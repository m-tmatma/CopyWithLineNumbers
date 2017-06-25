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
            this.SuspendLayout();
            // 
            // checkBoxAddFileNameAtFirst
            // 
            this.checkBoxAddFileNameAtFirst.AutoSize = true;
            this.checkBoxAddFileNameAtFirst.Location = new System.Drawing.Point(40, 18);
            this.checkBoxAddFileNameAtFirst.Name = "checkBoxAddFileNameAtFirst";
            this.checkBoxAddFileNameAtFirst.Size = new System.Drawing.Size(245, 25);
            this.checkBoxAddFileNameAtFirst.TabIndex = 0;
            this.checkBoxAddFileNameAtFirst.Text = "Add the filename at first";
            this.checkBoxAddFileNameAtFirst.UseVisualStyleBackColor = true;
            // 
            // OptionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBoxAddFileNameAtFirst);
            this.Name = "OptionsControl";
            this.Size = new System.Drawing.Size(1064, 688);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxAddFileNameAtFirst;
    }
}
