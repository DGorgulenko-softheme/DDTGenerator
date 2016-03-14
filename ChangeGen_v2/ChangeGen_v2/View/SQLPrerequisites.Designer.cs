namespace ChangeGen_v2
{
    partial class SQLPrerequisites
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
            this.cb_doNotShow = new System.Windows.Forms.CheckBox();
            this.btn_OK = new System.Windows.Forms.Button();
            this.lbl_prerequisitesText = new System.Windows.Forms.Label();
            this.lbl_prerequisitesHeader = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_doNotShow
            // 
            this.cb_doNotShow.AutoSize = true;
            this.cb_doNotShow.Location = new System.Drawing.Point(172, 153);
            this.cb_doNotShow.Name = "cb_doNotShow";
            this.cb_doNotShow.Size = new System.Drawing.Size(182, 17);
            this.cb_doNotShow.TabIndex = 7;
            this.cb_doNotShow.Text = "Do not show this message again.";
            this.cb_doNotShow.UseVisualStyleBackColor = true;
            this.cb_doNotShow.CheckedChanged += new System.EventHandler(this.cb_doNotShow_CheckedChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(229, 172);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 6;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // lbl_prerequisitesText
            // 
            this.lbl_prerequisitesText.AutoSize = true;
            this.lbl_prerequisitesText.Location = new System.Drawing.Point(37, 26);
            this.lbl_prerequisitesText.Name = "lbl_prerequisitesText";
            this.lbl_prerequisitesText.Size = new System.Drawing.Size(35, 13);
            this.lbl_prerequisitesText.TabIndex = 5;
            this.lbl_prerequisitesText.Text = "label1";
            // 
            // lbl_prerequisitesHeader
            // 
            this.lbl_prerequisitesHeader.AutoSize = true;
            this.lbl_prerequisitesHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_prerequisitesHeader.Location = new System.Drawing.Point(12, 9);
            this.lbl_prerequisitesHeader.Name = "lbl_prerequisitesHeader";
            this.lbl_prerequisitesHeader.Size = new System.Drawing.Size(486, 13);
            this.lbl_prerequisitesHeader.TabIndex = 4;
            this.lbl_prerequisitesHeader.Text = "For successful SQL generation, please, check the following necessary prerequisite" +
    "s:";
            // 
            // SQLPrerequisites
            // 
            this.AcceptButton = this.btn_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 203);
            this.ControlBox = false;
            this.Controls.Add(this.cb_doNotShow);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.lbl_prerequisitesText);
            this.Controls.Add(this.lbl_prerequisitesHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SQLPrerequisites";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Prerequisites Warning";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_doNotShow;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Label lbl_prerequisitesText;
        private System.Windows.Forms.Label lbl_prerequisitesHeader;
    }
}