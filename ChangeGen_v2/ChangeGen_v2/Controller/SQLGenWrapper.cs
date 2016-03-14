using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    internal static class SqlGenWrapper
    {
        public static bool DoNotShowSqlPrerequisites;
        // This method used to initiate start of DDT on remote machine
        public static void StartSqlGenerator(ListView listview, List<SqlServer> serversList, string dbName, int rowsToInsert)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList(); // Creating list of selected servers

            foreach (var server in selectedServers)
            {
                for (var y = 0; y < serversList.Count; y++)
                {
                    if (server.SubItems[1].Text != serversList[y].ServerCredentials.Ip) continue;
                    var index = y;

                    if (serversList[y].Task != null)
                    {
                        serversList[y].Cts.Cancel();
                    }

                    serversList[y].ServerGeneratorStatus = Server.GeneratorStatus.Running;
                    serversList[y].SqlGeneratorParameters.DbName = dbName;
                    serversList[y].SqlGeneratorParameters.RowsToInsert = rowsToInsert;
                    serversList[y].Cts = new CancellationTokenSource();
                    serversList[y].Task = new Task(() => serversList[index].StartSqlGenerator());
                    serversList[y].Task.Start();
                }
            }
        }

        public static void StartSqlGenerator(ListView listview, List<SqlServer> serversList, string dbName,
            int rowsToInser, string username, string password)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList(); // Creating list of selected servers

            foreach (var server in selectedServers)
            {
                foreach (var t in serversList)
                {
                    if (server.SubItems[1].Text != t.ServerCredentials.Ip) continue;

                    t.ServerCredentials.Username = username;
                    t.ServerCredentials.Password = password;
                }
            }

            StartSqlGenerator(listview, serversList, dbName, rowsToInser);
        }

        // Cancel DDT for selected server
        public static void StopSqlGenerator(ListView listview, List<SqlServer> serversList)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList();

            foreach (var server in selectedServers)
            {
                foreach (var sqlServer in serversList)
                {
                    if (server.SubItems[1].Text != sqlServer.ServerCredentials.Ip) continue;

                    Logger.Log("SQL generation has been canceled by user.", Logger.LogLevel.Info, sqlServer.ServerCredentials.Ip);
                    sqlServer.ServerGeneratorStatus = Server.GeneratorStatus.Stopped;
                    sqlServer.Cts.Cancel();
                }
            }
        }
    }
}
