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
            this.textBoxTemplate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxVariable = new System.Windows.Forms.ComboBox();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonInsertLineEnding = new System.Windows.Forms.Button();
            this.buttonSetDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxTemplate
            // 
            this.textBoxTemplate.Location = new System.Drawing.Point(40, 120);
            this.textBoxTemplate.Multiline = true;
            this.textBoxTemplate.Name = "textBoxTemplate";
            this.textBoxTemplate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxTemplate.Size = new System.Drawing.Size(600, 257);
            this.textBoxTemplate.TabIndex = 0;
            this.textBoxTemplate.WordWrap = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Template for copying string";
            // 
            // comboBoxVariable
            // 
            this.comboBoxVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxVariable.FormattingEnabled = true;
            this.comboBoxVariable.Location = new System.Drawing.Point(40, 26);
            this.comboBoxVariable.Name = "comboBoxVariable";
            this.comboBoxVariable.Size = new System.Drawing.Size(500, 29);
            this.comboBoxVariable.TabIndex = 2;
            // 
            // buttonInsert
            // 
            this.buttonInsert.Location = new System.Drawing.Point(565, 26);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(75, 29);
            this.buttonInsert.TabIndex = 3;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = true;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonInsertLineEnding
            // 
            this.buttonInsertLineEnding.Location = new System.Drawing.Point(481, 77);
            this.buttonInsertLineEnding.Name = "buttonInsertLineEnding";
            this.buttonInsertLineEnding.Size = new System.Drawing.Size(159, 29);
            this.buttonInsertLineEnding.TabIndex = 4;
            this.buttonInsertLineEnding.Text = "Insert EOL";
            this.buttonInsertLineEnding.UseVisualStyleBackColor = true;
            this.buttonInsertLineEnding.Click += new System.EventHandler(this.buttonInsertLineEnding_Click);
            // 
            // buttonSetDefault
            // 
            this.buttonSetDefault.Location = new System.Drawing.Point(302, 77);
            this.buttonSetDefault.Name = "buttonSetDefault";
            this.buttonSetDefault.Size = new System.Drawing.Size(159, 29);
            this.buttonSetDefault.TabIndex = 5;
            this.buttonSetDefault.Text = "Set Default";
            this.buttonSetDefault.UseVisualStyleBackColor = true;
            this.buttonSetDefault.Click += new System.EventHandler(this.buttonSetDefault_Click);
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSetDefault);
            this.Controls.Add(this.buttonInsertLineEnding);
            this.Controls.Add(this.buttonInsert);
            this.Controls.Add(this.comboBoxVariable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTemplate);
            this.Name = "OptionsControl";
            this.Size = new System.Drawing.Size(679, 405);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxVariable;
        private System.Windows.Forms.Button buttonInsert;
        private System.Windows.Forms.Button buttonInsertLineEnding;
        private System.Windows.Forms.Button buttonSetDefault;
    }
}
