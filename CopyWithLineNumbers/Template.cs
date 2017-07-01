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
        /// Variable Name
        /// </summary>
        internal string Name { get; set; }

        /// <summary>
        /// Description for Variable
        /// </summary>
        internal string Description { get; set; }

        /// <summary>
        /// Regular Expression for Variable
        /// </summary>
        internal Regex Regex { get; set; }

        /// <summary>
        /// Create a string for a variable
        /// </summary>
        /// <param name="variable">variable to be converted</param>
        /// <returns></returns>
        internal static string CreateStringForVariable(string variable)
        {
            return "{" + variable + "}";
        }

        /// <summary>
        /// Create a regular expression for a variable
        /// </summary>
        /// <param name="variable">variable to be converted</param>
        /// <returns></returns>
        private static string CreateRegExForVariable(string variable)
        {
            return "{" + variable + "}";
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="Name">Variable Name</param>
        /// <param name="Description">Variable Descriotion</param>
        internal VariableManager(string Name, string Description)
        {
            this.Name = Name;
            this.Description = Description;
            this.Regex = new Regex(CreateRegExForVariable(Name), RegexOptions.Compiled);
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
        static internal string KeyNameForFileName = "FileName";

        /// <summary>
        /// Template Name for FullPath
        /// </summary>
        static internal string KeyNameForFullPath = "FullPath";

        /// <summary>
        /// Template Name for Line Number
        /// </summary>
        static internal string KeyNameForLineNumber = "LineNumber";

        /// <summary>
        /// Template Name for Selection
        /// </summary>
        static internal string KeyNameForSelection = "Selection";

        /// <summary>
        /// Template Variables
        /// </summary>
        internal readonly static VariableManager[] Variables = new VariableManager[]
        {
            new VariableManager(KeyNameForFileName, "FileName"),
            new VariableManager(KeyNameForFullPath, "Absolute File Path"),
            new VariableManager(KeyNameForLineNumber, "File Number"),
            new VariableManager(KeyNameForSelection, "Selection of Active Document"),
        };

        /// <summary>
        /// Default Template String
        /// </summary>
        internal readonly static string DefaultFormatString = VariableManager.CreateStringForVariable(KeyNameForSelection);

        /// <summary>
        /// Replace the template variable to the values defined by dictionary
        /// </summary>
        /// <param name="template">template string to be replace</param>
        /// <param name="values">the values to replace</param>
        /// <returns></returns>
        internal static string ProcessTemplate(string template, Dictionary<string, string> values)
        {
            foreach (VariableManager variableManager in Variables)
            {
                if (values.ContainsKey(variableManager.Name))
                {
                    var value = values[variableManager.Name];
                    template = variableManager.Regex.Replace(template, value);
                }
            }
            return template;
        }
    }
}
