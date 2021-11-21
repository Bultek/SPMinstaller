namespace SPMcs
{
    partial class SPMinstall
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SPMinstall));
            this.InstallBPM = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InstallBPM
            // 
            this.InstallBPM.Location = new System.Drawing.Point(12, 179);
            this.InstallBPM.Name = "InstallBPM";
            this.InstallBPM.Size = new System.Drawing.Size(158, 30);
            this.InstallBPM.TabIndex = 0;
            this.InstallBPM.Text = "Install SPM";
            this.InstallBPM.UseVisualStyleBackColor = true;
            this.InstallBPM.Click += new System.EventHandler(this.button1_Click);
            // 
            // remove
            // 
            this.remove.Location = new System.Drawing.Point(238, 179);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(158, 30);
            this.remove.TabIndex = 2;
            this.remove.Text = "Remove SPM";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SPMinstall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 354);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.InstallBPM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SPMinstall";
            this.Text = "SPM INSTALLER (DEV)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InstallBPM;
        private System.Windows.Forms.Button remove;
    }
}

