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
 
        public OptionsControl()
        {
            InitializeComponent();

            foreach(VariableManager variableName in Template.Variables)
            {
                this.comboBoxVariable.Items.Add(variableName.Description);
            }
            this.comboBoxVariable.SelectedIndex = 0;
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

        /// <summary>
        /// Save the setting to the registry
        /// </summary>
        /// <param name="configuration"></param>
        public void SaveSetting(Configuration configuration)
        {
            configuration.FormatString = this.textBoxTemplate.Text;
            configuration.Save();
        }

        /// <summary>
        /// Load the setting from the registry
        /// </summary>
        /// <param name="configuration"></param>
        public void LoadSetting(Configuration configuration)
        {
            this.textBoxTemplate.Text = configuration.FormatString;
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            var variable = Template.Variables[this.comboBoxVariable.SelectedIndex].Variable;
            var textBox = this.textBoxTemplate;
            textBox.Text = textBox.Text.Insert(textBox.SelectionStart, variable);
        }

        private void buttonInsertLineEnding_Click(object sender, EventArgs e)
        {
            var textBox = this.textBoxTemplate;
            textBox.Text = textBox.Text.Insert(textBox.SelectionStart, Environment.NewLine);
        }

        private void buttonSetDefault_Click(object sender, EventArgs e)
        {
            var textBox = this.textBoxTemplate;
            textBox.Text = Template.DefaultFormatString;
        }
    }
}
