//------------------------------------------------------------------------------
// <copyright file="VSPackage.cs" company="Masaru Tsuchiyama">
//     Copyright (c) Masaru Tsuchiyama.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;

namespace CopyWithLineNumbers
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [ProvideAutoLoad(Microsoft.VisualStudio.Shell.Interop.UIContextGuids.SolutionExists)]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [Guid(VSPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideOptionPageAttribute(typeof(OptionsPageSetting), "CopyWithLineNumbers", "Setting", 0, 0, true)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    public sealed class VSPackage : Package
    {
        /// <summary>
        /// VSPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "c43ac2b7-f6f8-4fb9-a537-eeb29a7a03eb";

        /// <summary>
        /// Initializes a new instance of the <see cref="VSPackage"/> class.
        /// </summary>
        public VSPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }


        /// <summary>
        /// Get DTE Object
        /// </summary>
        public EnvDTE.DTE GetDTE()
        {
            return (EnvDTE.DTE)GetService(typeof(SDTE));
        }

#if DEBUG
        /// <summary>
        /// Get OutputWindow
        /// </summary>
        public EnvDTE.Window GetOutputWindow(EnvDTE.DTE dte)
        {
            return dte.Windows.Item(EnvDTE.Constants.vsWindowKindOutput);
        }

        /// <summary>
        /// Add an item to OutputWindow
        /// </summary>
        public void AddOutputWindow(string paneName)
        {
            var outputWindow = (EnvDTE.OutputWindow)GetOutputWindow(GetDTE()).Object;
            this.OutputPane = outputWindow.OutputWindowPanes.Add(paneName);
        }
#endif

        /// <summary>
        /// Get Instance of Configuration
        /// </summary>
        /// <returns></returns>
        public Configuration GetConfiguration()
        {
            var configuration = new Configuration(this.UserRegistryRoot);
            configuration.Load();
            return configuration;
        }

        /// <summary>
        /// Property For OutputWindow
        /// </summary>
        public EnvDTE.OutputWindowPane OutputPane { get; private set; }

#region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
            CopyWithLineNumbersCommand.Initialize(this);

#if DEBUG
            AddOutputWindow("Copy With Line Numbers");
#endif
        }

        #endregion
    }
}
