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
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.lbl_Port = new System.Windows.Forms.Label();
            this.gb_ddtparams = new System.Windows.Forms.GroupBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbl_ChangeRateLabel = new System.Windows.Forms.Label();
            this.lbl_ChangeRateValue = new System.Windows.Forms.Label();
            this.lbl_totalAgentsRunningValue = new System.Windows.Forms.Label();
            this.lbl_totalAgentsRunninglabel = new System.Windows.Forms.Label();
            this.lbl_TotalAmountLabel = new System.Windows.Forms.Label();
            this.lbl_TotalAmountValue = new System.Windows.Forms.Label();
            this.btn_About = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gb_ExchangeParameters = new System.Windows.Forms.GroupBox();
            this.cb_MailSize = new System.Windows.Forms.ComboBox();
            this.lbl_MessageSize = new System.Windows.Forms.Label();
            this.btn_stopExchangeGeneration = new System.Windows.Forms.Button();
            this.btn_startExchangeGeneration = new System.Windows.Forms.Button();
            this.cb_SelAllExchange = new System.Windows.Forms.CheckBox();
            this.lv_ExchangeServers = new System.Windows.Forms.ListView();
            this.lbl_SelectMode = new System.Windows.Forms.Label();
            this.rb_Core = new System.Windows.Forms.RadioButton();
            this.rb_Manually = new System.Windows.Forms.RadioButton();
            this.gb_ddtparams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gb_ExchangeParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_hostname
            // 
            this.tb_hostname.Location = new System.Drawing.Point(419, 299);
            this.tb_hostname.Margin = new System.Windows.Forms.Padding(2);
            this.tb_hostname.Name = "tb_hostname";
            this.tb_hostname.Size = new System.Drawing.Size(115, 20);
            this.tb_hostname.TabIndex = 0;
            this.tb_hostname.Validating += new System.ComponentModel.CancelEventHandler(this.tb_hostname_Validating);
            this.tb_hostname.Validated += new System.EventHandler(this.tb_hostname_Validated);
            // 
            // tb_userName
            // 
            this.tb_userName.Location = new System.Drawing.Point(419, 322);
            this.tb_userName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(174, 20);
            this.tb_userName.TabIndex = 1;
            this.tb_userName.Validating += new System.ComponentModel.CancelEventHandler(this.tb_userName_Validating);
            this.tb_userName.Validated += new System.EventHandler(this.tb_userName_Validated);
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(419, 345);
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
            this.btn_Connect.Location = new System.Drawing.Point(470, 368);
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
            this.lv_AgentsList.Location = new System.Drawing.Point(5, 5);
            this.lv_AgentsList.Margin = new System.Windows.Forms.Padding(2);
            this.lv_AgentsList.Name = "lv_AgentsList";
            this.lv_AgentsList.Size = new System.Drawing.Size(784, 379);
            this.lv_AgentsList.TabIndex = 0;
            this.lv_AgentsList.UseCompatibleStateImageBehavior = false;
            this.lv_AgentsList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_AgentsList_ColumnClick);
            // 
            // cb_selectAllAgents
            // 
            this.cb_selectAllAgents.AutoSize = true;
            this.cb_selectAllAgents.Location = new System.Drawing.Point(10, 10);
            this.cb_selectAllAgents.Margin = new System.Windows.Forms.Padding(2);
            this.cb_selectAllAgents.Name = "cb_selectAllAgents";
            this.cb_selectAllAgents.Size = new System.Drawing.Size(15, 14);
            this.cb_selectAllAgents.TabIndex = 3;
            this.cb_selectAllAgents.UseVisualStyleBackColor = true;
            this.cb_selectAllAgents.CheckedChanged += new System.EventHandler(this.cb_selectAllAgents_CheckedChanged);
            // 
            // btn_StartDDT
            // 
            this.btn_StartDDT.Location = new System.Drawing.Point(273, 399);
            this.btn_StartDDT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StartDDT.Name = "btn_StartDDT";
            this.btn_StartDDT.Size = new System.Drawing.Size(218, 34);
            this.btn_StartDDT.TabIndex = 6;
            this.btn_StartDDT.Text = "Start Data Generation";
            this.btn_StartDDT.UseVisualStyleBackColor = true;
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
            this.tb_Size.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Size_Validating);
            this.tb_Size.Validated += new System.EventHandler(this.tb_Size_Validated);
            // 
            // btn_StopDDT
            // 
            this.btn_StopDDT.Location = new System.Drawing.Point(495, 399);
            this.btn_StopDDT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StopDDT.Name = "btn_StopDDT";
            this.btn_StopDDT.Size = new System.Drawing.Size(202, 34);
            this.btn_StopDDT.TabIndex = 11;
            this.btn_StopDDT.Text = "Stop Data Generation";
            this.btn_StopDDT.UseVisualStyleBackColor = true;
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
            // 
            // lbl_Compression
            // 
            this.lbl_Compression.AutoSize = true;
            this.lbl_Compression.Location = new System.Drawing.Point(6, 56);
            this.lbl_Compression.Name = "lbl_Compression";
            this.lbl_Compression.Size = new System.Drawing.Size(84, 13);
            this.lbl_Compression.TabIndex = 16;
            this.lbl_Compression.Text = "Compression (%)";
            // 
            // tb_Compression
            // 
            this.tb_Compression.Location = new System.Drawing.Point(6, 74);
            this.tb_Compression.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Compression.Name = "tb_Compression";
            this.tb_Compression.Size = new System.Drawing.Size(119, 20);
            this.tb_Compression.TabIndex = 15;
            this.tb_Compression.Text = "60";
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
            // 
            // tb_Path
            // 
            this.tb_Path.Location = new System.Drawing.Point(6, 114);
            this.tb_Path.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Path.Name = "tb_Path";
            this.tb_Path.Size = new System.Drawing.Size(119, 20);
            this.tb_Path.TabIndex = 17;
            this.tb_Path.Text = "E:\\Data\\";
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
            // 
            // tb_Interval
            // 
            this.tb_Interval.Location = new System.Drawing.Point(6, 154);
            this.tb_Interval.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Interval.Name = "tb_Interval";
            this.tb_Interval.Size = new System.Drawing.Size(119, 20);
            this.tb_Interval.TabIndex = 19;
            this.tb_Interval.Text = "60";
            this.tb_Interval.Validating += new System.ComponentModel.CancelEventHandler(this.tb_Interval_Validating);
            this.tb_Interval.Validated += new System.EventHandler(this.tb_Interval_Validated);
            // 
            // lbl_hostname
            // 
            this.lbl_hostname.AutoSize = true;
            this.lbl_hostname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hostname.Location = new System.Drawing.Point(342, 300);
            this.lbl_hostname.Name = "lbl_hostname";
            this.lbl_hostname.Size = new System.Drawing.Size(72, 17);
            this.lbl_hostname.TabIndex = 22;
            this.lbl_hostname.Text = "Hostname";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_username.Location = new System.Drawing.Point(341, 323);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(73, 17);
            this.lbl_username.TabIndex = 23;
            this.lbl_username.Text = "Username";
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_password.Location = new System.Drawing.Point(345, 345);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(69, 17);
            this.lbl_password.TabIndex = 24;
            this.lbl_password.Text = "Password";
            // 
            // tb_Port
            // 
            this.tb_Port.Location = new System.Drawing.Point(552, 299);
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
            this.lbl_Port.Location = new System.Drawing.Point(600, 299);
            this.lbl_Port.Name = "lbl_Port";
            this.lbl_Port.Size = new System.Drawing.Size(34, 17);
            this.lbl_Port.TabIndex = 32;
            this.lbl_Port.Text = "Port";
            // 
            // gb_ddtparams
            // 
            this.gb_ddtparams.Controls.Add(this.lbl_Size);
            this.gb_ddtparams.Controls.Add(this.tb_Size);
            this.gb_ddtparams.Controls.Add(this.lbl_Compression);
            this.gb_ddtparams.Controls.Add(this.tb_Compression);
            this.gb_ddtparams.Controls.Add(this.tb_Path);
            this.gb_ddtparams.Controls.Add(this.lbl_Path);
            this.gb_ddtparams.Controls.Add(this.lbl_Interval);
            this.gb_ddtparams.Controls.Add(this.tb_Interval);
            this.gb_ddtparams.Location = new System.Drawing.Point(794, 12);
            this.gb_ddtparams.Name = "gb_ddtparams";
            this.gb_ddtparams.Size = new System.Drawing.Size(144, 192);
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
            this.lbl_ChangeRateLabel.Location = new System.Drawing.Point(800, 257);
            this.lbl_ChangeRateLabel.Name = "lbl_ChangeRateLabel";
            this.lbl_ChangeRateLabel.Size = new System.Drawing.Size(128, 13);
            this.lbl_ChangeRateLabel.TabIndex = 35;
            this.lbl_ChangeRateLabel.Text = "Total change rate GiB/hr:";
            // 
            // lbl_ChangeRateValue
            // 
            this.lbl_ChangeRateValue.AutoSize = true;
            this.lbl_ChangeRateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChangeRateValue.Location = new System.Drawing.Point(842, 275);
            this.lbl_ChangeRateValue.Name = "lbl_ChangeRateValue";
            this.lbl_ChangeRateValue.Size = new System.Drawing.Size(15, 15);
            this.lbl_ChangeRateValue.TabIndex = 36;
            this.lbl_ChangeRateValue.Text = "0";
            // 
            // lbl_totalAgentsRunningValue
            // 
            this.lbl_totalAgentsRunningValue.AutoSize = true;
            this.lbl_totalAgentsRunningValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalAgentsRunningValue.Location = new System.Drawing.Point(842, 242);
            this.lbl_totalAgentsRunningValue.Name = "lbl_totalAgentsRunningValue";
            this.lbl_totalAgentsRunningValue.Size = new System.Drawing.Size(15, 15);
            this.lbl_totalAgentsRunningValue.TabIndex = 38;
            this.lbl_totalAgentsRunningValue.Text = "0";
            // 
            // lbl_totalAgentsRunninglabel
            // 
            this.lbl_totalAgentsRunninglabel.AutoSize = true;
            this.lbl_totalAgentsRunninglabel.Location = new System.Drawing.Point(800, 229);
            this.lbl_totalAgentsRunninglabel.Name = "lbl_totalAgentsRunninglabel";
            this.lbl_totalAgentsRunninglabel.Size = new System.Drawing.Size(115, 13);
            this.lbl_totalAgentsRunninglabel.TabIndex = 37;
            this.lbl_totalAgentsRunninglabel.Text = "Generation running for:";
            // 
            // lbl_TotalAmountLabel
            // 
            this.lbl_TotalAmountLabel.AutoSize = true;
            this.lbl_TotalAmountLabel.Location = new System.Drawing.Point(6, 399);
            this.lbl_TotalAmountLabel.Name = "lbl_TotalAmountLabel";
            this.lbl_TotalAmountLabel.Size = new System.Drawing.Size(69, 13);
            this.lbl_TotalAmountLabel.TabIndex = 39;
            this.lbl_TotalAmountLabel.Text = "Total agents:";
            // 
            // lbl_TotalAmountValue
            // 
            this.lbl_TotalAmountValue.AutoSize = true;
            this.lbl_TotalAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalAmountValue.Location = new System.Drawing.Point(81, 399);
            this.lbl_TotalAmountValue.Name = "lbl_TotalAmountValue";
            this.lbl_TotalAmountValue.Size = new System.Drawing.Size(13, 13);
            this.lbl_TotalAmountValue.TabIndex = 40;
            this.lbl_TotalAmountValue.Text = "0";
            // 
            // btn_About
            // 
            this.btn_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_About.Location = new System.Drawing.Point(903, 5);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(54, 23);
            this.btn_About.TabIndex = 41;
            this.btn_About.Text = "About";
            this.btn_About.UseVisualStyleBackColor = true;
            this.btn_About.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(952, 491);
            this.tabControl.TabIndex = 42;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cb_selectAllAgents);
            this.tabPage1.Controls.Add(this.lv_AgentsList);
            this.tabPage1.Controls.Add(this.gb_ddtparams);
            this.tabPage1.Controls.Add(this.lbl_totalAgentsRunningValue);
            this.tabPage1.Controls.Add(this.lbl_TotalAmountValue);
            this.tabPage1.Controls.Add(this.lbl_totalAgentsRunninglabel);
            this.tabPage1.Controls.Add(this.lbl_ChangeRateValue);
            this.tabPage1.Controls.Add(this.lbl_TotalAmountLabel);
            this.tabPage1.Controls.Add(this.lbl_ChangeRateLabel);
            this.tabPage1.Controls.Add(this.btn_StartDDT);
            this.tabPage1.Controls.Add(this.btn_StopDDT);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(944, 465);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "DDT";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gb_ExchangeParameters);
            this.tabPage2.Controls.Add(this.btn_stopExchangeGeneration);
            this.tabPage2.Controls.Add(this.btn_startExchangeGeneration);
            this.tabPage2.Controls.Add(this.cb_SelAllExchange);
            this.tabPage2.Controls.Add(this.lv_ExchangeServers);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(944, 465);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Exchange";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gb_ExchangeParameters
            // 
            this.gb_ExchangeParameters.Controls.Add(this.cb_MailSize);
            this.gb_ExchangeParameters.Controls.Add(this.lbl_MessageSize);
            this.gb_ExchangeParameters.Location = new System.Drawing.Point(794, 10);
            this.gb_ExchangeParameters.Name = "gb_ExchangeParameters";
            this.gb_ExchangeParameters.Size = new System.Drawing.Size(144, 192);
            this.gb_ExchangeParameters.TabIndex = 35;
            this.gb_ExchangeParameters.TabStop = false;
            this.gb_ExchangeParameters.Text = "Parameters";
            // 
            // cb_MailSize
            // 
            this.cb_MailSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_MailSize.FormattingEnabled = true;
            this.cb_MailSize.Location = new System.Drawing.Point(9, 33);
            this.cb_MailSize.Name = "cb_MailSize";
            this.cb_MailSize.Size = new System.Drawing.Size(121, 21);
            this.cb_MailSize.TabIndex = 15;
            // 
            // lbl_MessageSize
            // 
            this.lbl_MessageSize.AutoSize = true;
            this.lbl_MessageSize.Location = new System.Drawing.Point(6, 16);
            this.lbl_MessageSize.Name = "lbl_MessageSize";
            this.lbl_MessageSize.Size = new System.Drawing.Size(47, 13);
            this.lbl_MessageSize.TabIndex = 14;
            this.lbl_MessageSize.Text = "Mail size";
            // 
            // btn_stopExchangeGeneration
            // 
            this.btn_stopExchangeGeneration.Location = new System.Drawing.Point(429, 388);
            this.btn_stopExchangeGeneration.Margin = new System.Windows.Forms.Padding(2);
            this.btn_stopExchangeGeneration.Name = "btn_stopExchangeGeneration";
            this.btn_stopExchangeGeneration.Size = new System.Drawing.Size(202, 34);
            this.btn_stopExchangeGeneration.TabIndex = 12;
            this.btn_stopExchangeGeneration.Text = "Stop Exchange Generation";
            this.btn_stopExchangeGeneration.UseVisualStyleBackColor = true;
            this.btn_stopExchangeGeneration.Click += new System.EventHandler(this.btn_stopExchangeGeneration_Click);
            // 
            // btn_startExchangeGeneration
            // 
            this.btn_startExchangeGeneration.Location = new System.Drawing.Point(207, 388);
            this.btn_startExchangeGeneration.Margin = new System.Windows.Forms.Padding(2);
            this.btn_startExchangeGeneration.Name = "btn_startExchangeGeneration";
            this.btn_startExchangeGeneration.Size = new System.Drawing.Size(218, 34);
            this.btn_startExchangeGeneration.TabIndex = 7;
            this.btn_startExchangeGeneration.Text = "Start Exchange Generation";
            this.btn_startExchangeGeneration.UseVisualStyleBackColor = true;
            this.btn_startExchangeGeneration.Click += new System.EventHandler(this.btn_startExchangeGeneration_Click);
            // 
            // cb_SelAllExchange
            // 
            this.cb_SelAllExchange.AutoSize = true;
            this.cb_SelAllExchange.Location = new System.Drawing.Point(10, 10);
            this.cb_SelAllExchange.Margin = new System.Windows.Forms.Padding(2);
            this.cb_SelAllExchange.Name = "cb_SelAllExchange";
            this.cb_SelAllExchange.Size = new System.Drawing.Size(15, 14);
            this.cb_SelAllExchange.TabIndex = 5;
            this.cb_SelAllExchange.UseVisualStyleBackColor = true;
            this.cb_SelAllExchange.CheckedChanged += new System.EventHandler(this.cb_SelAllExchange_CheckedChanged);
            // 
            // lv_ExchangeServers
            // 
            this.lv_ExchangeServers.Location = new System.Drawing.Point(5, 5);
            this.lv_ExchangeServers.Margin = new System.Windows.Forms.Padding(2);
            this.lv_ExchangeServers.Name = "lv_ExchangeServers";
            this.lv_ExchangeServers.Size = new System.Drawing.Size(784, 379);
            this.lv_ExchangeServers.TabIndex = 4;
            this.lv_ExchangeServers.UseCompatibleStateImageBehavior = false;
            this.lv_ExchangeServers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_ExchangeServers_ColumnClick);
            // 
            // lbl_SelectMode
            // 
            this.lbl_SelectMode.AutoSize = true;
            this.lbl_SelectMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectMode.Location = new System.Drawing.Point(368, 210);
            this.lbl_SelectMode.Name = "lbl_SelectMode";
            this.lbl_SelectMode.Size = new System.Drawing.Size(225, 18);
            this.lbl_SelectMode.TabIndex = 45;
            this.lbl_SelectMode.Text = "Please select servers list source:";
            // 
            // rb_Core
            // 
            this.rb_Core.AutoSize = true;
            this.rb_Core.Checked = true;
            this.rb_Core.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Core.Location = new System.Drawing.Point(338, 266);
            this.rb_Core.Name = "rb_Core";
            this.rb_Core.Size = new System.Drawing.Size(265, 20);
            this.rb_Core.TabIndex = 44;
            this.rb_Core.TabStop = true;
            this.rb_Core.Text = "Add servers automatically from RR Core";
            this.rb_Core.UseVisualStyleBackColor = true;
            this.rb_Core.CheckedChanged += new System.EventHandler(this.rb_Core_CheckedChanged);
            // 
            // rb_Manually
            // 
            this.rb_Manually.AutoSize = true;
            this.rb_Manually.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rb_Manually.Location = new System.Drawing.Point(338, 243);
            this.rb_Manually.Name = "rb_Manually";
            this.rb_Manually.Size = new System.Drawing.Size(156, 20);
            this.rb_Manually.TabIndex = 43;
            this.rb_Manually.Text = "Add servers manually";
            this.rb_Manually.UseVisualStyleBackColor = true;
            this.rb_Manually.CheckedChanged += new System.EventHandler(this.rb_Manually_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 519);
            this.Controls.Add(this.lbl_SelectMode);
            this.Controls.Add(this.rb_Core);
            this.Controls.Add(this.btn_About);
            this.Controls.Add(this.lbl_Port);
            this.Controls.Add(this.rb_Manually);
            this.Controls.Add(this.tb_Port);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.lbl_hostname);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_userName);
            this.Controls.Add(this.tb_hostname);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RR Data Generator";
            this.gb_ddtparams.ResumeLayout(false);
            this.gb_ddtparams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.gb_ExchangeParameters.ResumeLayout(false);
            this.gb_ExchangeParameters.PerformLayout();
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
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.Label lbl_Port;
        private System.Windows.Forms.GroupBox gb_ddtparams;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label lbl_ChangeRateValue;
        private System.Windows.Forms.Label lbl_ChangeRateLabel;
        private System.Windows.Forms.Label lbl_totalAgentsRunningValue;
        private System.Windows.Forms.Label lbl_totalAgentsRunninglabel;
        private System.Windows.Forms.Label lbl_TotalAmountValue;
        private System.Windows.Forms.Label lbl_TotalAmountLabel;
        private System.Windows.Forms.Button btn_About;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cb_SelAllExchange;
        private System.Windows.Forms.ListView lv_ExchangeServers;
        private System.Windows.Forms.Button btn_startExchangeGeneration;
        private System.Windows.Forms.Button btn_stopExchangeGeneration;
        private System.Windows.Forms.GroupBox gb_ExchangeParameters;
        private System.Windows.Forms.Label lbl_MessageSize;
        private System.Windows.Forms.ComboBox cb_MailSize;
        private System.Windows.Forms.Label lbl_SelectMode;
        private System.Windows.Forms.RadioButton rb_Core;
        private System.Windows.Forms.RadioButton rb_Manually;
    }
}

