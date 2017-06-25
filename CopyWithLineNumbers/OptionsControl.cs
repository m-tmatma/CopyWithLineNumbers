using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyWithLineNumbers
{
    public partial class OptionsControl : UserControl
    {
        private OptionsPageSetting settingOptionsPage;
        readonly private string[] textsFormatsAtFirst = new string[] {
            "FileName",
            "FileName With Line Number",
            "Absolute FilePath",
            "Absolute FilePath With Line Number",
        };
        readonly private string[] textsFormatsOfLineNumbers = new string[] {
            "Line Number",
            "Line Number with FileName",
            "Line Number with Absolute FilePath",
        };

        public OptionsControl()
        {
            InitializeComponent();

            foreach (string item in this.textsFormatsAtFirst)
            {
                this.comboBoxPathFormatAtFirst.Items.Add(item);
            }
            foreach (string item in this.textsFormatsOfLineNumbers)
            {
                this.comboBoxFormatOfTheLineNumbers.Items.Add(item);
            }

            this.comboBoxPathFormatAtFirst.SelectedIndex = 0;
            this.comboBoxFormatOfTheLineNumbers.SelectedIndex = 0;
        }

        /// <summary>
        /// Gets or sets the reference to the underlying OptionsPage object.
        /// </summary>
        public OptionsPageSetting OptionsPage
        {
            get
            {
                return settingOptionsPage;
            }
            set
            {
                settingOptionsPage = value;
            }
        }

        private void checkBoxAddFileNameAtFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBoxAddFileNameAtFirst.Checked)
            {
                this.comboBoxPathFormatAtFirst.Enabled = true;
                this.textBoxAddFirst.Enabled = true;
                this.textBoxAddLast.Enabled = true;
            }
            else
            {
                this.comboBoxPathFormatAtFirst.Enabled = false;
                this.textBoxAddFirst.Enabled = false;
                this.textBoxAddLast.Enabled = false;
            }
        }
    }
}
