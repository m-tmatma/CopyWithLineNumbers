using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CopyWithLineNumbers
{
    /// <summary>
    /// Configuration and setting manager
    /// </summary>
    public class Configuration
    {
        /// <summary>
        /// root registry key for user setting
        /// </summary>
        private RegistryKey UserRegistryRoot;

        /// <summary>
        /// Registry SubKey for the setting
        /// </summary>
        private const string SubKeyName = @"CopyWithLineNumbers";

        /// <summary>
        /// Registry Value Name for FormatString setting
        /// </summary>
        private const string ValueNameFormatString = "FormatString";

        /// <summary>
        /// Property for Template
        /// </summary>
        public string FormatString { get; set; }

        /// <summary>
        /// Property for getting singleton instance
        /// </summary>
        /// <param name="userRegistryRoot">root Registry for User setting</param>
        public Configuration(RegistryKey userRegistryRoot)
        {
            this.UserRegistryRoot = userRegistryRoot;
        }
 
        /// <summary>
        /// Load setting from registry
        /// </summary>
        public void Load()
        {
            var DefaultFormatString = Template.DefaultFormatString;
            this.FormatString = DefaultFormatString;
            try
            {
                using (RegistryKey subKey = this.UserRegistryRoot.OpenSubKey(SubKeyName))
                {
                    var value = (string)subKey.GetValue(ValueNameFormatString, DefaultFormatString);
                    this.FormatString = value;
                }
            }
            catch (NullReferenceException)
            {
                ;
            }
        }

        /// <summary>
        /// Store setting to registry
        /// </summary>
        public void Save()
        {
            try
            {
                using (RegistryKey subKey = this.UserRegistryRoot.CreateSubKey(SubKeyName))
                {
                    subKey.SetValue(ValueNameFormatString, this.FormatString);
                }
            }
            catch (NullReferenceException)
            {
                ;
            }
        }
    }
}
