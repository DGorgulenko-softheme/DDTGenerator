using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    // This class store methods which update ListView with servers current state
    static class ServerWrapper
    {
        public static List<Server> serversList; // store list of servers

        // This method displays servers received from Core API to ListView
        public static void ServersToListView(ListView listview, CoreConnectionCredentials coreCredentials)
        {

            serversList = CoreConnector.GetServersToListFromCore(coreCredentials);
              
            ListViewCreateColumns(listview);

            listview.Items.Clear();

            ListViewItem lvi_server;

            listview.View = View.Details;

            foreach (var server in serversList)
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

        // This method updates ListView with current state of each server
        public static void UpdateListView(ListView listView)
        {
            var listViewAgents = listView.Items.Cast<ListViewItem>().ToList();

            for (int i = 0; i < listViewAgents.Count; i++)
            {
                for (int j = 0; j < serversList.Count; j++)
                {
                    if (listViewAgents[i].SubItems[1].Text == serversList[j]._ip)
                    {
                        listViewAgents[i].SubItems[3].Text = serversList[j]._ddtStatus.ToString();   // DDT Status
                        if(serversList[j]._ddtParameters == null)
                        {
                            break;
                        }
                        else
                        {
                            listViewAgents[i].SubItems[4].Text = serversList[j]._ddtParameters.Filesize.ToString();   // Filesize
                            listViewAgents[i].SubItems[5].Text = serversList[j]._ddtParameters.Compression.ToString(); // Compression
                            listViewAgents[i].SubItems[6].Text = serversList[j]._ddtParameters.Interval.ToString();    // Interval
                            listViewAgents[i].SubItems[7].Text = serversList[j]._ddtParameters.Filepath;               // Path
                        }                       
                    }
                }
            }
        }

        // This method used to create columns in ListView
        private static void ListViewCreateColumns(ListView listview)
        {
            listview.Columns.Add("     Display Name", 100);
            listview.Columns.Add("IP", 100);
            listview.Columns.Add("Repository", 100);
            listview.Columns.Add("DDT Status", 70);
            listview.Columns.Add("Filesize", 50);
            listview.Columns.Add("Compression", 75);
            listview.Columns.Add("Interval", 50);
            listview.Columns.Add("Path", 100);
            listview.CheckBoxes = true;
        }

       


    }
}
