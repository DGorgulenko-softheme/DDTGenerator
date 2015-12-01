using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class Form1 : Form
    {
        ListViewColumnSorter lvwColumnSorter;           // used for storing instance of column sorter object
        private List<Control> connectionPageControls;   // used for storing controls of Connection page
        private List<Control> listviewPageControls;     // used for storing controls of ListView page

        public Form1()
        {
            InitializeComponent();

            AddControlsToCollections();
            displayConnectionPage();

            lvwColumnSorter = new ListViewColumnSorter();
            this.lv_AgentsList.ListViewItemSorter = lvwColumnSorter;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            // Displays list of servers received from Core API to ListView
            try
            {
                ServerWrapper.ServersToListView(lv_AgentsList,
                                            tb_hostname.Text,
                                            Convert.ToInt32(tb_Port.Text),
                                            tb_userName.Text,
                                            tb_password.Text);
                Logger.Log("Successfully connected to Core Server: " + tb_hostname.Text, Logger.LogLevel.Info, tb_hostname.Text);
            }
            catch (WCFClientBase.ClientServerErrorException exception)
            {
                Logger.Log("Cannot connect to Core server:" + tb_hostname.Text + Environment.NewLine + exception.Message
                    + Environment.NewLine + exception.StackTrace, Logger.LogLevel.Error);
                MessageBox.Show("Cannot connect to Core server." + Environment.NewLine + exception.Message);

                return;
            }


            // Hide Connection Page and displays ListView Page
            displayListViewPage();          
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
            ServerWrapper.UpdateListView(lv_AgentsList);
        }

        private void btn_startDDT_Click(object sender, EventArgs e)
        {
            // checking if checkbox "Use Core credentials" checked,
            // if so using core credentils to connect to each server,
            // if no using custom credentials.

            string username;
            string password;

            if (cb_useCoreCreds.Checked)
            {
                username = tb_userName.Text;
                password = tb_password.Text;
            }
            else
            {
                username = tb_customUsername.Text;
                password = tb_customPassword.Text;
            }

            // Start DDT for selected servers with specific parameters
            DDTWrapper.StartDDT(lv_AgentsList,
                                ServerWrapper.serversList,
                                Convert.ToInt32(tb_Size.Text),
                                Convert.ToInt32(tb_Compression.Text),
                                Convert.ToInt32(tb_Interval.Text), tb_Path.Text,
                                username,
                                password);
            // Update ListView
            ServerWrapper.UpdateListView(lv_AgentsList);

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

        // This methdo add controls of Connection and ListView page to two separate collections
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
            listviewPageControls.Add(cb_useCoreCreds);
            listviewPageControls.Add(lbl_customUsername);
            listviewPageControls.Add(tb_customUsername);
            listviewPageControls.Add(lbl_customPassword);
            listviewPageControls.Add(tb_customPassword);
            listviewPageControls.Add(gb_customcreds);
            listviewPageControls.Add(gb_ddtparams);
        }
    }
}
