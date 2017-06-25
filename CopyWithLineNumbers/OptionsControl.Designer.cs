namespace CopyWithLineNumbers
{
    partial class OptionsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxAddFileNameAtFirst = new System.Windows.Forms.CheckBox();
            this.comboBoxPathFormatAtFirst = new System.Windows.Forms.ComboBox();
            this.textBoxAddFirst = new System.Windows.Forms.TextBox();
            this.textBoxAddLast = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFormatOfTheLineNumbers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // checkBoxAddFileNameAtFirst
            // 
            this.checkBoxAddFileNameAtFirst.AutoSize = true;
            this.checkBoxAddFileNameAtFirst.Location = new System.Drawing.Point(62, 44);
            this.checkBoxAddFileNameAtFirst.Name = "checkBoxAddFileNameAtFirst";
            this.checkBoxAddFileNameAtFirst.Size = new System.Drawing.Size(245, 25);
            this.checkBoxAddFileNameAtFirst.TabIndex = 0;
            this.checkBoxAddFileNameAtFirst.Text = "Add the filename at first";
            this.checkBoxAddFileNameAtFirst.UseVisualStyleBackColor = true;
            this.checkBoxAddFileNameAtFirst.CheckedChanged += new System.EventHandler(this.checkBoxAddFileNameAtFirst_CheckedChanged);
            // 
            // comboBoxPathFormatAtFirst
            // 
            this.comboBoxPathFormatAtFirst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPathFormatAtFirst.Enabled = false;
            this.comboBoxPathFormatAtFirst.FormattingEnabled = true;
            this.comboBoxPathFormatAtFirst.Location = new System.Drawing.Point(189, 88);
            this.comboBoxPathFormatAtFirst.Name = "comboBoxPathFormatAtFirst";
            this.comboBoxPathFormatAtFirst.Size = new System.Drawing.Size(401, 29);
            this.comboBoxPathFormatAtFirst.TabIndex = 1;
            // 
            // textBoxAddFirst
            // 
            this.textBoxAddFirst.Enabled = false;
            this.textBoxAddFirst.Location = new System.Drawing.Point(345, 154);
            this.textBoxAddFirst.Name = "textBoxAddFirst";
            this.textBoxAddFirst.Size = new System.Drawing.Size(245, 28);
            this.textBoxAddFirst.TabIndex = 2;
            // 
            // textBoxAddLast
            // 
            this.textBoxAddLast.Enabled = false;
            this.textBoxAddLast.Location = new System.Drawing.Point(345, 212);
            this.textBoxAddLast.Name = "textBoxAddLast";
            this.textBoxAddLast.Size = new System.Drawing.Size(245, 28);
            this.textBoxAddLast.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add this before the filename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(241, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Add this after the filename";
            // 
            // comboBoxFormatOfTheLineNumbers
            // 
            this.comboBoxFormatOfTheLineNumbers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFormatOfTheLineNumbers.FormattingEnabled = true;
            this.comboBoxFormatOfTheLineNumbers.Location = new System.Drawing.Point(167, 291);
            this.comboBoxFormatOfTheLineNumbers.Name = "comboBoxFormatOfTheLineNumbers";
            this.comboBoxFormatOfTheLineNumbers.Size = new System.Drawing.Size(397, 29);
            this.comboBoxFormatOfTheLineNumbers.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Format";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Format";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(27, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 265);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Before Selection";
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxFormatOfTheLineNumbers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxAddLast);
            this.Controls.Add(this.textBoxAddFirst);
            this.Controls.Add(this.comboBoxPathFormatAtFirst);
            this.Controls.Add(this.checkBoxAddFileNameAtFirst);
            this.Controls.Add(this.groupBox1);
            this.Name = "OptionsControl";
            this.Size = new System.Drawing.Size(836, 511);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAddFileNameAtFirst;
        private System.Windows.Forms.ComboBox comboBoxPathFormatAtFirst;
        private System.Windows.Forms.TextBox textBoxAddFirst;
        private System.Windows.Forms.TextBox textBoxAddLast;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxFormatOfTheLineNumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
