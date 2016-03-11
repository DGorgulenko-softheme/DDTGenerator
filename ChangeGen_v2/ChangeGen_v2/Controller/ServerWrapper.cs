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
        public static List<SQLServer> SQLServersList; //store list of sql servers
        // This method displays servers received from Core API to ListView
        public static void ServersToListView(CoreConnectionCredentials coreCredentials)
        {
            ServersList = CoreConnector.GetServersToListFromCore(coreCredentials);
            ExchangeServersList = CoreConnector.GetExchangeServersToListFromCore(coreCredentials);
            SQLServersList = CoreConnector.GetSQLServersToListFromCore(coreCredentials);
        }

        public static void AddServerManually(string hostname, string username, string password)
        {
            if (ServersList == null)
                ServersList = new List<Server>();
            var alreadyAdded = ServersList.Any(server => server.ServerCredentials.Ip == hostname);

            if (!alreadyAdded)
                ServersList.Add(new Server(hostname, username, password));
        }

        public static void AddExchangeServerManually(string ip, string domain, string username, string password)
        {
            if (ExchangeServersList == null)
                ExchangeServersList = new List<ExchangeServer>();

            var alreadyAdded = ExchangeServersList.Any(server => server.ServerCredentials.Ip == ip);

            if (!alreadyAdded)
                ExchangeServersList.Add(new ExchangeServer(ip,domain,username,password));
        }

        public static void DeleteServerManually(ListView listView)
        {
            var selectedServers = listView.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList(); // Creating list of selected servers

            foreach (var selectedServer in selectedServers)
            {
                var sameServerInList =
                    ServersList.Find(server => server.ServerCredentials.Ip == selectedServer.SubItems[1].Text);
                sameServerInList.Cts?.Cancel();
                ServersList.Remove(sameServerInList);
                selectedServer.Remove();
            }
        }

        public static void DeleteExchangeServerManually(ListView listView)
        {
            var selectedServers = listView.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList(); // Creating list of selected servers

            foreach (var selectedServer in selectedServers)
            {
                var sameServerInList =
                    ExchangeServersList.Find(server => server.ServerCredentials.Ip == selectedServer.SubItems[1].Text);
                sameServerInList.Cts?.Cancel();
                ExchangeServersList.Remove(sameServerInList);
                selectedServer.Remove();
            }
        }

        // This method updates ListView with current state of each server
        public static void UpdateListView(ListView serverslistView, Label expectedRateLabel, Label amountOfActiveGeneraionsLabel)
        {
            if (ServersList != null)
            {
                var listViewAgents = serverslistView.Items.Cast<ListViewItem>().ToList();

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
                        AddNewServerToListView(serverslistView, server);
                }
                UpdateExpectedChangeRateAndAmountOfActiveGenerations(listViewAgents, expectedRateLabel, amountOfActiveGeneraionsLabel);
            }       
        }

        public static void UpdateExchangeListView(ListView exchangelistView, Label amountOfActiveGeneration)
        {
            if (ExchangeServersList != null)
            {
                var listViewAgents = exchangelistView.Items.Cast<ListViewItem>().ToList();

                foreach (var server in ExchangeServersList)
                {
                    bool isNew = true;
                    foreach (var lvServer in listViewAgents)
                    {
                        if (lvServer.SubItems[1].Text == server.ServerCredentials.Ip)
                        {
                            isNew = false;
                            lvServer.SubItems[3].Text = server.ServerGeneratorStatus.ToString();   // Generator Status
                            lvServer.SubItems[4].Text = server.ExchangeGenParameters?.MessageSize.ToString() ?? ""; //Mail Size
                        }                       
                    }
                    if (isNew)
                        AddNewExchangeServerToListView(exchangelistView,server);
                }
                UpdateAmountOfActiveExchangeGenerations(listViewAgents, amountOfActiveGeneration);
            }
        }

        public static void UpdateSQLListView(ListView sqllistView, Label amountOfActiveGeneration)
        {
            if (SQLServersList != null)
            {
                var listViewAgents = sqllistView.Items.Cast<ListViewItem>().ToList();

                foreach (var server in SQLServersList)
                {
                    bool isNew = true;
                    foreach (var lvServer in listViewAgents)
                    {
                        if (lvServer.SubItems[1].Text == server.ServerCredentials.Ip)
                        {
                            isNew = false;
                            lvServer.SubItems[3].Text = server.ServerGeneratorStatus.ToString();   // Generator Status
                            lvServer.SubItems[4].Text = server.SqlGeneratorParameters?.RowsToInsert.ToString() ?? ""; //Mail Size
                        }
                    }
                    if (isNew)
                        AddNewSQLServerToListView(sqllistView, server);
                }
                UpdateAmountOfActiveSQLGenerations(listViewAgents, amountOfActiveGeneration);
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

        private static void AddNewExchangeServerToListView(ListView listView, ExchangeServer server)
        {
            var lviNewServer = new ListViewItem(server.DisplayName);
            lviNewServer.SubItems.Add(server.ServerCredentials.Ip);
            lviNewServer.SubItems.Add(server.Repository);
            lviNewServer.SubItems.Add(server.ServerGeneratorStatus.ToString());
            lviNewServer.SubItems.Add(server.ExchangeGenParameters?.MessageSize.ToString() ?? "");
            listView.Items.Add(lviNewServer);
        }

        private static void AddNewSQLServerToListView(ListView listView, SQLServer server)
        {
            var lviNewServer = new ListViewItem(server.DisplayName);
            lviNewServer.SubItems.Add(server.ServerCredentials.Ip);
            lviNewServer.SubItems.Add(server.Repository);
            lviNewServer.SubItems.Add(server.ServerGeneratorStatus.ToString());
            lviNewServer.SubItems.Add(server.SqlGeneratorParameters?.RowsToInsert.ToString() ?? "");
            listView.Items.Add(lviNewServer);
        }

        private static void UpdateAmountOfActiveExchangeGenerations(IEnumerable<ListViewItem> listViewAgents,
            Control amountOfActiveGenerationsLabel)
        {
            var amountOfActiveExchangeGenerations = listViewAgents.Count(server => server.SubItems[3].Text == "Running");
            amountOfActiveGenerationsLabel.Text = amountOfActiveExchangeGenerations.ToString();
        }

        private static void UpdateAmountOfActiveSQLGenerations(IEnumerable<ListViewItem> listViewAgents,
           Control amountOfActiveGenerationsLabel)
        {
            var amountOfActiveExchangeGenerations = listViewAgents.Count(server => server.SubItems[3].Text == "Running");
            amountOfActiveGenerationsLabel.Text = amountOfActiveExchangeGenerations.ToString();
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
            expectedRateLabel.Text = Math.Round(expectedChRate,2).ToString();
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

        public static void ExchangeListViewCreateColumns(ListView listview)
        {
            listview.Columns.Add("     Display Name", 100);
            listview.Columns.Add("IP", 100);
            listview.Columns.Add("Repository", 100);
            listview.Columns.Add("Generation Status", 100);
            listview.Columns.Add("Message Size", 80);
            listview.CheckBoxes = true;
        }

        public static void SQLListViewCreateColumns(ListView listview)
        {
            listview.Columns.Add("     Display Name", 100);
            listview.Columns.Add("IP", 100);
            listview.Columns.Add("Repository", 100);
            listview.Columns.Add("Generation Status", 100);
            listview.Columns.Add("Rows to Insert", 100);
            listview.CheckBoxes = true;
        }
    }
}
