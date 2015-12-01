using Replay.Core.Client;
using Replay.Core.Contracts.Agents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    public partial class Form1 : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        List<Server> serversList;
        private List<Control> connectionPageControls;
        private List<Control> listviewPageControls;

        private string username, password, hostname;
        public Form1()
        {
            InitializeComponent();

            connectionPageControls = new List<Control>();
            listviewPageControls = new List<Control>();

            connectionPageControls.Add(tb_serverName);
            connectionPageControls.Add(tb_userName);
            connectionPageControls.Add(tb_password);
            connectionPageControls.Add(btn_Connect);
            connectionPageControls.Add(lbl_hostname);
            connectionPageControls.Add(lbl_username);
            connectionPageControls.Add(lbl_password);

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
            listviewPageControls.Add(lbl_customCreds);

            displayConnectionPage();

            lv_AgentsList.Columns.Add("     Display Name", 100);
            lv_AgentsList.Columns.Add("IP", 100);
            lv_AgentsList.Columns.Add("Repository", 100);
            lv_AgentsList.Columns.Add("DDT Status", 70);
            lv_AgentsList.Columns.Add("Filesize", 50);
            lv_AgentsList.Columns.Add("Compression", 75);
            lv_AgentsList.Columns.Add("Interval", 50);
            lv_AgentsList.Columns.Add("Path", 100);
            lv_AgentsList.CheckBoxes = true;

            lvwColumnSorter = new ListViewColumnSorter();
            this.lv_AgentsList.ListViewItemSorter = lvwColumnSorter;
        }

        private void btn_Connect_Click(object sender, EventArgs e)
        {
            username = tb_userName.Text;
            password = tb_password.Text;
            hostname = tb_serverName.Text;

            ServerWrapper.ServersToListView(lv_AgentsList, CoreConnector.GetServersToListFromCore(hostname, 8006, username, password, ref serversList));
            displayListViewPage();          
        }

        private void lv_AgentsList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvwColumnSorter.sortColumn(e, lv_AgentsList);
        }

        private void cb_selectAllAgents_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_selectAllAgents.Checked == true)
            {
                for (int i = 0; i < lv_AgentsList.Items.Count; i++)
                {
                    lv_AgentsList.Items[i].Checked = true;
                }
            }
            else
            {
                for (int i = 0; i < lv_AgentsList.Items.Count; i++)
                {
                    lv_AgentsList.Items[i].Checked = false;
                }
            }
        }

        private void btn_StopDDT_Click(object sender, EventArgs e)
        {
            DDTWrapper.StopDDT(lv_AgentsList, serversList);

            ServerWrapper.UpdateListView(lv_AgentsList,serversList);
        }

        private void btn_startDDT_Click(object sender, EventArgs e)
        {  
            int fileSize = Convert.ToInt32(tb_Size.Text);
            int compression = Convert.ToInt32(tb_Compression.Text);
            int interval = Convert.ToInt32(tb_Interval.Text);
            string filePath  = tb_Path.Text;
            string customUsername = tb_customUsername.Text;
            string customPassword = tb_customPassword.Text;
            bool useCoreCredentilas = cb_useCoreCreds.Checked;

            DDTWrapper.StartDDT(lv_AgentsList,serversList,fileSize,compression,interval,filePath,username,password,customUsername,customPassword,useCoreCredentilas);

            ServerWrapper.UpdateListView(lv_AgentsList, serversList);

        }

        public void displayConnectionPage()
        {
            foreach (var control in connectionPageControls)
            {
                control.Visible = true;
            }

            foreach (var control in listviewPageControls)
            {
                control.Visible = false;
            }
        }

        public void displayListViewPage()
        {
            foreach (var control in connectionPageControls)
            {
                control.Visible = false;
            }

            foreach (var control in listviewPageControls)
            {
                control.Visible = true;
            }
        }
    }
}
