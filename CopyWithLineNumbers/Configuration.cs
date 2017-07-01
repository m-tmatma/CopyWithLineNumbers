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
    class Configuration
    {
        /// <summary>
        /// Singleton for this class
        /// </summary>
        private static volatile Configuration instance;

        /// <summary>
        /// Lock Object
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Registry SubKey for the setting
        /// </summary>
        private const string SubKeyName = @"SOFTWARE\mtmatma\CopyWithLineNumbers";

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
        public static Configuration Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Configuration();
                            instance.Load();
                        }
                    }
                }
                return instance;
            }
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
                RegistryKey rKey = Registry.CurrentUser.OpenSubKey(SubKeyName);

                try
                {
                    var value = (string)rKey.GetValue(ValueNameFormatString, DefaultFormatString);
                    this.FormatString = value;
                }
                catch (NullReferenceException)
                {
                }
                rKey.Close();
            }
            catch (NullReferenceException)
            {
            }
        }

        /// <summary>
        /// Store setting to registry
        /// </summary>
        public void Save()
        {
            try
            {
                RegistryKey rKey = Registry.CurrentUser.CreateSubKey(SubKeyName);

                try
                {
                    rKey.SetValue(ValueNameFormatString, this.FormatString);
                }
                catch (NullReferenceException)
                {
                }
                rKey.Close();
            }
            catch (NullReferenceException)
            {
            }
        }
    }
}
