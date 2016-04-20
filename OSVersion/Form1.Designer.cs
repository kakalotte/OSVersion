namespace OSVersion
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OSInfo_TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OSInfo_TextBox
            // 
            this.OSInfo_TextBox.Location = new System.Drawing.Point(12, 12);
            this.OSInfo_TextBox.Multiline = true;
            this.OSInfo_TextBox.Name = "OSInfo_TextBox";
            this.OSInfo_TextBox.ReadOnly = true;
            this.OSInfo_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.OSInfo_TextBox.Size = new System.Drawing.Size(602, 349);
            this.OSInfo_TextBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 373);
            this.Controls.Add(this.OSInfo_TextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Environment Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OSInfo_TextBox;
    }
}

