using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CopyWithLineNumbers
{
    /// <summary>
    /// Manager for Variable Name, Description, and Regular Expressioin
    /// </summary>
    internal class VariableManager
    {
        /// <summary>
        /// Variable
        /// </summary>
        internal string Variable { get; set; }

        /// <summary>
        /// Description for Variable
        /// </summary>
        internal string Description { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Variable">Variable</param>
        /// <param name="Description">Variable Descriotion</param>
        internal VariableManager(string Variable, string Description)
        {
            this.Variable = Variable;
            this.Description = this.Variable + " : " + Description;
        }
    }

    /// <summary>
    /// Template Processing Class
    /// </summary>
    internal class Template
    {
        /// <summary>
        /// Template Name for FileName
        /// </summary>
        static internal string VariableForFileName = "{FileName}";

        /// <summary>
        /// Template Name for FullPath
        /// </summary>
        static internal string VariableForFullPath = "{FullPath}";

        /// <summary>
        /// Template Name for Relative Path from opened Solution
        /// </summary>
        static internal string VariableForRelativePath = "{RelativePath}";

        /// <summary>
        /// Template Name for Top Line Number
        /// </summary>
        static internal string VariableForTopLineNumber = "{TopLineNumber}";

        /// <summary>
        /// Template Name for Bottom Line Number
        /// </summary>
        static internal string VariableForBottomLineNumber = "{BottomLineNumber}";

        /// <summary>
        /// Template Name for Selection
        /// </summary>
        static internal string VariableForSelection = "{Selection}";

        /// <summary>
        /// Template Variables
        /// </summary>
        internal readonly static VariableManager[] Variables = new VariableManager[]
        {
            new VariableManager(VariableForFileName, "File Name"),
            new VariableManager(VariableForFullPath, "Absolute File Path"),
            new VariableManager(VariableForRelativePath, "Relative File Path from Solution File"),
            new VariableManager(VariableForTopLineNumber, "The Top Line Number"),
            new VariableManager(VariableForBottomLineNumber, "The Bottom Line Number"),
            new VariableManager(VariableForSelection, "Selection of Active Document"),
        };

        /// <summary>
        /// Default Template String
        /// </summary>
        internal readonly static string DefaultFormatString = VariableForSelection;

        /// <summary>
        /// Replace the template variable to the values defined by dictionary
        /// </summary>
        /// <param name="template">template string to be replace</param>
        /// <param name="values">the values to replace</param>
        /// <returns></returns>
        internal static string ProcessTemplate(string template, Dictionary<string, string> values)
        {
            const string pattern = @"({\w+})";
            string[] substrings = Regex.Split(template, pattern);

            string[] replacedStrings = new string[substrings.Length];

            int index = 0;
            foreach (string match in substrings)
            {
                replacedStrings[index] = match;
                foreach (VariableManager variableManager in Variables)
                {
                    if (match == variableManager.Variable)
                    {
                        replacedStrings[index] = values[variableManager.Variable];
                        break;
                    }
                }
                index++;
            }
            return string.Join(string.Empty, replacedStrings);
        }
    }
}
