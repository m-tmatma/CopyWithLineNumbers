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

        public bool IsAddFileNameAtFirst { get; set; }

        public FilenameFormatAtFirst FormatAtFirst { get; set; }

        public string AddBeforeFilename { get; set; }

        public string AddAfterFilename { get; set; }

        public LineNumberFormat Format { get; set; }

        public void Load()
        {
            try
            {
                RegistryKey rKey = Registry.Users.OpenSubKey(SubKeyName);

                try
                {
                    this.IsAddFileNameAtFirst = (bool)rKey.GetValue(ValueNameIsAddFileNameAtFirst);
                }
                catch (NullReferenceException)
                {
                    this.IsAddFileNameAtFirst = false;
                }

                try
                {
                    this.FormatAtFirst = (FilenameFormatAtFirst)rKey.GetValue(ValueNameFilenameFormatAtFirst);
                }
                catch (NullReferenceException)
                {
                    this.FormatAtFirst = FilenameFormatAtFirst.FileName;
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
                    this.Format = (LineNumberFormat)rKey.GetValue(ValueNameFilenameFormatAtFirst);
                }
                catch (NullReferenceException)
                {
                    this.Format = LineNumberFormat.LineNumber;
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
                RegistryKey rKey = Registry.Users.OpenSubKey(SubKeyName);

                try
                {
                    rKey.SetValue(ValueNameIsAddFileNameAtFirst, this.IsAddFileNameAtFirst);
                }
                catch (NullReferenceException)
                {
                }

                try
                {
                    rKey.SetValue(ValueNameFilenameFormatAtFirst, this.FormatAtFirst);
                }
                catch (NullReferenceException)
                {
                }

                try
                {
                    rKey.GetValue(ValueNameAddBeforeFilename, this.AddBeforeFilename);
                }
                catch (NullReferenceException)
                {
                }

                try
                {
                    rKey.GetValue(ValueNameAddAfterFilename, this.AddAfterFilename);
                }
                catch (NullReferenceException)
                {
                }

                try
                {
                    rKey.GetValue(ValueNameFilenameFormatAtFirst, this.Format);
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
