namespace ChangeGen_v2
{
    partial class AddSQLServerManually
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
            this.components = new System.ComponentModel.Container();
            this.lbl_Password = new System.Windows.Forms.Label();
            this.lbl_UserName = new System.Windows.Forms.Label();
            this.lbl_IP = new System.Windows.Forms.Label();
            this.btn_Add = new System.Windows.Forms.Button();
            this.tb_Password = new System.Windows.Forms.TextBox();
            this.tb_UserName = new System.Windows.Forms.TextBox();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Password
            // 
            this.lbl_Password.AutoSize = true;
            this.lbl_Password.Location = new System.Drawing.Point(292, 8);
            this.lbl_Password.Name = "lbl_Password";
            this.lbl_Password.Size = new System.Drawing.Size(53, 13);
            this.lbl_Password.TabIndex = 14;
            this.lbl_Password.Text = "Password";
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.AutoSize = true;
            this.lbl_UserName.Location = new System.Drawing.Point(126, 8);
            this.lbl_UserName.Name = "lbl_UserName";
            this.lbl_UserName.Size = new System.Drawing.Size(55, 13);
            this.lbl_UserName.TabIndex = 13;
            this.lbl_UserName.Text = "Username";
            // 
            // lbl_IP
            // 
            this.lbl_IP.AutoSize = true;
            this.lbl_IP.Location = new System.Drawing.Point(14, 8);
            this.lbl_IP.Name = "lbl_IP";
            this.lbl_IP.Size = new System.Drawing.Size(17, 13);
            this.lbl_IP.TabIndex = 12;
            this.lbl_IP.Text = "IP";
            // 
            // btn_Add
            // 
            this.btn_Add.Enabled = false;
            this.btn_Add.Location = new System.Drawing.Point(214, 50);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 11;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // tb_Password
            // 
            this.tb_Password.Location = new System.Drawing.Point(295, 24);
            this.tb_Password.Name = "tb_Password";
            this.tb_Password.Size = new System.Drawing.Size(165, 20);
            this.tb_Password.TabIndex = 10;
            this.tb_Password.UseSystemPasswordChar = true;
            this.tb_Password.TextChanged += new System.EventHandler(this.tb_Password_TextChanged);
            this.tb_Password.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Password_Validating);
            this.tb_Password.Validated += new System.EventHandler(this.tb_Password_Validated);
            // 
            // tb_UserName
            // 
            this.tb_UserName.Location = new System.Drawing.Point(129, 24);
            this.tb_UserName.Name = "tb_UserName";
            this.tb_UserName.Size = new System.Drawing.Size(151, 20);
            this.tb_UserName.TabIndex = 9;
            this.tb_UserName.TextChanged += new System.EventHandler(this.tb_UserName_TextChanged);
            this.tb_UserName.Validating += new System.ComponentModel.CancelEventHandler(this.tb_UserName_Validating);
            this.tb_UserName.Validated += new System.EventHandler(this.tb_UserName_Validated);
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(14, 24);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(100, 20);
            this.tb_IP.TabIndex = 8;
            this.tb_IP.TextChanged += new System.EventHandler(this.tb_IP_TextChanged);
            this.tb_IP.Validating += new System.ComponentModel.CancelEventHandler(this.tb_IP_Validating);
            this.tb_IP.Validated += new System.EventHandler(this.tb_IP_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddSQLServerManually
            // 
            this.AcceptButton = this.btn_Add;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(475, 81);
            this.Controls.Add(this.lbl_Password);
            this.Controls.Add(this.lbl_UserName);
            this.Controls.Add(this.lbl_IP);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.tb_Password);
            this.Controls.Add(this.tb_UserName);
            this.Controls.Add(this.tb_IP);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSQLServerManually";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please specify SQL Server Credentials";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Password;
        private System.Windows.Forms.Label lbl_UserName;
        private System.Windows.Forms.Label lbl_IP;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.TextBox tb_Password;
        private System.Windows.Forms.TextBox tb_UserName;
        private System.Windows.Forms.TextBox tb_IP;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}