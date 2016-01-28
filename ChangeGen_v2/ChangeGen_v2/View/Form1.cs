using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Threading;

namespace ChangeGen_v2
{
    public partial class Form1 : Form
    {
        ListViewColumnSorter lvwColumnSorter;               // used for storing instance of column sorter object
        private List<Control> connectionPageControls;       // used for storing controls of Connection page
        private List<Control> listviewPageControls;         // used for storing controls of ListView page
        private CoreConnectionCredentials coreCreds;        // used for storing core API credentials
        private DDTParameters ddtParameters;                // used for storing DDT Parameters

        public Form1()
        {
            InitializeComponent();

            AddControlsToCollections();
            displayConnectionPage();

            GetCredsFromFileToGUI();

            lvwColumnSorter = new ListViewColumnSorter();
            lv_AgentsList.ListViewItemSorter = lvwColumnSorter;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {           
            coreCreds = new CoreConnectionCredentials();
            coreCreds.Hostname = tb_hostname.Text;
            coreCreds.Port = Convert.ToInt32(tb_Port.Text);
            coreCreds.Username = tb_userName.Text;
            coreCreds.Password = tb_password.Text;

            coreCreds.SerizalizeCredsToFile();
            GetDDTParamsFromFileToGUI();

            // Displays list of servers received from Core API to ListView
            try
            {
                ServerWrapper.ServersToListView(lv_AgentsList,coreCreds);
                Logger.Log("Successfully connected to Core Server: " + tb_hostname.Text, Logger.LogLevel.Info, tb_hostname.Text);
            }
            catch (WCFClientBase.ClientServerErrorException exception)
            {
                Logger.LogError("Cannot connect to Core server " + coreCreds.Hostname, coreCreds.Hostname, exception);
                MessageBox.Show("Cannot connect to Core server." + Environment.NewLine + exception.Message, "Connection Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }
            catch (WCFClientBase.HttpUnauthorizedRequestException exception)
            {
                Logger.LogError("Cannot connect to Core server " + coreCreds.Hostname + " Wrong credentials.", coreCreds.Hostname, exception);
                MessageBox.Show("Cannot connect to Core server. Incorrect credentials." + Environment.NewLine + exception.Message, "Connection Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            timer1.Interval = 3000;     // Timer for UI update
            timer1.Start();


            // Hide Connection Page and displays ListView Page
            displayListViewPage();

            lbl_TotalAmountValue.Text = lv_AgentsList.Items.Count.ToString();         
        }

        private void lv_AgentsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Sort ListView by clicked column
            lvwColumnSorter.sortColumn(e, lv_AgentsList);
        }

        private void cb_selectAllAgents_CheckedChanged(object sender, EventArgs e)
        {
            // Check/Uncheck all agents
            ControlsImplementation.selectUnselectAll(lv_AgentsList, cb_selectAllAgents.Checked);
        }

        private void btn_StopDDT_Click(object sender, EventArgs e)
        {
            // Stop DDT for selected servers
            DDTWrapper.StopDDT(lv_AgentsList, ServerWrapper.serversList);

            // Update ListView
            ServerWrapper.UpdateListView(lv_AgentsList, lbl_ChangeRateValue, lbl_totalAgentsRunningValue);
        }

        private void btn_startDDT_Click(object sender, EventArgs e)
        {
            ddtParameters = new DDTParameters()
            {
                Filesize = Convert.ToInt32(tb_Size.Text),
                Compression = Convert.ToInt32(tb_Compression.Text),
                Interval = Convert.ToInt32(tb_Interval.Text),
                Filepath = tb_Path.Text
            };

            ddtParameters.SerizalizeDDTParamsToFile();

            // Start DDT for selected servers with specific parameters
            DDTWrapper.StartDDT(lv_AgentsList,
                            ServerWrapper.serversList,
                            ddtParameters);

            // Update ListView
            ServerWrapper.UpdateListView(lv_AgentsList, lbl_ChangeRateValue, lbl_totalAgentsRunningValue);

        }

        // This method displays controls for connection page
        public void displayConnectionPage()
        {
            ControlsImplementation.ChangePage(listviewPageControls, connectionPageControls);
        }

        // This method displays controls for ListView Page
        public void displayListViewPage()
        {
            ControlsImplementation.ChangePage(connectionPageControls, listviewPageControls);
        }

        // This method adds controls of Connection and ListView page to two separate collections
        private void AddControlsToCollections()
        {
            connectionPageControls = new List<Control>();
            listviewPageControls = new List<Control>();

            connectionPageControls.Add(tb_hostname);
            connectionPageControls.Add(tb_userName);
            connectionPageControls.Add(tb_password);
            connectionPageControls.Add(btn_Connect);
            connectionPageControls.Add(lbl_hostname);
            connectionPageControls.Add(lbl_username);
            connectionPageControls.Add(lbl_password);
            connectionPageControls.Add(tb_Port);
            connectionPageControls.Add(lbl_Port);

            listviewPageControls.Add(lv_AgentsList);
            listviewPageControls.Add(cb_selectAllAgents);
            listviewPageControls.Add(btn_StartDDT);
            listviewPageControls.Add(btn_StopDDT);
            listviewPageControls.Add(tb_Compression);
            listviewPageControls.Add(tb_Interval);
            listviewPageControls.Add(tb_Path);
            listviewPageControls.Add(tb_Size);
            listviewPageControls.Add(lbl_Compression);
            listviewPageControls.Add(lbl_Interval);
            listviewPageControls.Add(lbl_Path);
            listviewPageControls.Add(lbl_Size);
            listviewPageControls.Add(gb_ddtparams);
            listviewPageControls.Add(lbl_ChangeRateLabel);
            listviewPageControls.Add(lbl_ChangeRateValue);
            listviewPageControls.Add(lbl_totalAgentsRunninglabel);
            listviewPageControls.Add(lbl_totalAgentsRunningValue);
            listviewPageControls.Add(lbl_TotalAmountLabel);
            listviewPageControls.Add(lbl_TotalAmountValue);
        }

        private void GetCredsFromFileToGUI()
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
        }

        private void GetDDTParamsFromFileToGUI()
        {
            var ddtParams = DDTParameters.DeserializeDDTParamsFromFile();
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
    }
}
