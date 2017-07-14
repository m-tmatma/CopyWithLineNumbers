//------------------------------------------------------------------------------
// <copyright file="CopyWithLineNumbersCommand.cs" company="Masaru Tsuchiyama">
//     Copyright (c) Masaru Tsuchiyama.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Globalization;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace CopyWithLineNumbers
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class CopyWithLineNumbersCommand
    {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int CommandId = 0x0100;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid CommandSet = new Guid("02e696a1-06f8-4e96-afcd-66c98176b584");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly VSPackage package;


        /// <summary>
        /// control whether an menu item is displayed or not.
        /// </summary>
        private void BeforeQueryStatus(object sender, EventArgs e)
        {
            OleMenuCommand command = sender as OleMenuCommand;
            if (command != null)
            {
                var dte = this.package.GetDTE();
                var activeDocument = dte.ActiveDocument;

                command.Visible = false;
                if (activeDocument != null)
                {
                    var configuration = this.package.GetConfiguration();
                    var selection = (EnvDTE.TextSelection)activeDocument.Selection;
                    if (!selection.IsEmpty)
                    {
                        command.Visible = true;
                    }
                    else
                    {
                        var values = CreateValuesDictionary();
                        values[Template.VariableForSelection] = string.Empty;
                        var formatString = configuration.FormatString;

                        var copyString = Template.ProcessTemplate(formatString, values);
                        var clippedString = copyString.Replace("\n", "");
                        if (!string.IsNullOrWhiteSpace(clippedString))
                        {
                            command.Visible = true;
                        }
                    }
                }
            }
        }
 
        /// <summary>
        /// Initializes a new instance of the <see cref="CopyWithLineNumbersCommand"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private CopyWithLineNumbersCommand(VSPackage package)
        {
            if (package == null)
            {
                throw new ArgumentNullException("package");
            }

            this.package = package;

            OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (commandService != null)
            {
                var menuCommandID = new CommandID(CommandSet, CommandId);
                var menuItem = new OleMenuCommand(this.MenuItemCallback, menuCommandID);
                menuItem.BeforeQueryStatus += this.BeforeQueryStatus;
                commandService.AddCommand(menuItem);
            }
        }

        /// <summary>
        /// Gets the instance of the command.
        /// </summary>
        public static CopyWithLineNumbersCommand Instance
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider
        {
            get
            {
                return this.package;
            }
        }

        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize(VSPackage package)
        {
            Instance = new CopyWithLineNumbersCommand(package);
        }

#if DEBUG
        /// <summary>
        /// Print to Output Window
        /// </summary>
        internal void OutputString(string output)
        {
            var outPutPane = this.package.OutputPane;
            outPutPane.OutputString(output);
        }

        /// <summary>
        /// Print to Output Window with Line Ending
        /// </summary>
        internal void OutputStringLine(string output)
        {
            OutputString(output + Environment.NewLine);
        }

        /// <summary>
        /// Clear Output Window
        /// </summary>
        internal void ClearOutout()
        {
            var outPutPane = this.package.OutputPane;
            outPutPane.Clear();
        }

        /// <summary>
        /// Clear Output Window
        /// </summary>
        internal void ActivateOutout()
        {
            var outPutPane = this.package.OutputPane;
            outPutPane.Activate();
        }
#endif
        /// <summary>
        /// Create relative Path from the solution file
        /// </summary>
        /// <param name="path">file path to be converted</param>
        /// <returns></returns>
        private string CreateSolutionRelativePath(string path)
        {
            var dte = this.package.GetDTE();
            if (File.Exists(dte.Solution.FullName))
            {
                var solutionDir = Path.GetDirectoryName(dte.Solution.FullName);

                var baseUri = new Uri(solutionDir + "\\");
                var targetUri = new Uri(path);

                var relativeUri = baseUri.MakeRelativeUri(targetUri);
                return relativeUri.ToString().Replace("/", "\\");
            }
            else
            {
                return Path.GetFileName(path);
            }
        }

        /// <summary>
        /// Format the selection
        /// </summary>
        /// <param name="selectionText">selected text</param>
        /// <param name="topLine">the first line number of the selection</param>
        /// <param name="bottomLine">the last line number of the selection</param>
        /// <returns>formatted text</returns>
        private string FormatSelection(string selectionText, int topLine, int bottomLine)
        {
            if (!string.IsNullOrEmpty(selectionText))
            {
                var builder = new StringBuilder();
                var lines = selectionText.Split(new String[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                var width = bottomLine.ToString().Length;
                int count = 0;
                foreach (string line in lines)
                {
                    if (count == lines.Length - 1)
                    {
                        if (string.IsNullOrEmpty(line))
                        {
                            break;
                        }
                    }
                    var lineNumber = topLine + count;
                    builder.Append(lineNumber.ToString().PadLeft(width));
                    builder.Append(": ");
                    builder.Append(line);
                    builder.Append(Environment.NewLine);
                    count++;
                }
                return builder.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Create a dictionary for the template values
        /// </summary>
        /// <returns></returns>
        private Dictionary<string, string> CreateValuesDictionary()
        {
            var values = new Dictionary<string, string>();
            foreach (VariableManager variableManager in Template.Variables)
            {
                values[variableManager.Variable] = string.Empty;
            }

            var dte = this.package.GetDTE();
            var activeDocument = dte.ActiveDocument;
            if (activeDocument != null)
            {
                var selection = (EnvDTE.TextSelection)activeDocument.Selection;
                var text = selection.Text;
                var formatedSelection = FormatSelection(text, selection.TopLine, selection.BottomLine);
                values[Template.VariableForSelection] = formatedSelection;
                values[Template.VariableForTopLineNumber] = string.Format("{0}", selection.TopLine);
                values[Template.VariableForBottomLineNumber] = string.Format("{0}", selection.BottomLine);
            }
            values[Template.VariableForFileName] = Path.GetFileName(activeDocument.FullName);
            values[Template.VariableForFullPath] = activeDocument.FullName;
            values[Template.VariableForRelativePath] = CreateSolutionRelativePath(activeDocument.FullName);
            return values;
        }

        /// <summary>
        /// This function is the callback used to execute the command when the menu item is clicked.
        /// See the constructor to see how the menu item is associated with this function using
        /// OleMenuCommandService service and MenuCommand class.
        /// </summary>
        /// <param name="sender">Event sender.</param>
        /// <param name="e">Event args.</param>
        private void MenuItemCallback(object sender, EventArgs e)
        {
            var dte = this.package.GetDTE();
            var activeDocument = dte.ActiveDocument;

            if (activeDocument != null)
            {
                var values = CreateValuesDictionary();
                var configuration = this.package.GetConfiguration();
                var formatString = configuration.FormatString;

                var copyString = Template.ProcessTemplate(formatString, values);
#if DEBUG
                this.ClearOutout();
                this.ActivateOutout();
                this.OutputString(copyString);
#endif
                Clipboard.SetDataObject(copyString);
            }
        }
    }
}
