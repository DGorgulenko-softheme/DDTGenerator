using Replay.Core.Contracts.Agents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    static class ServerWrapper
    {
        public static void ServersToListView(ListView listview, List<Server> serverList)
        {
            //username = tb_userName.Text;
            //password = tb_password.Text;
            //hostname = tb_serverName.Text;

            //AgentInfoCollection protectedAgents;
            //try
            //{
            //    protectedAgents = CoreConnector.GetProtectedAgents(hostname, 8006, username, password);
            //}
            //catch (WCFClientBase.ClientServerErrorException exception)
            //{
            //    Logger.Log("Cannot connect to Core server:" + hostname + Environment.NewLine + exception.Message
            //        + Environment.NewLine + exception.StackTrace, Logger.LogLevel.Error);
            //    MessageBox.Show("Cannot connect to Core server." + Environment.NewLine + exception.Message);

            //    return;
            //}

            //foreach (var agent in protectedAgents)
            //{
            //    if ((agent.AgentType != AgentType.EsxServer) && (agent.AgentType != AgentType.EsxVirtualMachine))
            //    {
            //        serversList.Add(new Server(agent.Descriptor.HostUri.Host, agent.DisplayName, agent.RepositoryName));
            //    }

            //}

            listview.Items.Clear();

            ListViewItem lvi_server;

            listview.View = View.Details;

            foreach (var server in serverList)
            {
                lvi_server = new ListViewItem(server._displayname);
                lvi_server.SubItems.Add(server._ip);
                lvi_server.SubItems.Add(server._repository);
                lvi_server.SubItems.Add(server._ddtStatus.ToString());
                lvi_server.SubItems.Add("");
                lvi_server.SubItems.Add("");
                lvi_server.SubItems.Add("");
                lvi_server.SubItems.Add("");
                listview.Items.Add(lvi_server);
            }
        }

        public static void UpdateListView(ListView listView, List<Server> serverList)
        {
            var listViewAgents = listView.Items.Cast<ListViewItem>().ToList();

            for (int i = 0; i < listViewAgents.Count; i++)
            {
                for (int j = 0; j < serverList.Count; j++)
                {
                    if (listViewAgents[i].SubItems[1].Text == serverList[j]._ip)
                    {
                        listViewAgents[i].SubItems[3].Text = serverList[j]._ddtStatus.ToString();   // DDT Status
                        listViewAgents[i].SubItems[4].Text = serverList[j]._fileSize.ToString();    // Filesize
                        listViewAgents[i].SubItems[5].Text = serverList[j]._compression.ToString(); // Compression
                        listViewAgents[i].SubItems[6].Text = serverList[j]._interval.ToString();    // Interval
                        listViewAgents[i].SubItems[7].Text = serverList[j].FilePath;                // Path
                    }
                }
            }
        }


    }
}
