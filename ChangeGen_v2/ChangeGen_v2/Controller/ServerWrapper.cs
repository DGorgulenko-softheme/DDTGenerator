using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    // This class store methods which update ListView with servers current state
    internal static class ServerWrapper
    {
        public static List<Server> ServersList; // store list of servers
        public static List<ExchangeServer> ExchangeServersList; //store list of exchange servers 

        // This method displays servers received from Core API to ListView
        public static void ServersToListView(ListView serverslistview, ListView exchangeServersListView, CoreConnectionCredentials coreCredentials)
        {

            ServersList = CoreConnector.GetServersToListFromCore(coreCredentials);

            ExchangeServersList = CoreConnector.GetExchangeServersToListFromCore(coreCredentials);

            ExchangeListViewCreateColumns(exchangeServersListView);
            exchangeServersListView.Items.Clear();
            exchangeServersListView.View = View.Details;

            foreach (var server in ExchangeServersList)
            {
                var lviServer = new ListViewItem(server.DisplayName);
                lviServer.SubItems.Add(server.ServerCredentials.Ip);
                lviServer.SubItems.Add(server.Repository);
                lviServer.SubItems.Add(server.ServerGeneratorStatus.ToString());
                lviServer.SubItems.Add("");
                exchangeServersListView.Items.Add(lviServer);
            }
        }

        public static void AddServerManually(string hostname, string username, string password)
        {
            if (ServersList == null)
                ServersList = new List<Server>();
            ServersList.Add(new Server(hostname, username, password));
        }

        // This method updates ListView with current state of each server
        public static void UpdateListView(ListView listView, Label expectedRateLabel, Label amountOfActiveGeneraionsLabel)
        {
            if (ServersList != null)
            {
                var listViewAgents = listView.Items.Cast<ListViewItem>().ToList();

                foreach (var server in ServersList)
                {
                    bool isNew = true;
                    foreach (var lvServer in listViewAgents)
                    {
                        if (lvServer.SubItems[1].Text == server.ServerCredentials.Ip)
                        {
                            isNew = false;
                            lvServer.SubItems[3].Text = server.ServerGeneratorStatus.ToString();   // DDT Status
                            lvServer.SubItems[4].Text = server.DdtParameters?.Filesize.ToString() ?? "";   // Filesize  
                            lvServer.SubItems[5].Text = server.DdtParameters?.Compression.ToString() ?? ""; // Compression
                            lvServer.SubItems[6].Text = server.DdtParameters?.Interval.ToString() ?? "";    // Interval
                            lvServer.SubItems[7].Text = server.DdtParameters?.Filepath ?? "";               // Path
                        }
                    }
                    if (isNew)
                        AddNewServerToListView(listView, server);
                }

                UpdateExpectedChangeRateAndAmountOfActiveGenerations(listViewAgents, expectedRateLabel, amountOfActiveGeneraionsLabel);
            }       
        }

        private static void AddNewServerToListView(ListView listView, Server server)
        {
            var lviNewServer = new ListViewItem(server.DisplayName);
            lviNewServer.SubItems.Add(server.ServerCredentials.Ip);
            lviNewServer.SubItems.Add(server.Repository);
            lviNewServer.SubItems.Add(server.ServerGeneratorStatus.ToString());
            lviNewServer.SubItems.Add(server.DdtParameters?.Filesize.ToString() ?? "");
            lviNewServer.SubItems.Add(server.DdtParameters?.Compression.ToString() ?? "");
            lviNewServer.SubItems.Add(server.DdtParameters?.Interval.ToString() ?? "");
            lviNewServer.SubItems.Add(server.DdtParameters?.Filepath ?? "");
            listView.Items.Add(lviNewServer);
        }

        public static void UpdateExchangeListView(ListView listView)
        {
            var listViewAgents = listView.Items.Cast<ListViewItem>().ToList();

            foreach (var agent in listViewAgents)
            {
                foreach (var server in ExchangeServersList.Where(server => agent.SubItems[1].Text == server.ServerCredentials.Ip))
                {
                    agent.SubItems[3].Text = server.ServerGeneratorStatus.ToString();   // DDT Status
                    if (server.ExchangeGenParameters.MessageSize != 0)
                        agent.SubItems[4].Text = server.ExchangeGenParameters.MessageSize.ToString();
                }
            }
        }

        private static void UpdateExpectedChangeRateAndAmountOfActiveGenerations(IEnumerable<ListViewItem> listViewAgents, Control expectedRateLabel, Control amountOfRunningLabel)
        {
            double expectedChRate = 0;
            var amountOfActiveGenerations = 0;
            foreach (var agent in listViewAgents.Where(agent => agent.SubItems[3].Text == "Running"))
            {
                expectedChRate += Convert.ToDouble(agent.SubItems[4].Text) / Convert.ToDouble(agent.SubItems[6].Text) * 60.0 / 1024.0;
                amountOfActiveGenerations += 1;
            }

            expectedRateLabel.Text = expectedChRate.ToString();
            amountOfRunningLabel.Text = amountOfActiveGenerations.ToString();
        }

        // This method used to create columns in ListView
        public static void ServersListViewCreateColumns(ListView listview)
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

        private static void ExchangeListViewCreateColumns(ListView listview)
        {
            listview.Columns.Add("     Display Name", 100);
            listview.Columns.Add("IP", 100);
            listview.Columns.Add("Repository", 100);
            listview.Columns.Add("Generation Status", 100);
            listview.Columns.Add("Message Size", 80);
            listview.CheckBoxes = true;
        }
    }
}
