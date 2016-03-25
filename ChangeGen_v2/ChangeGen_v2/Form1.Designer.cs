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
            this.tab_Data = new System.Windows.Forms.TabPage();
            this.btn_deleteSelectedServers = new System.Windows.Forms.Button();
            this.gb_customCredentials = new System.Windows.Forms.GroupBox();
            this.lbl_customPassword = new System.Windows.Forms.Label();
            this.lbl_customUserName = new System.Windows.Forms.Label();
            this.tb_customPassword = new System.Windows.Forms.TextBox();
            this.tb_customUsername = new System.Windows.Forms.TextBox();
            this.cb_UseCustomCredentials = new System.Windows.Forms.CheckBox();
            this.btn_ExportCSV = new System.Windows.Forms.Button();
            this.btn_ImportCSV = new System.Windows.Forms.Button();
            this.btn_addServerManually = new System.Windows.Forms.Button();
            this.tab_Exchange = new System.Windows.Forms.TabPage();
            this.btn_deleteExchangeServer = new System.Windows.Forms.Button();
            this.gb_ExchangeCustomCreds = new System.Windows.Forms.GroupBox();
            this.lbl_exchangeCustomDomain = new System.Windows.Forms.Label();
            this.tb_exchangeCustomDomain = new System.Windows.Forms.TextBox();
            this.lbl_exchangeCustomPassword = new System.Windows.Forms.Label();
            this.lbl_exchangeCustomUsername = new System.Windows.Forms.Label();
            this.tb_exchangeCustomPassword = new System.Windows.Forms.TextBox();
            this.tb_exchangeCustomUsername = new System.Windows.Forms.TextBox();
            this.cb_ExchangeUseCustomCreds = new System.Windows.Forms.CheckBox();
            this.btn_ExchangeExportCSV = new System.Windows.Forms.Button();
            this.btn_ExchangeImportCSV = new System.Windows.Forms.Button();
            this.btn_AddExchangeServerManually = new System.Windows.Forms.Button();
            this.lbl_exchangeGenerationRunningValue = new System.Windows.Forms.Label();
            this.lbl_exchangeTotalAgentsValue = new System.Windows.Forms.Label();
            this.lbl_exchangeGenerationRunningLabel = new System.Windows.Forms.Label();
            this.lbl_exchangeTotalAgentsLabel = new System.Windows.Forms.Label();
            this.gb_ExchangeParameters = new System.Windows.Forms.GroupBox();
            this.lbl_MailSizeNote = new System.Windows.Forms.Label();
            this.cb_MailSize = new System.Windows.Forms.ComboBox();
            this.lbl_MessageSize = new System.Windows.Forms.Label();
            this.btn_stopExchangeGeneration = new System.Windows.Forms.Button();
            this.btn_startExchangeGeneration = new System.Windows.Forms.Button();
            this.cb_SelAllExchange = new System.Windows.Forms.CheckBox();
            this.lv_ExchangeServers = new System.Windows.Forms.ListView();
            this.tabSQL = new System.Windows.Forms.TabPage();
            this.btn_RemoveSQLManually = new System.Windows.Forms.Button();
            this.gb_SQLCustomCreds = new System.Windows.Forms.GroupBox();
            this.lbl_SQLCustomPassword = new System.Windows.Forms.Label();
            this.lbl_SQLCustomUsername = new System.Windows.Forms.Label();
            this.tb_SQLCustomPassword = new System.Windows.Forms.TextBox();
            this.tb_SQLCustomUsername = new System.Windows.Forms.TextBox();
            this.cb_UseCustomCredsSQL = new System.Windows.Forms.CheckBox();
            this.btn_ExportCSVSQL = new System.Windows.Forms.Button();
            this.btn_ImportCSVSQL = new System.Windows.Forms.Button();
            this.btn_AddSQLManually = new System.Windows.Forms.Button();
            this.lbl_SQLGenerationRunningvalue = new System.Windows.Forms.Label();
            this.lbl_TotalSQLServersValue = new System.Windows.Forms.Label();
            this.lbl_SQLGenerationRunninglbl = new System.Windows.Forms.Label();
            this.lbl_TotalSQLServerslbl = new System.Windows.Forms.Label();
            this.gb_SQLParams = new System.Windows.Forms.GroupBox();
            this.tb_dbName = new System.Windows.Forms.TextBox();
            this.lbl_dbName = new System.Windows.Forms.Label();
            this.tb_SQLAmountRows = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_AddRows = new System.Windows.Forms.Label();
            this.btn_StopSQLGeneration = new System.Windows.Forms.Button();
            this.btn_StartSQLGeneration = new System.Windows.Forms.Button();
            this.cb_SelectAllSQL = new System.Windows.Forms.CheckBox();
            this.lv_SQL = new System.Windows.Forms.ListView();
            this.lbl_SelectMode = new System.Windows.Forms.Label();
            this.rb_Core = new System.Windows.Forms.RadioButton();
            this.rb_Manually = new System.Windows.Forms.RadioButton();
            this.lbl_Loading = new System.Windows.Forms.Label();
            this.cb_fillingGeneration = new System.Windows.Forms.CheckBox();
            this.lbl_fillingGenerationDescription = new System.Windows.Forms.Label();
            this.gb_ddtparams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tab_Data.SuspendLayout();
            this.gb_customCredentials.SuspendLayout();
            this.tab_Exchange.SuspendLayout();
            this.gb_ExchangeCustomCreds.SuspendLayout();
            this.gb_ExchangeParameters.SuspendLayout();
            this.tabSQL.SuspendLayout();
            this.gb_SQLCustomCreds.SuspendLayout();
            this.gb_SQLParams.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_hostname
            // 
            this.tb_hostname.Location = new System.Drawing.Point(419, 299);
            this.tb_hostname.Margin = new System.Windows.Forms.Padding(2);
            this.tb_hostname.Name = "tb_hostname";
            this.tb_hostname.Size = new System.Drawing.Size(115, 20);
            this.tb_hostname.TabIndex = 0;
            this.tb_hostname.TextChanged += new System.EventHandler(this.tb_hostname_TextChanged);
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
            this.tb_userName.TextChanged += new System.EventHandler(this.tb_userName_TextChanged);
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
            this.tb_password.TextChanged += new System.EventHandler(this.tb_password_TextChanged);
            this.tb_password.Validating += new System.ComponentModel.CancelEventHandler(this.tb_password_Validating);
            this.tb_password.Validated += new System.EventHandler(this.tb_password_Validated);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Enabled = false;
            this.btn_Connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Connect.Location = new System.Drawing.Point(470, 368);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 29);
            this.btn_Connect.TabIndex = 3;
            this.btn_Connect.Text = "Next";
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
            this.btn_StartDDT.Location = new System.Drawing.Point(369, 389);
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
            this.btn_StopDDT.Location = new System.Drawing.Point(591, 389);
            this.btn_StopDDT.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StopDDT.Name = "btn_StopDDT";
            this.btn_StopDDT.Size = new System.Drawing.Size(198, 34);
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
            this.gb_ddtparams.Controls.Add(this.lbl_fillingGenerationDescription);
            this.gb_ddtparams.Controls.Add(this.cb_fillingGeneration);
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
            this.gb_ddtparams.Size = new System.Drawing.Size(144, 223);
            this.gb_ddtparams.TabIndex = 34;
            this.gb_ddtparams.TabStop = false;
            this.gb_ddtparams.Text = "Parameters";
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
            this.lbl_ChangeRateLabel.Location = new System.Drawing.Point(804, 419);
            this.lbl_ChangeRateLabel.Name = "lbl_ChangeRateLabel";
            this.lbl_ChangeRateLabel.Size = new System.Drawing.Size(128, 13);
            this.lbl_ChangeRateLabel.TabIndex = 35;
            this.lbl_ChangeRateLabel.Text = "Total change rate GiB/hr:";
            // 
            // lbl_ChangeRateValue
            // 
            this.lbl_ChangeRateValue.AutoSize = true;
            this.lbl_ChangeRateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ChangeRateValue.Location = new System.Drawing.Point(846, 435);
            this.lbl_ChangeRateValue.Name = "lbl_ChangeRateValue";
            this.lbl_ChangeRateValue.Size = new System.Drawing.Size(15, 15);
            this.lbl_ChangeRateValue.TabIndex = 36;
            this.lbl_ChangeRateValue.Text = "0";
            // 
            // lbl_totalAgentsRunningValue
            // 
            this.lbl_totalAgentsRunningValue.AutoSize = true;
            this.lbl_totalAgentsRunningValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totalAgentsRunningValue.Location = new System.Drawing.Point(846, 395);
            this.lbl_totalAgentsRunningValue.Name = "lbl_totalAgentsRunningValue";
            this.lbl_totalAgentsRunningValue.Size = new System.Drawing.Size(15, 15);
            this.lbl_totalAgentsRunningValue.TabIndex = 38;
            this.lbl_totalAgentsRunningValue.Text = "0";
            // 
            // lbl_totalAgentsRunninglabel
            // 
            this.lbl_totalAgentsRunninglabel.AutoSize = true;
            this.lbl_totalAgentsRunninglabel.Location = new System.Drawing.Point(804, 382);
            this.lbl_totalAgentsRunninglabel.Name = "lbl_totalAgentsRunninglabel";
            this.lbl_totalAgentsRunninglabel.Size = new System.Drawing.Size(115, 13);
            this.lbl_totalAgentsRunninglabel.TabIndex = 37;
            this.lbl_totalAgentsRunninglabel.Text = "Generation running for:";
            // 
            // lbl_TotalAmountLabel
            // 
            this.lbl_TotalAmountLabel.AutoSize = true;
            this.lbl_TotalAmountLabel.Location = new System.Drawing.Point(7, 423);
            this.lbl_TotalAmountLabel.Name = "lbl_TotalAmountLabel";
            this.lbl_TotalAmountLabel.Size = new System.Drawing.Size(71, 13);
            this.lbl_TotalAmountLabel.TabIndex = 39;
            this.lbl_TotalAmountLabel.Text = "Total servers:";
            // 
            // lbl_TotalAmountValue
            // 
            this.lbl_TotalAmountValue.AutoSize = true;
            this.lbl_TotalAmountValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalAmountValue.Location = new System.Drawing.Point(82, 423);
            this.lbl_TotalAmountValue.Name = "lbl_TotalAmountValue";
            this.lbl_TotalAmountValue.Size = new System.Drawing.Size(13, 13);
            this.lbl_TotalAmountValue.TabIndex = 40;
            this.lbl_TotalAmountValue.Text = "0";
            // 
            // btn_About
            // 
            this.btn_About.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_About.Location = new System.Drawing.Point(903, 1);
            this.btn_About.Name = "btn_About";
            this.btn_About.Size = new System.Drawing.Size(54, 23);
            this.btn_About.TabIndex = 41;
            this.btn_About.Text = "About";
            this.btn_About.UseVisualStyleBackColor = true;
            this.btn_About.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_Data);
            this.tabControl.Controls.Add(this.tab_Exchange);
            this.tabControl.Controls.Add(this.tabSQL);
            this.tabControl.Location = new System.Drawing.Point(5, 6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(952, 491);
            this.tabControl.TabIndex = 42;
            // 
            // tab_Data
            // 
            this.tab_Data.Controls.Add(this.btn_deleteSelectedServers);
            this.tab_Data.Controls.Add(this.gb_customCredentials);
            this.tab_Data.Controls.Add(this.cb_UseCustomCredentials);
            this.tab_Data.Controls.Add(this.btn_ExportCSV);
            this.tab_Data.Controls.Add(this.btn_ImportCSV);
            this.tab_Data.Controls.Add(this.btn_addServerManually);
            this.tab_Data.Controls.Add(this.cb_selectAllAgents);
            this.tab_Data.Controls.Add(this.lv_AgentsList);
            this.tab_Data.Controls.Add(this.gb_ddtparams);
            this.tab_Data.Controls.Add(this.lbl_totalAgentsRunningValue);
            this.tab_Data.Controls.Add(this.lbl_TotalAmountValue);
            this.tab_Data.Controls.Add(this.lbl_totalAgentsRunninglabel);
            this.tab_Data.Controls.Add(this.lbl_ChangeRateValue);
            this.tab_Data.Controls.Add(this.lbl_TotalAmountLabel);
            this.tab_Data.Controls.Add(this.lbl_ChangeRateLabel);
            this.tab_Data.Controls.Add(this.btn_StartDDT);
            this.tab_Data.Controls.Add(this.btn_StopDDT);
            this.tab_Data.Location = new System.Drawing.Point(4, 22);
            this.tab_Data.Name = "tab_Data";
            this.tab_Data.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Data.Size = new System.Drawing.Size(944, 465);
            this.tab_Data.TabIndex = 0;
            this.tab_Data.Text = "Data";
            this.tab_Data.UseVisualStyleBackColor = true;
            // 
            // btn_deleteSelectedServers
            // 
            this.btn_deleteSelectedServers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteSelectedServers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_deleteSelectedServers.Location = new System.Drawing.Point(34, 389);
            this.btn_deleteSelectedServers.Name = "btn_deleteSelectedServers";
            this.btn_deleteSelectedServers.Size = new System.Drawing.Size(30, 27);
            this.btn_deleteSelectedServers.TabIndex = 46;
            this.btn_deleteSelectedServers.Text = "-";
            this.btn_deleteSelectedServers.UseVisualStyleBackColor = true;
            this.btn_deleteSelectedServers.Click += new System.EventHandler(this.btn_deleteSelectedServers_Click);
            // 
            // gb_customCredentials
            // 
            this.gb_customCredentials.Controls.Add(this.lbl_customPassword);
            this.gb_customCredentials.Controls.Add(this.lbl_customUserName);
            this.gb_customCredentials.Controls.Add(this.tb_customPassword);
            this.gb_customCredentials.Controls.Add(this.tb_customUsername);
            this.gb_customCredentials.Location = new System.Drawing.Point(794, 264);
            this.gb_customCredentials.Name = "gb_customCredentials";
            this.gb_customCredentials.Size = new System.Drawing.Size(147, 100);
            this.gb_customCredentials.TabIndex = 45;
            this.gb_customCredentials.TabStop = false;
            // 
            // lbl_customPassword
            // 
            this.lbl_customPassword.AutoSize = true;
            this.lbl_customPassword.Enabled = false;
            this.lbl_customPassword.Location = new System.Drawing.Point(6, 53);
            this.lbl_customPassword.Name = "lbl_customPassword";
            this.lbl_customPassword.Size = new System.Drawing.Size(53, 13);
            this.lbl_customPassword.TabIndex = 3;
            this.lbl_customPassword.Text = "Password";
            // 
            // lbl_customUserName
            // 
            this.lbl_customUserName.AutoSize = true;
            this.lbl_customUserName.Enabled = false;
            this.lbl_customUserName.Location = new System.Drawing.Point(6, 14);
            this.lbl_customUserName.Name = "lbl_customUserName";
            this.lbl_customUserName.Size = new System.Drawing.Size(55, 13);
            this.lbl_customUserName.TabIndex = 2;
            this.lbl_customUserName.Text = "Username";
            // 
            // tb_customPassword
            // 
            this.tb_customPassword.Enabled = false;
            this.tb_customPassword.Location = new System.Drawing.Point(6, 69);
            this.tb_customPassword.Name = "tb_customPassword";
            this.tb_customPassword.Size = new System.Drawing.Size(119, 20);
            this.tb_customPassword.TabIndex = 1;
            this.tb_customPassword.UseSystemPasswordChar = true;
            this.tb_customPassword.TextChanged += new System.EventHandler(this.tb_customPassword_TextChanged);
            this.tb_customPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tb_customPassword_Validating);
            this.tb_customPassword.Validated += new System.EventHandler(this.tb_customPassword_Validated);
            // 
            // tb_customUsername
            // 
            this.tb_customUsername.Enabled = false;
            this.tb_customUsername.Location = new System.Drawing.Point(6, 30);
            this.tb_customUsername.Name = "tb_customUsername";
            this.tb_customUsername.Size = new System.Drawing.Size(119, 20);
            this.tb_customUsername.TabIndex = 0;
            this.tb_customUsername.TextChanged += new System.EventHandler(this.tb_customUsername_TextChanged);
            this.tb_customUsername.Validating += new System.ComponentModel.CancelEventHandler(this.tb_customUsername_Validating);
            this.tb_customUsername.Validated += new System.EventHandler(this.tb_customUsername_Validated);
            // 
            // cb_UseCustomCredentials
            // 
            this.cb_UseCustomCredentials.AutoSize = true;
            this.cb_UseCustomCredentials.Location = new System.Drawing.Point(794, 241);
            this.cb_UseCustomCredentials.Name = "cb_UseCustomCredentials";
            this.cb_UseCustomCredentials.Size = new System.Drawing.Size(138, 17);
            this.cb_UseCustomCredentials.TabIndex = 44;
            this.cb_UseCustomCredentials.Text = "Use Custom Credentials";
            this.cb_UseCustomCredentials.UseVisualStyleBackColor = true;
            this.cb_UseCustomCredentials.CheckedChanged += new System.EventHandler(this.cb_UseCustomCredentials_CheckedChanged);
            // 
            // btn_ExportCSV
            // 
            this.btn_ExportCSV.Location = new System.Drawing.Point(154, 389);
            this.btn_ExportCSV.Name = "btn_ExportCSV";
            this.btn_ExportCSV.Size = new System.Drawing.Size(86, 27);
            this.btn_ExportCSV.TabIndex = 43;
            this.btn_ExportCSV.Text = "Export CSV";
            this.btn_ExportCSV.UseVisualStyleBackColor = true;
            this.btn_ExportCSV.Click += new System.EventHandler(this.btn_ExportCSV_Click);
            // 
            // btn_ImportCSV
            // 
            this.btn_ImportCSV.Location = new System.Drawing.Point(63, 389);
            this.btn_ImportCSV.Name = "btn_ImportCSV";
            this.btn_ImportCSV.Size = new System.Drawing.Size(90, 27);
            this.btn_ImportCSV.TabIndex = 42;
            this.btn_ImportCSV.Text = "Import CSV";
            this.btn_ImportCSV.UseVisualStyleBackColor = true;
            this.btn_ImportCSV.Click += new System.EventHandler(this.btn_ImportCSV_Click);
            // 
            // btn_addServerManually
            // 
            this.btn_addServerManually.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_addServerManually.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_addServerManually.Location = new System.Drawing.Point(5, 389);
            this.btn_addServerManually.Name = "btn_addServerManually";
            this.btn_addServerManually.Size = new System.Drawing.Size(30, 27);
            this.btn_addServerManually.TabIndex = 41;
            this.btn_addServerManually.Text = "+";
            this.btn_addServerManually.UseVisualStyleBackColor = true;
            this.btn_addServerManually.Click += new System.EventHandler(this.btn_addServerManually_Click);
            // 
            // tab_Exchange
            // 
            this.tab_Exchange.Controls.Add(this.btn_deleteExchangeServer);
            this.tab_Exchange.Controls.Add(this.gb_ExchangeCustomCreds);
            this.tab_Exchange.Controls.Add(this.cb_ExchangeUseCustomCreds);
            this.tab_Exchange.Controls.Add(this.btn_ExchangeExportCSV);
            this.tab_Exchange.Controls.Add(this.btn_ExchangeImportCSV);
            this.tab_Exchange.Controls.Add(this.btn_AddExchangeServerManually);
            this.tab_Exchange.Controls.Add(this.lbl_exchangeGenerationRunningValue);
            this.tab_Exchange.Controls.Add(this.lbl_exchangeTotalAgentsValue);
            this.tab_Exchange.Controls.Add(this.lbl_exchangeGenerationRunningLabel);
            this.tab_Exchange.Controls.Add(this.lbl_exchangeTotalAgentsLabel);
            this.tab_Exchange.Controls.Add(this.gb_ExchangeParameters);
            this.tab_Exchange.Controls.Add(this.btn_stopExchangeGeneration);
            this.tab_Exchange.Controls.Add(this.btn_startExchangeGeneration);
            this.tab_Exchange.Controls.Add(this.cb_SelAllExchange);
            this.tab_Exchange.Controls.Add(this.lv_ExchangeServers);
            this.tab_Exchange.Location = new System.Drawing.Point(4, 22);
            this.tab_Exchange.Name = "tab_Exchange";
            this.tab_Exchange.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Exchange.Size = new System.Drawing.Size(944, 465);
            this.tab_Exchange.TabIndex = 1;
            this.tab_Exchange.Text = "Exchange";
            this.tab_Exchange.UseVisualStyleBackColor = true;
            // 
            // btn_deleteExchangeServer
            // 
            this.btn_deleteExchangeServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteExchangeServer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_deleteExchangeServer.Location = new System.Drawing.Point(34, 389);
            this.btn_deleteExchangeServer.Name = "btn_deleteExchangeServer";
            this.btn_deleteExchangeServer.Size = new System.Drawing.Size(30, 27);
            this.btn_deleteExchangeServer.TabIndex = 56;
            this.btn_deleteExchangeServer.Text = "-";
            this.btn_deleteExchangeServer.UseVisualStyleBackColor = true;
            this.btn_deleteExchangeServer.Click += new System.EventHandler(this.btn_deleteExchangeServer_Click);
            // 
            // gb_ExchangeCustomCreds
            // 
            this.gb_ExchangeCustomCreds.Controls.Add(this.lbl_exchangeCustomDomain);
            this.gb_ExchangeCustomCreds.Controls.Add(this.tb_exchangeCustomDomain);
            this.gb_ExchangeCustomCreds.Controls.Add(this.lbl_exchangeCustomPassword);
            this.gb_ExchangeCustomCreds.Controls.Add(this.lbl_exchangeCustomUsername);
            this.gb_ExchangeCustomCreds.Controls.Add(this.tb_exchangeCustomPassword);
            this.gb_ExchangeCustomCreds.Controls.Add(this.tb_exchangeCustomUsername);
            this.gb_ExchangeCustomCreds.Location = new System.Drawing.Point(794, 232);
            this.gb_ExchangeCustomCreds.Name = "gb_ExchangeCustomCreds";
            this.gb_ExchangeCustomCreds.Size = new System.Drawing.Size(147, 152);
            this.gb_ExchangeCustomCreds.TabIndex = 55;
            this.gb_ExchangeCustomCreds.TabStop = false;
            // 
            // lbl_exchangeCustomDomain
            // 
            this.lbl_exchangeCustomDomain.AutoSize = true;
            this.lbl_exchangeCustomDomain.Enabled = false;
            this.lbl_exchangeCustomDomain.Location = new System.Drawing.Point(6, 54);
            this.lbl_exchangeCustomDomain.Name = "lbl_exchangeCustomDomain";
            this.lbl_exchangeCustomDomain.Size = new System.Drawing.Size(43, 13);
            this.lbl_exchangeCustomDomain.TabIndex = 5;
            this.lbl_exchangeCustomDomain.Text = "Domain";
            // 
            // tb_exchangeCustomDomain
            // 
            this.tb_exchangeCustomDomain.Enabled = false;
            this.tb_exchangeCustomDomain.Location = new System.Drawing.Point(6, 69);
            this.tb_exchangeCustomDomain.Name = "tb_exchangeCustomDomain";
            this.tb_exchangeCustomDomain.Size = new System.Drawing.Size(119, 20);
            this.tb_exchangeCustomDomain.TabIndex = 1;
            this.tb_exchangeCustomDomain.TextChanged += new System.EventHandler(this.tb_exchangeCustomDomain_TextChanged);
            this.tb_exchangeCustomDomain.Validating += new System.ComponentModel.CancelEventHandler(this.tb_exchangeCustomDomain_Validating);
            this.tb_exchangeCustomDomain.Validated += new System.EventHandler(this.tb_exchangeCustomDomain_Validated);
            // 
            // lbl_exchangeCustomPassword
            // 
            this.lbl_exchangeCustomPassword.AutoSize = true;
            this.lbl_exchangeCustomPassword.Enabled = false;
            this.lbl_exchangeCustomPassword.Location = new System.Drawing.Point(6, 94);
            this.lbl_exchangeCustomPassword.Name = "lbl_exchangeCustomPassword";
            this.lbl_exchangeCustomPassword.Size = new System.Drawing.Size(53, 13);
            this.lbl_exchangeCustomPassword.TabIndex = 3;
            this.lbl_exchangeCustomPassword.Text = "Password";
            // 
            // lbl_exchangeCustomUsername
            // 
            this.lbl_exchangeCustomUsername.AutoSize = true;
            this.lbl_exchangeCustomUsername.Enabled = false;
            this.lbl_exchangeCustomUsername.Location = new System.Drawing.Point(6, 14);
            this.lbl_exchangeCustomUsername.Name = "lbl_exchangeCustomUsername";
            this.lbl_exchangeCustomUsername.Size = new System.Drawing.Size(55, 13);
            this.lbl_exchangeCustomUsername.TabIndex = 2;
            this.lbl_exchangeCustomUsername.Text = "Username";
            // 
            // tb_exchangeCustomPassword
            // 
            this.tb_exchangeCustomPassword.Enabled = false;
            this.tb_exchangeCustomPassword.Location = new System.Drawing.Point(6, 111);
            this.tb_exchangeCustomPassword.Name = "tb_exchangeCustomPassword";
            this.tb_exchangeCustomPassword.Size = new System.Drawing.Size(119, 20);
            this.tb_exchangeCustomPassword.TabIndex = 2;
            this.tb_exchangeCustomPassword.UseSystemPasswordChar = true;
            this.tb_exchangeCustomPassword.TextChanged += new System.EventHandler(this.tb_exchangeCustomPassword_TextChanged);
            this.tb_exchangeCustomPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tb_exchangeCustomPassword_Validating);
            this.tb_exchangeCustomPassword.Validated += new System.EventHandler(this.tb_exchangeCustomPassword_Validated);
            // 
            // tb_exchangeCustomUsername
            // 
            this.tb_exchangeCustomUsername.Enabled = false;
            this.tb_exchangeCustomUsername.Location = new System.Drawing.Point(6, 30);
            this.tb_exchangeCustomUsername.Name = "tb_exchangeCustomUsername";
            this.tb_exchangeCustomUsername.Size = new System.Drawing.Size(119, 20);
            this.tb_exchangeCustomUsername.TabIndex = 0;
            this.tb_exchangeCustomUsername.TextChanged += new System.EventHandler(this.tb_exchangeCustomUsername_TextChanged);
            this.tb_exchangeCustomUsername.Validating += new System.ComponentModel.CancelEventHandler(this.tb_exchangeCustomUsername_Validating);
            this.tb_exchangeCustomUsername.Validated += new System.EventHandler(this.tb_exchangeCustomUsername_Validated);
            // 
            // cb_ExchangeUseCustomCreds
            // 
            this.cb_ExchangeUseCustomCreds.AutoSize = true;
            this.cb_ExchangeUseCustomCreds.Location = new System.Drawing.Point(794, 209);
            this.cb_ExchangeUseCustomCreds.Name = "cb_ExchangeUseCustomCreds";
            this.cb_ExchangeUseCustomCreds.Size = new System.Drawing.Size(138, 17);
            this.cb_ExchangeUseCustomCreds.TabIndex = 54;
            this.cb_ExchangeUseCustomCreds.Text = "Use Custom Credentials";
            this.cb_ExchangeUseCustomCreds.UseVisualStyleBackColor = true;
            this.cb_ExchangeUseCustomCreds.CheckedChanged += new System.EventHandler(this.cb_ExchangeUseCustomCreds_CheckedChanged);
            // 
            // btn_ExchangeExportCSV
            // 
            this.btn_ExchangeExportCSV.Location = new System.Drawing.Point(154, 389);
            this.btn_ExchangeExportCSV.Name = "btn_ExchangeExportCSV";
            this.btn_ExchangeExportCSV.Size = new System.Drawing.Size(86, 27);
            this.btn_ExchangeExportCSV.TabIndex = 53;
            this.btn_ExchangeExportCSV.Text = "Export CSV";
            this.btn_ExchangeExportCSV.UseVisualStyleBackColor = true;
            this.btn_ExchangeExportCSV.Click += new System.EventHandler(this.btn_ExchangeExportCSV_Click);
            // 
            // btn_ExchangeImportCSV
            // 
            this.btn_ExchangeImportCSV.Location = new System.Drawing.Point(63, 389);
            this.btn_ExchangeImportCSV.Name = "btn_ExchangeImportCSV";
            this.btn_ExchangeImportCSV.Size = new System.Drawing.Size(90, 27);
            this.btn_ExchangeImportCSV.TabIndex = 52;
            this.btn_ExchangeImportCSV.Text = "Import CSV";
            this.btn_ExchangeImportCSV.UseVisualStyleBackColor = true;
            this.btn_ExchangeImportCSV.Click += new System.EventHandler(this.btn_ExchangeImportCSV_Click);
            // 
            // btn_AddExchangeServerManually
            // 
            this.btn_AddExchangeServerManually.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddExchangeServerManually.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_AddExchangeServerManually.Location = new System.Drawing.Point(5, 389);
            this.btn_AddExchangeServerManually.Name = "btn_AddExchangeServerManually";
            this.btn_AddExchangeServerManually.Size = new System.Drawing.Size(30, 27);
            this.btn_AddExchangeServerManually.TabIndex = 51;
            this.btn_AddExchangeServerManually.Text = "+";
            this.btn_AddExchangeServerManually.UseVisualStyleBackColor = true;
            this.btn_AddExchangeServerManually.Click += new System.EventHandler(this.btn_AddExchangeServerManually_Click);
            // 
            // lbl_exchangeGenerationRunningValue
            // 
            this.lbl_exchangeGenerationRunningValue.AutoSize = true;
            this.lbl_exchangeGenerationRunningValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exchangeGenerationRunningValue.Location = new System.Drawing.Point(846, 402);
            this.lbl_exchangeGenerationRunningValue.Name = "lbl_exchangeGenerationRunningValue";
            this.lbl_exchangeGenerationRunningValue.Size = new System.Drawing.Size(15, 15);
            this.lbl_exchangeGenerationRunningValue.TabIndex = 48;
            this.lbl_exchangeGenerationRunningValue.Text = "0";
            // 
            // lbl_exchangeTotalAgentsValue
            // 
            this.lbl_exchangeTotalAgentsValue.AutoSize = true;
            this.lbl_exchangeTotalAgentsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_exchangeTotalAgentsValue.Location = new System.Drawing.Point(82, 423);
            this.lbl_exchangeTotalAgentsValue.Name = "lbl_exchangeTotalAgentsValue";
            this.lbl_exchangeTotalAgentsValue.Size = new System.Drawing.Size(13, 13);
            this.lbl_exchangeTotalAgentsValue.TabIndex = 50;
            this.lbl_exchangeTotalAgentsValue.Text = "0";
            // 
            // lbl_exchangeGenerationRunningLabel
            // 
            this.lbl_exchangeGenerationRunningLabel.AutoSize = true;
            this.lbl_exchangeGenerationRunningLabel.Location = new System.Drawing.Point(804, 389);
            this.lbl_exchangeGenerationRunningLabel.Name = "lbl_exchangeGenerationRunningLabel";
            this.lbl_exchangeGenerationRunningLabel.Size = new System.Drawing.Size(115, 13);
            this.lbl_exchangeGenerationRunningLabel.TabIndex = 47;
            this.lbl_exchangeGenerationRunningLabel.Text = "Generation running for:";
            // 
            // lbl_exchangeTotalAgentsLabel
            // 
            this.lbl_exchangeTotalAgentsLabel.AutoSize = true;
            this.lbl_exchangeTotalAgentsLabel.Location = new System.Drawing.Point(7, 423);
            this.lbl_exchangeTotalAgentsLabel.Name = "lbl_exchangeTotalAgentsLabel";
            this.lbl_exchangeTotalAgentsLabel.Size = new System.Drawing.Size(71, 13);
            this.lbl_exchangeTotalAgentsLabel.TabIndex = 49;
            this.lbl_exchangeTotalAgentsLabel.Text = "Total servers:";
            // 
            // gb_ExchangeParameters
            // 
            this.gb_ExchangeParameters.Controls.Add(this.lbl_MailSizeNote);
            this.gb_ExchangeParameters.Controls.Add(this.cb_MailSize);
            this.gb_ExchangeParameters.Controls.Add(this.lbl_MessageSize);
            this.gb_ExchangeParameters.Location = new System.Drawing.Point(794, 12);
            this.gb_ExchangeParameters.Name = "gb_ExchangeParameters";
            this.gb_ExchangeParameters.Size = new System.Drawing.Size(144, 192);
            this.gb_ExchangeParameters.TabIndex = 35;
            this.gb_ExchangeParameters.TabStop = false;
            this.gb_ExchangeParameters.Text = "Parameters";
            // 
            // lbl_MailSizeNote
            // 
            this.lbl_MailSizeNote.AutoSize = true;
            this.lbl_MailSizeNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_MailSizeNote.Location = new System.Drawing.Point(9, 61);
            this.lbl_MailSizeNote.Name = "lbl_MailSizeNote";
            this.lbl_MailSizeNote.Size = new System.Drawing.Size(0, 12);
            this.lbl_MailSizeNote.TabIndex = 16;
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
            this.btn_stopExchangeGeneration.Location = new System.Drawing.Point(591, 389);
            this.btn_stopExchangeGeneration.Margin = new System.Windows.Forms.Padding(2);
            this.btn_stopExchangeGeneration.Name = "btn_stopExchangeGeneration";
            this.btn_stopExchangeGeneration.Size = new System.Drawing.Size(198, 34);
            this.btn_stopExchangeGeneration.TabIndex = 12;
            this.btn_stopExchangeGeneration.Text = "Stop Exchange Generation";
            this.btn_stopExchangeGeneration.UseVisualStyleBackColor = true;
            this.btn_stopExchangeGeneration.Click += new System.EventHandler(this.btn_stopExchangeGeneration_Click);
            // 
            // btn_startExchangeGeneration
            // 
            this.btn_startExchangeGeneration.Location = new System.Drawing.Point(369, 389);
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
            // tabSQL
            // 
            this.tabSQL.Controls.Add(this.btn_RemoveSQLManually);
            this.tabSQL.Controls.Add(this.gb_SQLCustomCreds);
            this.tabSQL.Controls.Add(this.cb_UseCustomCredsSQL);
            this.tabSQL.Controls.Add(this.btn_ExportCSVSQL);
            this.tabSQL.Controls.Add(this.btn_ImportCSVSQL);
            this.tabSQL.Controls.Add(this.btn_AddSQLManually);
            this.tabSQL.Controls.Add(this.lbl_SQLGenerationRunningvalue);
            this.tabSQL.Controls.Add(this.lbl_TotalSQLServersValue);
            this.tabSQL.Controls.Add(this.lbl_SQLGenerationRunninglbl);
            this.tabSQL.Controls.Add(this.lbl_TotalSQLServerslbl);
            this.tabSQL.Controls.Add(this.gb_SQLParams);
            this.tabSQL.Controls.Add(this.btn_StopSQLGeneration);
            this.tabSQL.Controls.Add(this.btn_StartSQLGeneration);
            this.tabSQL.Controls.Add(this.cb_SelectAllSQL);
            this.tabSQL.Controls.Add(this.lv_SQL);
            this.tabSQL.Location = new System.Drawing.Point(4, 22);
            this.tabSQL.Name = "tabSQL";
            this.tabSQL.Padding = new System.Windows.Forms.Padding(3);
            this.tabSQL.Size = new System.Drawing.Size(944, 465);
            this.tabSQL.TabIndex = 2;
            this.tabSQL.Text = "SQL (Beta)";
            this.tabSQL.UseVisualStyleBackColor = true;
            // 
            // btn_RemoveSQLManually
            // 
            this.btn_RemoveSQLManually.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemoveSQLManually.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_RemoveSQLManually.Location = new System.Drawing.Point(34, 389);
            this.btn_RemoveSQLManually.Name = "btn_RemoveSQLManually";
            this.btn_RemoveSQLManually.Size = new System.Drawing.Size(30, 27);
            this.btn_RemoveSQLManually.TabIndex = 71;
            this.btn_RemoveSQLManually.Text = "-";
            this.btn_RemoveSQLManually.UseVisualStyleBackColor = true;
            this.btn_RemoveSQLManually.Click += new System.EventHandler(this.btn_RemoveSQLManually_Click);
            // 
            // gb_SQLCustomCreds
            // 
            this.gb_SQLCustomCreds.Controls.Add(this.lbl_SQLCustomPassword);
            this.gb_SQLCustomCreds.Controls.Add(this.lbl_SQLCustomUsername);
            this.gb_SQLCustomCreds.Controls.Add(this.tb_SQLCustomPassword);
            this.gb_SQLCustomCreds.Controls.Add(this.tb_SQLCustomUsername);
            this.gb_SQLCustomCreds.Location = new System.Drawing.Point(794, 232);
            this.gb_SQLCustomCreds.Name = "gb_SQLCustomCreds";
            this.gb_SQLCustomCreds.Size = new System.Drawing.Size(147, 152);
            this.gb_SQLCustomCreds.TabIndex = 70;
            this.gb_SQLCustomCreds.TabStop = false;
            // 
            // lbl_SQLCustomPassword
            // 
            this.lbl_SQLCustomPassword.AutoSize = true;
            this.lbl_SQLCustomPassword.Enabled = false;
            this.lbl_SQLCustomPassword.Location = new System.Drawing.Point(6, 53);
            this.lbl_SQLCustomPassword.Name = "lbl_SQLCustomPassword";
            this.lbl_SQLCustomPassword.Size = new System.Drawing.Size(53, 13);
            this.lbl_SQLCustomPassword.TabIndex = 3;
            this.lbl_SQLCustomPassword.Text = "Password";
            // 
            // lbl_SQLCustomUsername
            // 
            this.lbl_SQLCustomUsername.AutoSize = true;
            this.lbl_SQLCustomUsername.Enabled = false;
            this.lbl_SQLCustomUsername.Location = new System.Drawing.Point(6, 14);
            this.lbl_SQLCustomUsername.Name = "lbl_SQLCustomUsername";
            this.lbl_SQLCustomUsername.Size = new System.Drawing.Size(55, 13);
            this.lbl_SQLCustomUsername.TabIndex = 2;
            this.lbl_SQLCustomUsername.Text = "Username";
            // 
            // tb_SQLCustomPassword
            // 
            this.tb_SQLCustomPassword.Enabled = false;
            this.tb_SQLCustomPassword.Location = new System.Drawing.Point(6, 69);
            this.tb_SQLCustomPassword.Name = "tb_SQLCustomPassword";
            this.tb_SQLCustomPassword.Size = new System.Drawing.Size(119, 20);
            this.tb_SQLCustomPassword.TabIndex = 2;
            this.tb_SQLCustomPassword.UseSystemPasswordChar = true;
            this.tb_SQLCustomPassword.TextChanged += new System.EventHandler(this.tb_SQLCustomPassword_TextChanged);
            this.tb_SQLCustomPassword.Validating += new System.ComponentModel.CancelEventHandler(this.tb_SQLCustomPassword_Validating);
            this.tb_SQLCustomPassword.Validated += new System.EventHandler(this.tb_SQLCustomPassword_Validated);
            // 
            // tb_SQLCustomUsername
            // 
            this.tb_SQLCustomUsername.Enabled = false;
            this.tb_SQLCustomUsername.Location = new System.Drawing.Point(6, 30);
            this.tb_SQLCustomUsername.Name = "tb_SQLCustomUsername";
            this.tb_SQLCustomUsername.Size = new System.Drawing.Size(119, 20);
            this.tb_SQLCustomUsername.TabIndex = 0;
            this.tb_SQLCustomUsername.TextChanged += new System.EventHandler(this.tb_SQLCustomUsername_TextChanged);
            this.tb_SQLCustomUsername.Validating += new System.ComponentModel.CancelEventHandler(this.tb_SQLCustomUsername_Validating);
            this.tb_SQLCustomUsername.Validated += new System.EventHandler(this.tb_SQLCustomUsername_Validated);
            // 
            // cb_UseCustomCredsSQL
            // 
            this.cb_UseCustomCredsSQL.AutoSize = true;
            this.cb_UseCustomCredsSQL.Location = new System.Drawing.Point(794, 209);
            this.cb_UseCustomCredsSQL.Name = "cb_UseCustomCredsSQL";
            this.cb_UseCustomCredsSQL.Size = new System.Drawing.Size(138, 17);
            this.cb_UseCustomCredsSQL.TabIndex = 69;
            this.cb_UseCustomCredsSQL.Text = "Use Custom Credentials";
            this.cb_UseCustomCredsSQL.UseVisualStyleBackColor = true;
            this.cb_UseCustomCredsSQL.CheckedChanged += new System.EventHandler(this.cb_UseCustomCredsSQL_CheckedChanged);
            // 
            // btn_ExportCSVSQL
            // 
            this.btn_ExportCSVSQL.Location = new System.Drawing.Point(154, 389);
            this.btn_ExportCSVSQL.Name = "btn_ExportCSVSQL";
            this.btn_ExportCSVSQL.Size = new System.Drawing.Size(86, 27);
            this.btn_ExportCSVSQL.TabIndex = 68;
            this.btn_ExportCSVSQL.Text = "Export CSV";
            this.btn_ExportCSVSQL.UseVisualStyleBackColor = true;
            this.btn_ExportCSVSQL.Click += new System.EventHandler(this.btn_ExportCSVSQL_Click);
            // 
            // btn_ImportCSVSQL
            // 
            this.btn_ImportCSVSQL.Location = new System.Drawing.Point(63, 389);
            this.btn_ImportCSVSQL.Name = "btn_ImportCSVSQL";
            this.btn_ImportCSVSQL.Size = new System.Drawing.Size(90, 27);
            this.btn_ImportCSVSQL.TabIndex = 67;
            this.btn_ImportCSVSQL.Text = "Import CSV";
            this.btn_ImportCSVSQL.UseVisualStyleBackColor = true;
            this.btn_ImportCSVSQL.Click += new System.EventHandler(this.btn_ImportCSVSQL_Click);
            // 
            // btn_AddSQLManually
            // 
            this.btn_AddSQLManually.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_AddSQLManually.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_AddSQLManually.Location = new System.Drawing.Point(5, 389);
            this.btn_AddSQLManually.Name = "btn_AddSQLManually";
            this.btn_AddSQLManually.Size = new System.Drawing.Size(30, 27);
            this.btn_AddSQLManually.TabIndex = 66;
            this.btn_AddSQLManually.Text = "+";
            this.btn_AddSQLManually.UseVisualStyleBackColor = true;
            this.btn_AddSQLManually.Click += new System.EventHandler(this.btn_AddSQLManually_Click);
            // 
            // lbl_SQLGenerationRunningvalue
            // 
            this.lbl_SQLGenerationRunningvalue.AutoSize = true;
            this.lbl_SQLGenerationRunningvalue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SQLGenerationRunningvalue.Location = new System.Drawing.Point(846, 402);
            this.lbl_SQLGenerationRunningvalue.Name = "lbl_SQLGenerationRunningvalue";
            this.lbl_SQLGenerationRunningvalue.Size = new System.Drawing.Size(15, 15);
            this.lbl_SQLGenerationRunningvalue.TabIndex = 63;
            this.lbl_SQLGenerationRunningvalue.Text = "0";
            // 
            // lbl_TotalSQLServersValue
            // 
            this.lbl_TotalSQLServersValue.AutoSize = true;
            this.lbl_TotalSQLServersValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalSQLServersValue.Location = new System.Drawing.Point(82, 423);
            this.lbl_TotalSQLServersValue.Name = "lbl_TotalSQLServersValue";
            this.lbl_TotalSQLServersValue.Size = new System.Drawing.Size(13, 13);
            this.lbl_TotalSQLServersValue.TabIndex = 65;
            this.lbl_TotalSQLServersValue.Text = "0";
            // 
            // lbl_SQLGenerationRunninglbl
            // 
            this.lbl_SQLGenerationRunninglbl.AutoSize = true;
            this.lbl_SQLGenerationRunninglbl.Location = new System.Drawing.Point(804, 389);
            this.lbl_SQLGenerationRunninglbl.Name = "lbl_SQLGenerationRunninglbl";
            this.lbl_SQLGenerationRunninglbl.Size = new System.Drawing.Size(115, 13);
            this.lbl_SQLGenerationRunninglbl.TabIndex = 62;
            this.lbl_SQLGenerationRunninglbl.Text = "Generation running for:";
            // 
            // lbl_TotalSQLServerslbl
            // 
            this.lbl_TotalSQLServerslbl.AutoSize = true;
            this.lbl_TotalSQLServerslbl.Location = new System.Drawing.Point(7, 423);
            this.lbl_TotalSQLServerslbl.Name = "lbl_TotalSQLServerslbl";
            this.lbl_TotalSQLServerslbl.Size = new System.Drawing.Size(71, 13);
            this.lbl_TotalSQLServerslbl.TabIndex = 64;
            this.lbl_TotalSQLServerslbl.Text = "Total servers:";
            // 
            // gb_SQLParams
            // 
            this.gb_SQLParams.Controls.Add(this.tb_dbName);
            this.gb_SQLParams.Controls.Add(this.lbl_dbName);
            this.gb_SQLParams.Controls.Add(this.tb_SQLAmountRows);
            this.gb_SQLParams.Controls.Add(this.label8);
            this.gb_SQLParams.Controls.Add(this.lbl_AddRows);
            this.gb_SQLParams.Location = new System.Drawing.Point(794, 12);
            this.gb_SQLParams.Name = "gb_SQLParams";
            this.gb_SQLParams.Size = new System.Drawing.Size(144, 192);
            this.gb_SQLParams.TabIndex = 61;
            this.gb_SQLParams.TabStop = false;
            this.gb_SQLParams.Text = "Parameters";
            // 
            // tb_dbName
            // 
            this.tb_dbName.Location = new System.Drawing.Point(6, 34);
            this.tb_dbName.Margin = new System.Windows.Forms.Padding(2);
            this.tb_dbName.Name = "tb_dbName";
            this.tb_dbName.Size = new System.Drawing.Size(119, 20);
            this.tb_dbName.TabIndex = 19;
            this.tb_dbName.Text = "DB1";
            this.tb_dbName.Validating += new System.ComponentModel.CancelEventHandler(this.tb_dbName_Validating);
            this.tb_dbName.Validated += new System.EventHandler(this.tb_dbName_Validated);
            // 
            // lbl_dbName
            // 
            this.lbl_dbName.AutoSize = true;
            this.lbl_dbName.Location = new System.Drawing.Point(6, 16);
            this.lbl_dbName.Name = "lbl_dbName";
            this.lbl_dbName.Size = new System.Drawing.Size(53, 13);
            this.lbl_dbName.TabIndex = 20;
            this.lbl_dbName.Text = "DB Name";
            // 
            // tb_SQLAmountRows
            // 
            this.tb_SQLAmountRows.Location = new System.Drawing.Point(6, 76);
            this.tb_SQLAmountRows.Margin = new System.Windows.Forms.Padding(2);
            this.tb_SQLAmountRows.Name = "tb_SQLAmountRows";
            this.tb_SQLAmountRows.Size = new System.Drawing.Size(119, 20);
            this.tb_SQLAmountRows.TabIndex = 17;
            this.tb_SQLAmountRows.Text = "1000";
            this.tb_SQLAmountRows.Validating += new System.ComponentModel.CancelEventHandler(this.tb_SQLAmountRows_Validating);
            this.tb_SQLAmountRows.Validated += new System.EventHandler(this.tb_SQLAmountRows_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 12);
            this.label8.TabIndex = 16;
            // 
            // lbl_AddRows
            // 
            this.lbl_AddRows.AutoSize = true;
            this.lbl_AddRows.Location = new System.Drawing.Point(6, 61);
            this.lbl_AddRows.Name = "lbl_AddRows";
            this.lbl_AddRows.Size = new System.Drawing.Size(85, 13);
            this.lbl_AddRows.TabIndex = 14;
            this.lbl_AddRows.Text = "Amount of Rows";
            // 
            // btn_StopSQLGeneration
            // 
            this.btn_StopSQLGeneration.Location = new System.Drawing.Point(591, 389);
            this.btn_StopSQLGeneration.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StopSQLGeneration.Name = "btn_StopSQLGeneration";
            this.btn_StopSQLGeneration.Size = new System.Drawing.Size(198, 34);
            this.btn_StopSQLGeneration.TabIndex = 60;
            this.btn_StopSQLGeneration.Text = "Stop SQL Generation";
            this.btn_StopSQLGeneration.UseVisualStyleBackColor = true;
            this.btn_StopSQLGeneration.Click += new System.EventHandler(this.btn_StopSQLGeneration_Click);
            // 
            // btn_StartSQLGeneration
            // 
            this.btn_StartSQLGeneration.Location = new System.Drawing.Point(369, 389);
            this.btn_StartSQLGeneration.Margin = new System.Windows.Forms.Padding(2);
            this.btn_StartSQLGeneration.Name = "btn_StartSQLGeneration";
            this.btn_StartSQLGeneration.Size = new System.Drawing.Size(218, 34);
            this.btn_StartSQLGeneration.TabIndex = 59;
            this.btn_StartSQLGeneration.Text = "Start SQL Generation";
            this.btn_StartSQLGeneration.UseVisualStyleBackColor = true;
            this.btn_StartSQLGeneration.Click += new System.EventHandler(this.btn_StartSQLGeneration_Click);
            // 
            // cb_SelectAllSQL
            // 
            this.cb_SelectAllSQL.AutoSize = true;
            this.cb_SelectAllSQL.Location = new System.Drawing.Point(10, 10);
            this.cb_SelectAllSQL.Margin = new System.Windows.Forms.Padding(2);
            this.cb_SelectAllSQL.Name = "cb_SelectAllSQL";
            this.cb_SelectAllSQL.Size = new System.Drawing.Size(15, 14);
            this.cb_SelectAllSQL.TabIndex = 58;
            this.cb_SelectAllSQL.UseVisualStyleBackColor = true;
            this.cb_SelectAllSQL.CheckedChanged += new System.EventHandler(this.cb_SelectAllSQL_CheckedChanged);
            // 
            // lv_SQL
            // 
            this.lv_SQL.Location = new System.Drawing.Point(5, 5);
            this.lv_SQL.Margin = new System.Windows.Forms.Padding(2);
            this.lv_SQL.Name = "lv_SQL";
            this.lv_SQL.Size = new System.Drawing.Size(784, 379);
            this.lv_SQL.TabIndex = 57;
            this.lv_SQL.UseCompatibleStateImageBehavior = false;
            this.lv_SQL.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lv_SQL_ColumnClick);
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
            // lbl_Loading
            // 
            this.lbl_Loading.AutoSize = true;
            this.lbl_Loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Loading.Location = new System.Drawing.Point(312, 414);
            this.lbl_Loading.Name = "lbl_Loading";
            this.lbl_Loading.Size = new System.Drawing.Size(372, 16);
            this.lbl_Loading.TabIndex = 57;
            this.lbl_Loading.Text = "Loading... Please wait... It can take several minutes...";
            this.lbl_Loading.Visible = false;
            // 
            // cb_fillingGeneration
            // 
            this.cb_fillingGeneration.AutoSize = true;
            this.cb_fillingGeneration.Location = new System.Drawing.Point(6, 179);
            this.cb_fillingGeneration.Name = "cb_fillingGeneration";
            this.cb_fillingGeneration.Size = new System.Drawing.Size(109, 17);
            this.cb_fillingGeneration.TabIndex = 21;
            this.cb_fillingGeneration.Text = "Filling generation*";
            this.cb_fillingGeneration.UseVisualStyleBackColor = true;
            // 
            // lbl_fillingGenerationDescription
            // 
            this.lbl_fillingGenerationDescription.AutoSize = true;
            this.lbl_fillingGenerationDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fillingGenerationDescription.Location = new System.Drawing.Point(7, 195);
            this.lbl_fillingGenerationDescription.Name = "lbl_fillingGenerationDescription";
            this.lbl_fillingGenerationDescription.Size = new System.Drawing.Size(0, 12);
            this.lbl_fillingGenerationDescription.TabIndex = 22;
            // 
            // Form1
            // 
            this.AcceptButton = this.btn_Connect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(964, 502);
            this.Controls.Add(this.lbl_Loading);
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RR Data Generator";
            this.gb_ddtparams.ResumeLayout(false);
            this.gb_ddtparams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tab_Data.ResumeLayout(false);
            this.tab_Data.PerformLayout();
            this.gb_customCredentials.ResumeLayout(false);
            this.gb_customCredentials.PerformLayout();
            this.tab_Exchange.ResumeLayout(false);
            this.tab_Exchange.PerformLayout();
            this.gb_ExchangeCustomCreds.ResumeLayout(false);
            this.gb_ExchangeCustomCreds.PerformLayout();
            this.gb_ExchangeParameters.ResumeLayout(false);
            this.gb_ExchangeParameters.PerformLayout();
            this.tabSQL.ResumeLayout(false);
            this.tabSQL.PerformLayout();
            this.gb_SQLCustomCreds.ResumeLayout(false);
            this.gb_SQLCustomCreds.PerformLayout();
            this.gb_SQLParams.ResumeLayout(false);
            this.gb_SQLParams.PerformLayout();
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
        private System.Windows.Forms.TabPage tab_Data;
        private System.Windows.Forms.TabPage tab_Exchange;
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
        private System.Windows.Forms.Button btn_addServerManually;
        private System.Windows.Forms.Button btn_ExportCSV;
        private System.Windows.Forms.Button btn_ImportCSV;
        private System.Windows.Forms.GroupBox gb_customCredentials;
        private System.Windows.Forms.CheckBox cb_UseCustomCredentials;
        private System.Windows.Forms.Label lbl_customPassword;
        private System.Windows.Forms.Label lbl_customUserName;
        private System.Windows.Forms.TextBox tb_customPassword;
        private System.Windows.Forms.TextBox tb_customUsername;
        private System.Windows.Forms.Button btn_deleteSelectedServers;
        private System.Windows.Forms.Button btn_deleteExchangeServer;
        private System.Windows.Forms.GroupBox gb_ExchangeCustomCreds;
        private System.Windows.Forms.Label lbl_exchangeCustomPassword;
        private System.Windows.Forms.Label lbl_exchangeCustomUsername;
        private System.Windows.Forms.TextBox tb_exchangeCustomPassword;
        private System.Windows.Forms.TextBox tb_exchangeCustomUsername;
        private System.Windows.Forms.CheckBox cb_ExchangeUseCustomCreds;
        private System.Windows.Forms.Button btn_ExchangeExportCSV;
        private System.Windows.Forms.Button btn_ExchangeImportCSV;
        private System.Windows.Forms.Button btn_AddExchangeServerManually;
        private System.Windows.Forms.Label lbl_exchangeGenerationRunningValue;
        private System.Windows.Forms.Label lbl_exchangeTotalAgentsValue;
        private System.Windows.Forms.Label lbl_exchangeGenerationRunningLabel;
        private System.Windows.Forms.Label lbl_exchangeTotalAgentsLabel;
        private System.Windows.Forms.Label lbl_exchangeCustomDomain;
        private System.Windows.Forms.TextBox tb_exchangeCustomDomain;
        private System.Windows.Forms.Label lbl_MailSizeNote;
        private System.Windows.Forms.Label lbl_Loading;
        private System.Windows.Forms.TabPage tabSQL;
        private System.Windows.Forms.Button btn_RemoveSQLManually;
        private System.Windows.Forms.GroupBox gb_SQLCustomCreds;
        private System.Windows.Forms.Label lbl_SQLCustomPassword;
        private System.Windows.Forms.Label lbl_SQLCustomUsername;
        private System.Windows.Forms.TextBox tb_SQLCustomPassword;
        private System.Windows.Forms.TextBox tb_SQLCustomUsername;
        private System.Windows.Forms.CheckBox cb_UseCustomCredsSQL;
        private System.Windows.Forms.Button btn_ExportCSVSQL;
        private System.Windows.Forms.Button btn_ImportCSVSQL;
        private System.Windows.Forms.Button btn_AddSQLManually;
        private System.Windows.Forms.Label lbl_SQLGenerationRunningvalue;
        private System.Windows.Forms.Label lbl_TotalSQLServersValue;
        private System.Windows.Forms.Label lbl_SQLGenerationRunninglbl;
        private System.Windows.Forms.Label lbl_TotalSQLServerslbl;
        private System.Windows.Forms.GroupBox gb_SQLParams;
        private System.Windows.Forms.TextBox tb_SQLAmountRows;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbl_AddRows;
        private System.Windows.Forms.Button btn_StopSQLGeneration;
        private System.Windows.Forms.Button btn_StartSQLGeneration;
        private System.Windows.Forms.CheckBox cb_SelectAllSQL;
        private System.Windows.Forms.ListView lv_SQL;
        private System.Windows.Forms.TextBox tb_dbName;
        private System.Windows.Forms.Label lbl_dbName;
        private System.Windows.Forms.Label lbl_fillingGenerationDescription;
        private System.Windows.Forms.CheckBox cb_fillingGeneration;
    }
}

