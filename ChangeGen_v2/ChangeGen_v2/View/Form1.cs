using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class Form1 : Form
    {
        private readonly ListViewColumnSorter _lvwColumnSorter;               // used for storing instance of column sorter object
        private List<Control> _connectionPageControls;       // used for storing controls of Connection page
        private List<Control> _listviewPageControls;         // used for storing controls of ListView page
        private CoreConnectionCredentials _coreCreds;        // used for storing core API credentials
        private DdtParameters _ddtParameters;                // used for storing DDT Parameters

        public Form1()
        {
            InitializeComponent();

            AddControlsToCollections();
            DisplayConnectionPage();
            GetCredsFromFileToGui();

            _lvwColumnSorter = new ListViewColumnSorter();
            lv_AgentsList.ListViewItemSorter = _lvwColumnSorter;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            _coreCreds = new CoreConnectionCredentials
            {
                Hostname = tb_hostname.Text,
                Port = Convert.ToInt32(tb_Port.Text),
                Username = tb_userName.Text,
                Password = tb_password.Text
            };

            _coreCreds.SerizalizeCredsToFile();
            GetDdtParamsFromFileToGui();

            // Displays list of servers received from Core API to ListView
            try
            {
                ServerWrapper.ServersToListView(lv_AgentsList, lv_ExchangeServers,_coreCreds);
                Logger.Log("Successfully connected to Core Server: " + tb_hostname.Text, Logger.LogLevel.Info, tb_hostname.Text);
            }
            catch (WCFClientBase.ClientServerErrorException exception)
            {
                Logger.LogError("Cannot connect to Core server " + _coreCreds.Hostname, _coreCreds.Hostname, exception);
                MessageBox.Show("Cannot connect to Core server." + Environment.NewLine + exception.Message, "Connection Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            catch (WCFClientBase.HttpUnauthorizedRequestException exception)
            {
                Logger.LogError("Cannot connect to Core server " + _coreCreds.Hostname + " Wrong credentials.", _coreCreds.Hostname, exception);
                MessageBox.Show("Cannot connect to Core server. Incorrect credentials." + Environment.NewLine + exception.Message, "Connection Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            timer1.Interval = 3000;     // Timer for UI update
            timer1.Start();


            // Hide Connection Page and displays ListView Page
            DisplayListViewPage();

            lbl_TotalAmountValue.Text = lv_AgentsList.Items.Count.ToString();  
        }

        private void lv_AgentsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Sort ListView by clicked column
            _lvwColumnSorter.SortColumn(e, lv_AgentsList);
        }

        private void cb_selectAllAgents_CheckedChanged(object sender, EventArgs e)
        {
            // Check/Uncheck all agents
            ControlsImplementation.SelectUnselectAll(lv_AgentsList, cb_selectAllAgents.Checked);
        }

        private void btn_StopDDT_Click(object sender, EventArgs e)
        {
            // Stop DDT for selected servers
            DdtWrapper.StopDdt(lv_AgentsList, ServerWrapper.ServersList);

            // Update ListView
            ServerWrapper.UpdateListView(lv_AgentsList, lbl_ChangeRateValue, lbl_totalAgentsRunningValue);
        }

        private void btn_startDDT_Click(object sender, EventArgs e)
        {
            _ddtParameters = new DdtParameters()
            {
                Filesize = Convert.ToInt32(tb_Size.Text),
                Compression = Convert.ToInt32(tb_Compression.Text),
                Interval = Convert.ToInt32(tb_Interval.Text),
                Filepath = tb_Path.Text
            };

            _ddtParameters.SerizalizeDdtParamsToFile();

            // Start DDT for selected servers with specific parameters
            DdtWrapper.StartDdt(lv_AgentsList,
                            ServerWrapper.ServersList,
                            _ddtParameters);

            // Update ListView
            ServerWrapper.UpdateListView(lv_AgentsList, lbl_ChangeRateValue, lbl_totalAgentsRunningValue);

        }

        // This method displays controls for connection page
        public void DisplayConnectionPage()
        {
            ControlsImplementation.ChangePage(_listviewPageControls, _connectionPageControls);
        }

        // This method displays controls for ListView Page
        public void DisplayListViewPage()
        {
            ControlsImplementation.ChangePage(_connectionPageControls, _listviewPageControls);
        }

        // This method adds controls of Connection and ListView page to two separate collections
        private void AddControlsToCollections()
        {
            _connectionPageControls = new List<Control>();
            _listviewPageControls = new List<Control>();

            _connectionPageControls.Add(tb_hostname);
            _connectionPageControls.Add(tb_userName);
            _connectionPageControls.Add(tb_password);
            _connectionPageControls.Add(btn_Connect);
            _connectionPageControls.Add(lbl_hostname);
            _connectionPageControls.Add(lbl_username);
            _connectionPageControls.Add(lbl_password);
            _connectionPageControls.Add(tb_Port);
            _connectionPageControls.Add(lbl_Port);

            _listviewPageControls.Add(tabControl);
        }

        private void GetCredsFromFileToGui()
        {
            var creds = CoreConnectionCredentials.DeserializeCredsFromFile();
            if (creds == null)
            {
                return;
            }

            tb_hostname.Text = creds.Hostname;
            tb_Port.Text = creds.Port.ToString();
            tb_userName.Text = creds.Username;
            tb_password.Text = creds.Password;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ServerWrapper.UpdateListView(lv_AgentsList, lbl_ChangeRateValue, lbl_totalAgentsRunningValue);
            ServerWrapper.UpdateExchangeListView(lv_ExchangeServers);
        }

        private void GetDdtParamsFromFileToGui()
        {
            var ddtParams = DdtParameters.DeserializeDdtParamsFromFile();
            if (ddtParams == null)
            {
                return;
            }

            tb_Size.Text = ddtParams.Filesize.ToString();
            tb_Compression.Text = ddtParams.Compression.ToString();
            tb_Path.Text = ddtParams.Filepath;
            tb_Interval.Text = ddtParams.Interval.ToString();

        }

        private void tb_hostname_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_hostname_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_userName_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_userName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_password_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_password_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_Path_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingEmpty(e, (TextBox)sender, errorProvider1);
        }

        private void tb_Path_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_Port_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingPort(e, (TextBox)sender, errorProvider1);
        }

        private void tb_Port_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_Size_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_Size_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingNumeric(e, (TextBox)sender, errorProvider1);
        }

        private void tb_Interval_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void tb_Interval_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingNumeric(e, (TextBox)sender, errorProvider1);
        }

        private void tb_Compression_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validator.TextBox_ValidatingCompression(e, (TextBox)sender, errorProvider1);
        }

        private void tb_Compression_Validated(object sender, EventArgs e)
        {
            Validator.TextBox_Validated((TextBox)sender, errorProvider1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var box = new AboutBox1();
            box.Show();
        }

        private void btn_startExchangeGeneration_Click(object sender, EventArgs e)
        {
            //_ddtParameters.SerizalizeDdtParamsToFile();

            // Start DDT for selected servers with specific parameters
           ExchangeGenWrapper.StartExchangeGenerator(lv_ExchangeServers, ServerWrapper.ExchangeServersList);

            // Update ListView
           ServerWrapper.UpdateExchangeListView(lv_ExchangeServers);
        }

        private void btn_stopExchangeGeneration_Click(object sender, EventArgs e)
        {
            // Stop DDT for selected servers
            ExchangeGenWrapper.StopExchangeGenerator(lv_ExchangeServers,ServerWrapper.ExchangeServersList);

            // Update ListView
            ServerWrapper.UpdateExchangeListView(lv_ExchangeServers);
        }
    }
}
