namespace ChangeGen_v2
{
    partial class FrmAbout
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
            this.lbl_About_title = new System.Windows.Forms.Label();
            this.lbl_About_description = new System.Windows.Forms.Label();
            this.linkGDrive = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lbl_About_title
            // 
            this.lbl_About_title.AutoSize = true;
            this.lbl_About_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_About_title.Location = new System.Drawing.Point(13, 13);
            this.lbl_About_title.Name = "lbl_About_title";
            this.lbl_About_title.Size = new System.Drawing.Size(195, 17);
            this.lbl_About_title.TabIndex = 0;
            this.lbl_About_title.Text = "DDT Data Generator 0.2b";
            // 
            // lbl_About_description
            // 
            this.lbl_About_description.AutoSize = true;
            this.lbl_About_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_About_description.Location = new System.Drawing.Point(16, 54);
            this.lbl_About_description.Name = "lbl_About_description";
            this.lbl_About_description.Size = new System.Drawing.Size(43, 17);
            this.lbl_About_description.TabIndex = 1;
            this.lbl_About_description.Text = "Label";
            // 
            // linkGDrive
            // 
            this.linkGDrive.AutoSize = true;
            this.linkGDrive.Location = new System.Drawing.Point(16, 142);
            this.linkGDrive.Name = "linkGDrive";
            this.linkGDrive.Size = new System.Drawing.Size(186, 13);
            this.linkGDrive.TabIndex = 2;
            this.linkGDrive.TabStop = true;
            this.linkGDrive.Text = "DDT Data Generator on Google Docs";
            this.linkGDrive.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkGDrive_LinkClicked);
            // 
            // FrmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 343);
            this.Controls.Add(this.linkGDrive);
            this.Controls.Add(this.lbl_About_description);
            this.Controls.Add(this.lbl_About_title);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAbout";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_About_title;
        private System.Windows.Forms.Label lbl_About_description;
        private System.Windows.Forms.LinkLabel linkGDrive;
    }
}