using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    internal class DdtWrapper
    {
        // This method used to initiate start of DDT on remote machine
        public static void StartDdt(ListView listview, List<Server> serversList, DdtParameters ddtparameters)
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
                    serversList[y].Cts = new CancellationTokenSource();
                    serversList[y].DdtParameters = ddtparameters;
                     
                    serversList[y].Task = new Task(() => serversList[index].Runddt());
                    serversList[y].Task.Start();
                }
            }
        }

        public static void StartDdt(ListView listview, List<Server> serversList, DdtParameters ddtparameters, string username, string password)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList(); // Creating list of selected servers

            foreach (var server in selectedServers)
            {
                foreach (Server t in serversList)
                {
                    if (server.SubItems[1].Text != t.ServerCredentials.Ip) continue;

                    t.ServerCredentials.Username = username;
                    t.ServerCredentials.Password = password;
                }
            }

            StartDdt(listview,serversList,ddtparameters);
        }



        // Cancel DDT for selected server
        public static void StopDdt(ListView listview, List<Server> serversList)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList();

            foreach (var server in selectedServers)
            {
                foreach (var agent in serversList)
                {
                    if (server.SubItems[1].Text != agent.ServerCredentials.Ip) continue;

                    Logger.Log("Data generation has been canceled by user.", Logger.LogLevel.Info, agent.ServerCredentials.Ip);
                    agent.ServerGeneratorStatus = Server.GeneratorStatus.Stopped;
                    agent.Cts.Cancel();
                }
            }
        }
    }
}
