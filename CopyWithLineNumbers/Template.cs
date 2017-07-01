using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CopyWithLineNumbers
{
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
        /// Template Variable Names
        /// </summary>
        readonly static string[] TemplateNames = new string[]
        {
            KeyNameForFileName,
            KeyNameForFullPath,
            KeyNameForLineNumber,
            KeyNameForSelection,
        };

        /// <summary>
        /// Template Variable Name and the regular expression
        /// </summary>
        private class RegexAndName
        {
            /// <summary>
            /// Template Variable Name
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Regular Expression
            /// </summary>
            public Regex Expression { get; set; }
        }

        /// <summary>
        /// Create data for template processing
        /// </summary>
        /// <returns></returns>
        private static List<RegexAndName> CreateTemplateData()
        {
            var regexList = new List<RegexAndName>();
            foreach (string templateName in TemplateNames)
            {
                var regexString = "{" + string.Format("{0}", templateName) + "}";

                var regexAndName = new RegexAndName();
                regexAndName.Name = templateName;
                regexAndName.Expression = new Regex(regexString, RegexOptions.Compiled);
                regexList.Add(regexAndName);
            }
            return regexList;
        }

        /// <summary>
        /// Replace the template variable to the values defined by dictionary
        /// </summary>
        /// <param name="template">template string to be replace</param>
        /// <param name="values">the values to replace</param>
        /// <returns></returns>
        internal static string ProcessTemplate(string template, Dictionary<string, string> values)
        {
            var regexList = CreateTemplateData();

            foreach (RegexAndName regex in regexList)
            {
                if (values.ContainsKey(regex.Name))
                {
                    var value = values[regex.Name];
                    template = regex.Expression.Replace(template, value);
                }
            }
            return template;
        }
    }
}
