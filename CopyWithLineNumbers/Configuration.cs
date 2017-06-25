using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CopyWithLineNumbers
{
    class Configuration
    {
        private static volatile Configuration instance;
        private static object syncRoot = new Object();

        private const string SubKeyName = @"SOFTWARE\mtmatma\CopyWithLineNumbers";
        private const string ValueNameIsAddFileNameAtFirst = "IsAddFileNameAtFirst";
        private const string ValueNameFilenameFormatAtFirst = "FormatOfFileNameAtFirst";
        private const string ValueNameAddBeforeFilename = "AddBeforeFilename";
        private const string ValueNameAddAfterFilename = "AddAfterFilename";
        private const string ValueNameLineNumberFormat = "LineNumberFormat";

        public enum FilenameFormatAtFirst
        {
            FileName,
            FileNameWithLineNumber,
            AbsoluteFilePath,
            AbsoluteFilepathWithLineNumber,
        }

        public enum LineNumberFormat
        {
            LineNumber,
            LineNumberWithFileName,
            LineNumberWithAbsoluteFilePath,
        }

        public const FilenameFormatAtFirst DefaultFilenameFormatAtFirst = FilenameFormatAtFirst.FileName;
        public const LineNumberFormat DefaultLineNumberFormat = LineNumberFormat.LineNumber;

        public bool IsAddFileNameAtFirst { get; set; }

        public FilenameFormatAtFirst FormatAtFirst { get; set; }

        public string AddBeforeFilename { get; set; }

        public string AddAfterFilename { get; set; }

        public LineNumberFormat Format { get; set; }

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
 
        public void Load()
        {
            try
            {
                RegistryKey rKey = Registry.CurrentUser.OpenSubKey(SubKeyName);

                try
                {
                    int value = (int)rKey.GetValue(ValueNameIsAddFileNameAtFirst);
                    this.IsAddFileNameAtFirst = (value != 0) ? true : false;
                }
                catch (NullReferenceException)
                {
                    this.IsAddFileNameAtFirst = false;
                }

                try
                {
                    int value = (int)rKey.GetValue(ValueNameFilenameFormatAtFirst);
                    if (Enum.IsDefined(typeof(FilenameFormatAtFirst), value))
                    {
                        this.FormatAtFirst = (FilenameFormatAtFirst)value;
                    }
                    else
                    {
                        this.FormatAtFirst = DefaultFilenameFormatAtFirst;
                    }
                }
                catch (NullReferenceException)
                {
                    this.FormatAtFirst = DefaultFilenameFormatAtFirst;
                }

                try
                {
                    this.AddBeforeFilename = (string)rKey.GetValue(ValueNameAddBeforeFilename);
                }
                catch (NullReferenceException)
                {
                    this.AddBeforeFilename = string.Empty;
                }

                try
                {
                    this.AddAfterFilename = (string)rKey.GetValue(ValueNameAddAfterFilename);
                }
                catch (NullReferenceException)
                {
                    this.AddAfterFilename = string.Empty;
                }

                try
                {
                    int value = (int)rKey.GetValue(ValueNameLineNumberFormat);
                    if (Enum.IsDefined(typeof(LineNumberFormat), value))
                    {
                        this.Format = (LineNumberFormat)value;
                    }
                    else
                    {
                        this.Format = DefaultLineNumberFormat;
                    }
                }
                catch (NullReferenceException)
                {
                    this.Format = DefaultLineNumberFormat;
                }

                rKey.Close();
            }
            catch (NullReferenceException)
            {
            }
        }

        public void Save()
        {
            try
            {
                RegistryKey rKey = Registry.CurrentUser.CreateSubKey(SubKeyName);

                try
                {
                    rKey.SetValue(ValueNameIsAddFileNameAtFirst, this.IsAddFileNameAtFirst ? 1 : 0);
                }
                catch (NullReferenceException)
                {
                }

                try
                {
                    rKey.SetValue(ValueNameFilenameFormatAtFirst, (int)this.FormatAtFirst);
                }
                catch (NullReferenceException)
                {
                }

                try
                {
                    rKey.SetValue(ValueNameAddBeforeFilename, this.AddBeforeFilename);
                }
                catch (NullReferenceException)
                {
                }

                try
                {
                    rKey.SetValue(ValueNameAddAfterFilename, this.AddAfterFilename);
                }
                catch (NullReferenceException)
                {
                }

                try
                {
                    rKey.SetValue(ValueNameLineNumberFormat, (int)this.Format);
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
