namespace ChangeGen_v2
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
            this.components = new System.ComponentModel.Container();
            this.tb_hostname = new System.Windows.Forms.TextBox();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.lv_AgentsList = new System.Windows.Forms.ListView();
            this.cb_selectAllAgents = new System.Windows.Forms.CheckBox();
            this.btn_StartDDT = new System.Windows.Forms.Button();
            this.tb_Size = new System.Windows.Forms.TextBox();
            this.btn_StopDDT = new System.Windows.Forms.Button();
            this.lbl_Size = new System.Windows.Forms.Label();
            this.lbl_Compression = new System.Windows.Forms.Label();
            this.tb_Compression = new System.Windows.Forms.TextBox();
            this.lbl_Path = new System.Windows.Forms.Label();
            this.tb_Path = new System.Windows.Forms.TextBox();
            this.lbl_Interval = new System.Windows.Forms.Label();
            this.tb_Interval = new System.Windows.Forms.TextBox();
            this.lbl_hostname = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.cb_useCoreCreds = new System.Windows.Forms.CheckBox();
            this.lbl_customUsername = new System.Windows.Forms.Label();
            this.tb_customUsername = new System.Windows.Forms.TextBox();
            this.tb_customPassword = new System.Windows.Forms.TextBox();
            this.lbl_customPassword = new System.Windows.Forms.Label();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.gb_customcreds = new System.Windows.Forms.GroupBox();
            this.gb_ddtparams = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl_ChangeRateLabel = new System.Windows.Forms.Label();
            this.lbl_ChangeRateValue = new System.Windows.Forms.Label();
            this.lbl_totalAgentsRunningValue = new System.Windows.Forms.Label();
            this.lbl_totalAgentsRunninglabel = new System.Windows.Forms.Label();
            this.lbl_TotalAmountLabel = new System.Windows.Forms.Label();
            this.lbl_TotalAmountValue = new System.Windows.Forms.Label();
            this.gb_customcreds.SuspendLayout();
            this.gb_ddtparams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_hostname
            // 
            this.tb_hostname.Location = new System.Drawing.Point(327, 267);
            this.tb_hostname.Margin = new System.Windows.Forms.Padding(2);
            this.tb_hostname.Name = "tb_hostname";
            this.tb_hostname.Size = new System.Drawing.Size(115, 20);
            this.tb_hostname.TabIndex = 0;
            this.tb_hostname.Validating += new System.ComponentModel.CancelEventHandler(this.tb_hostname_Validating);
            this.tb_hostname.Validated += new System.EventHandler(this.tb_hostname_Validated);
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(327, 290);
            this.tb_userName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(174, 20);
            this.tb_userName.TabIndex = 1;
            this.tb_userName.Validating += new System.ComponentModel.CancelEventHandler(this.tb_userName_Validating);
            this.tb_userName.Validated += new System.EventHandler(this.tb_userName_Validated);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(327, 313);
            this.tb_password.Margin = new System.Windows.Forms.Padding(2);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(174, 20);
            this.tb_password.TabIndex = 2;
            this.tb_password.UseSystemPasswordChar = true;
            this.tb_password.Validating += new System.ComponentModel.CancelEventHandler(this.tb_password_Validating);
            this.tb_password.Validated += new System.EventHandler(this.tb_password_Validated);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Connect.Location = new System.Drawing.Point(378, 336);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 29);
            this.btn_Connect.TabIndex = 3;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = true;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // lv_AgentsList
            // 
            this.lv_AgentsList.Location = new System.Drawing.Point(10, 11);
            this.lv_AgentsList.Margin = new System.Windows.Forms.Padding(2);
            this.lv_AgentsList.Name = "lv_AgentsList";
            this.lv_AgentsList.Size = new System.Drawing.Size(649, 370);
            this.lv_AgentsList.TabIndex = 0;
            this.lv_AgentsList.UseCompatibleStateImageBehavior = false;
            this.lv_AgentsList.Visible = false;
            this.lv_AgentsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_AgentsList_ColumnClick);
            // 
            // cb_selectAllAgents
            // 
            this.cb_selectAllAgents.AutoSize = true;
            this.cb_selectAllAgents.Location = new System.Drawing.Point(16, 18);
            this.cb_selectAllAgents.Margin = new System.Windows.Forms.Padding(2);
            this.cb_selectAllAgents.Name = "cb_selectAllAgents";
            this.cb_selectAllAgents.Size = new System.Drawing.Size(15, 14);
            this.cb_selectAllAgents.TabIndex = 3;
            this.cb_selectAllAgents.UseVisualStyleBackColor = true;
            this.cb_selectAllAgents.Visible = false;
            this.cb_selectAllAgents.CheckedChanged += new System.EventHandler(this.cb_selectAllAgents_CheckedChanged);
            // 
            // btn_StartDDT
            // 
            this.btn_StartDDT.Location = new System.Drawing.Point(235, 385);
            this.btn_StartDDT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StartDDT.Name = "btn_StartDDT";
            this.btn_StartDDT.Size = new System.Drawing.Size(218, 34);
            this.btn_StartDDT.TabIndex = 6;
            this.btn_StartDDT.Text = "Start Data Generation";
            this.btn_StartDDT.UseVisualStyleBackColor = true;
            this.btn_StartDDT.Visible = false;
            this.btn_StartDDT.Click += new System.EventHandler(this.btn_startDDT_Click);
            // 
            // tb_Size
            // 
            this.tb_Size.Location = new System.Drawing.Point(6, 33);
            this.tb_Size.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Size.Name = "tb_Size";
            this.tb_Size.Size = new System.Drawing.Size(119, 20);
            this.tb_Size.TabIndex = 7;
            this.tb_Size.Text = "10240";
            this.tb_Size.Visible = false;
            this.tb_Size.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Size_Validating);
            this.tb_Size.Validated += new System.EventHandler(this.tb_Size_Validated);
            // 
            // btn_StopDDT
            // 
            this.btn_StopDDT.Location = new System.Drawing.Point(457, 385);
            this.btn_StopDDT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StopDDT.Name = "btn_StopDDT";
            this.btn_StopDDT.Size = new System.Drawing.Size(202, 34);
            this.btn_StopDDT.TabIndex = 11;
            this.btn_StopDDT.Text = "Stop Data Generation";
            this.btn_StopDDT.UseVisualStyleBackColor = true;
            this.btn_StopDDT.Visible = false;
            this.btn_StopDDT.Click += new System.EventHandler(this.btn_StopDDT_Click);
            // 
            // lbl_Size
            // 
            this.lbl_Size.AutoSize = true;
            this.lbl_Size.Location = new System.Drawing.Point(6, 16);
            this.lbl_Size.Name = "lbl_Size";
            this.lbl_Size.Size = new System.Drawing.Size(52, 13);
            this.lbl_Size.TabIndex = 14;
            this.lbl_Size.Text = "Size (MB)";
            this.lbl_Size.Visible = false;
            // 
            // lbl_Compression
            // 
            this.lbl_Compression.AutoSize = true;
            this.lbl_Compression.Location = new System.Drawing.Point(6, 56);
            this.lbl_Compression.Name = "lbl_Compression";
            this.lbl_Compression.Size = new System.Drawing.Size(84, 13);
            this.lbl_Compression.TabIndex = 16;
            this.lbl_Compression.Text = "Compression (%)";
            this.lbl_Compression.Visible = false;
            // 
            // tb_Compression
            // 
            this.tb_Compression.Location = new System.Drawing.Point(6, 74);
            this.tb_Compression.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Compression.Name = "tb_Compression";
            this.tb_Compression.Size = new System.Drawing.Size(119, 20);
            this.tb_Compression.TabIndex = 15;
            this.tb_Compression.Text = "60";
            this.tb_Compression.Visible = false;
            this.tb_Compression.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Compression_Validating);
            this.tb_Compression.Validated += new System.EventHandler(this.tb_Compression_Validated);
            // 
            // lbl_Path
            // 
            this.lbl_Path.AutoSize = true;
            this.lbl_Path.Location = new System.Drawing.Point(6, 96);
            this.lbl_Path.Name = "lbl_Path";
            this.lbl_Path.Size = new System.Drawing.Size(69, 13);
            this.lbl_Path.TabIndex = 18;
            this.lbl_Path.Text = "Remote Path";
            this.lbl_Path.Visible = false;
            // 
            // tb_Path
            // 
            this.tb_Path.Location = new System.Drawing.Point(6, 114);
            this.tb_Path.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.Size = new System.Drawing.Size(119, 20);
            this.tb_Path.TabIndex = 17;
            this.tb_Path.Text = "E:\\Data\\";
            this.tb_Path.Visible = false;
            this.tb_Path.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Path_Validating);
            this.tb_Path.Validated += new System.EventHandler(this.tb_Path_Validated);
            // 
            // lbl_Interval
            // 
            this.lbl_Interval.AutoSize = true;
            this.lbl_Interval.Location = new System.Drawing.Point(6, 136);
            this.lbl_Interval.Name = "lbl_Interval";
            this.lbl_Interval.Size = new System.Drawing.Size(67, 13);
            this.lbl_Interval.TabIndex = 20;
            this.lbl_Interval.Text = "Interval (min)";
            this.lbl_Interval.Visible = false;
            // 
            // tb_Interval
            // 
            this.tb_Interval.Location = new System.Drawing.Point(6, 154);
            this.tb_Interval.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Interval.Name = "tb_Interval";
            this.tb_Interval.Size = new System.Drawing.Size(119, 20);
            this.tb_Interval.TabIndex = 19;
            this.tb_Interval.Text = "60";
            this.tb_Interval.Visible = false;
            this.tb_Interval.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Interval_Validating);
            this.tb_Interval.Validated += new System.EventHandler(this.tb_Interval_Validated);
            // 
            // lbl_hostname
            // 
            this.lbl_hostname.AutoSize = true;
            this.lbl_hostname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hostname.Location = new System.Drawing.Point(250, 268);
            this.lbl_hostname.Name = "lbl_hostname";
            this.lbl_hostname.Size = new System.Drawing.Size(72, 17);
            this.lbl_hostname.TabIndex = 22;
            this.lbl_hostname.Text = "Hostname";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.Location = new System.Drawing.Point(249, 291);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(73, 17);
            this.lbl_username.TabIndex = 23;
            this.lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.Location = new System.Drawing.Point(253, 313);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(69, 17);
            this.lbl_password.TabIndex = 24;
            this.lbl_password.Text = "Password";
            // 
            // cb_useCoreCreds
            // 
            this.cb_useCoreCreds.AutoSize = true;
            this.cb_useCoreCreds.Checked = true;
            this.cb_useCoreCreds.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_useCoreCreds.Location = new System.Drawing.Point(6, 186);
            this.cb_useCoreCreds.Name = "cb_useCoreCreds";
            this.cb_useCoreCreds.Size = new System.Drawing.Size(125, 17);
            this.cb_useCoreCreds.TabIndex = 25;
            this.cb_useCoreCreds.Text = "Use Core Credentials";
            this.cb_useCoreCreds.UseVisualStyleBackColor = true;
            this.cb_useCoreCreds.CheckedChanged += new System.EventHandler(this.cb_useCoreCreds_CheckedChanged);
            // 
            // lbl_customUsername
            // 
            this.lbl_customUsername.AutoSize = true;
            this.lbl_customUsername.Location = new System.Drawing.Point(6, 17);
            this.lbl_customUsername.Name = "lbl_customUsername";
            this.lbl_customUsername.Size = new System.Drawing.Size(55, 13);
            this.lbl_customUsername.TabIndex = 27;
            this.lbl_customUsername.Text = "Username";
            // 
            // tb_customUsername
            // 
            this.tb_customUsername.Enabled = false;
            this.tb_customUsername.Location = new System.Drawing.Point(6, 34);
            this.tb_customUsername.Name = "tb_customUsername";
            this.tb_customUsername.Size = new System.Drawing.Size(120, 20);
            this.tb_customUsername.TabIndex = 28;
            // 
            // tb_customPassword
            // 
            this.tb_customPassword.Enabled = false;
            this.tb_customPassword.Location = new System.Drawing.Point(6, 74);
            this.tb_customPassword.Name = "tb_customPassword";
            this.tb_customPassword.Size = new System.Drawing.Size(120, 20);
            this.tb_customPassword.TabIndex = 30;
            this.tb_customPassword.UseSystemPasswordChar = true;
            // 
            // lbl_customPassword
            // 
            this.lbl_customPassword.AutoSize = true;
            this.lbl_customPassword.Location = new System.Drawing.Point(6, 57);
            this.lbl_customPassword.Name = "lbl_customPassword";
            this.lbl_customPassword.Size = new System.Drawing.Size(53, 13);
            this.lbl_customPassword.TabIndex = 29;
            this.lbl_customPassword.Text = "Password";
            // 
            // tb_Port
            // 
            this.tb_Port.Location = new System.Drawing.Point(460, 267);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(41, 20);
            this.tb_Port.TabIndex = 31;
            this.tb_Port.Text = "8006";
            this.tb_Port.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Port_Validating);
            this.tb_Port.Validated += new System.EventHandler(this.tb_Port_Validated);
            // 
            // lbl_Port
            // 
            this.lbl_Port.AutoSize = true;
            this.lbl_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Port.Location = new System.Drawing.Point(508, 267);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(34, 17);
            this.lbl_Port.TabIndex = 32;
            this.lbl_Port.Text = "Port";
            // 
            // gb_customcreds
            // 
            this.gb_customcreds.Controls.Add(this.lbl_customUsername);
            this.gb_customcreds.Controls.Add(this.tb_customUsername);
            this.gb_customcreds.Controls.Add(this.lbl_customPassword);
            this.gb_customcreds.Controls.Add(this.tb_customPassword);
            this.gb_customcreds.Location = new System.Drawing.Point(663, 234);
            this.gb_customcreds.Name = "gb_customcreds";
            this.gb_customcreds.Size = new System.Drawing.Size(145, 100);
            this.gb_customcreds.TabIndex = 33;
            this.gb_customcreds.TabStop = false;
            this.gb_customcreds.Text = "Custom Credentials";
            // 
            // gb_ddtparams
            // 
            this.gb_ddtparams.Controls.Add(this.lbl_Size);
            this.gb_ddtparams.Controls.Add(this.tb_Size);
            this.gb_ddtparams.Controls.Add(this.lbl_Compression);
            this.gb_ddtparams.Controls.Add(this.tb_Compression);
            this.gb_ddtparams.Controls.Add(this.cb_useCoreCreds);
            this.gb_ddtparams.Controls.Add(this.tb_Path);
            this.gb_ddtparams.Controls.Add(this.lbl_Path);
            this.gb_ddtparams.Controls.Add(this.lbl_Interval);
            this.gb_ddtparams.Controls.Add(this.tb_Interval);
            this.gb_ddtparams.Location = new System.Drawing.Point(664, 11);
            this.gb_ddtparams.Name = "gb_ddtparams";
            this.gb_ddtparams.Size = new System.Drawing.Size(144, 217);
            this.gb_ddtparams.TabIndex = 34;
            this.gb_ddtparams.TabStop = false;
            this.gb_ddtparams.Text = "DDT Parameters";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbl_ChangeRateLabel
            // 
            this.lbl_ChangeRateLabel.AutoSize = true;
            this.lbl_ChangeRateLabel.Location = new System.Drawing.Point(670, 372);
            this.lbl_ChangeRateLabel.Name = "lbl_ChangeRateLabel";
            this.lbl_ChangeRateLabel.Size = new System.Drawing.Size(128, 13);
            this.lbl_ChangeRateLabel.TabIndex = 35;
            this.lbl_ChangeRateLabel.Text = "Total change rate GiB/hr:";
            // 
            // lbl_ChangeRateValue
            // 
            this.lbl_ChangeRateValue.AutoSize = true;
            this.lbl_ChangeRateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChangeRateValue.Location = new System.Drawing.Point(712, 390);
            this.lbl_ChangeRateValue.Name = "lbl_ChangeRateValue";
            this.lbl_ChangeRateValue.Size = new System.Drawing.Size(15, 15);
            this.lbl_ChangeRateValue.TabIndex = 36;
            this.lbl_ChangeRateValue.Text = "0";
            // 
            // lbl_totalAgentsRunningValue
            // 
            this.lbl_totalAgentsRunningValue.AutoSize = true;
            this.lbl_totalAgentsRunningValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalAgentsRunningValue.Location = new System.Drawing.Point(712, 357);
            this.lbl_totalAgentsRunningValue.Name = "lbl_totalAgentsRunningValue";
            this.lbl_totalAgentsRunningValue.Size = new System.Drawing.Size(15, 15);
            this.lbl_totalAgentsRunningValue.TabIndex = 38;
            this.lbl_totalAgentsRunningValue.Text = "0";
            // 
            // lbl_totalAgentsRunninglabel
            // 
            this.lbl_totalAgentsRunninglabel.AutoSize = true;
            this.lbl_totalAgentsRunninglabel.Location = new System.Drawing.Point(670, 344);
            this.lbl_totalAgentsRunninglabel.Name = "lbl_totalAgentsRunninglabel";
            this.lbl_totalAgentsRunninglabel.Size = new System.Drawing.Size(115, 13);
            this.lbl_totalAgentsRunninglabel.TabIndex = 37;
            this.lbl_totalAgentsRunninglabel.Text = "Generation running for:";
            // 
            // lbl_TotalAmountLabel
            // 
            this.lbl_TotalAmountLabel.AutoSize = true;
            this.lbl_TotalAmountLabel.Location = new System.Drawing.Point(13, 385);
            this.lbl_TotalAmountLabel.Name = "lbl_TotalAmountLabel";
            this.lbl_TotalAmountLabel.Size = new System.Drawing.Size(69, 13);
            this.lbl_TotalAmountLabel.TabIndex = 39;
            this.lbl_TotalAmountLabel.Text = "Total agents:";
            // 
            // lbl_TotalAmountValue
            // 
            this.lbl_TotalAmountValue.AutoSize = true;
            this.lbl_TotalAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalAmountValue.Location = new System.Drawing.Point(78, 385);
            this.lbl_TotalAmountValue.Name = "lbl_TotalAmountValue";
            this.lbl_TotalAmountValue.Size = new System.Drawing.Size(13, 13);
            this.lbl_TotalAmountValue.TabIndex = 40;
            this.lbl_TotalAmountValue.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 428);
            this.Controls.Add(this.lbl_TotalAmountValue);
            this.Controls.Add(this.lbl_TotalAmountLabel);
            this.Controls.Add(this.lbl_totalAgentsRunningValue);
            this.Controls.Add(this.lbl_totalAgentsRunninglabel);
            this.Controls.Add(this.lbl_ChangeRateValue);
            this.Controls.Add(this.lbl_ChangeRateLabel);
            this.Controls.Add(this.gb_ddtparams);
            this.Controls.Add(this.gb_customcreds);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.tb_Port);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.lbl_hostname);
            this.Controls.Add(this.btn_StopDDT);
            this.Controls.Add(this.cb_selectAllAgents);
            this.Controls.Add(this.btn_StartDDT);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_userName);
            this.Controls.Add(this.tb_hostname);
            this.Controls.Add(this.lv_AgentsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Generator 0.3";
            this.gb_customcreds.ResumeLayout(false);
            this.gb_customcreds.PerformLayout();
            this.gb_ddtparams.ResumeLayout(false);
            this.gb_ddtparams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_hostname;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.ListView lv_AgentsList;
        private System.Windows.Forms.CheckBox cb_selectAllAgents;
        private System.Windows.Forms.Button btn_StartDDT;
        private System.Windows.Forms.TextBox tb_Size;
        private System.Windows.Forms.Button btn_StopDDT;
        private System.Windows.Forms.Label lbl_Size;
        private System.Windows.Forms.Label lbl_Compression;
        private System.Windows.Forms.TextBox tb_Compression;
        private System.Windows.Forms.Label lbl_Path;
        private System.Windows.Forms.TextBox tb_Path;
        private System.Windows.Forms.Label lbl_Interval;
        private System.Windows.Forms.TextBox tb_Interval;
        private System.Windows.Forms.Label lbl_hostname;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.CheckBox cb_useCoreCreds;
        private System.Windows.Forms.Label lbl_customUsername;
        private System.Windows.Forms.TextBox tb_customUsername;
        private System.Windows.Forms.TextBox tb_customPassword;
        private System.Windows.Forms.Label lbl_customPassword;
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.GroupBox gb_customcreds;
        private System.Windows.Forms.GroupBox gb_ddtparams;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbl_ChangeRateValue;
        private System.Windows.Forms.Label lbl_ChangeRateLabel;
        private System.Windows.Forms.Label lbl_totalAgentsRunningValue;
        private System.Windows.Forms.Label lbl_totalAgentsRunninglabel;
        private System.Windows.Forms.Label lbl_TotalAmountValue;
        private System.Windows.Forms.Label lbl_TotalAmountLabel;
    }
}

