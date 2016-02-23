using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    class ExchangeGenWrapper
    {
        // This method used to initiate start of DDT on remote machine
        public static void StartExchangeGenerator(ListView listview, List<ExchangeServer> serversList)
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
                    serversList[y].Task = new Task(() => serversList[index].StartExchangeGenerator());
                    serversList[y].Task.Start();
                }
            }
        }

        // Cancel DDT for selected server
        public static void StopExchangeGenerator(ListView listview, List<ExchangeServer> serversList)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList();

            foreach (var server in selectedServers)
            {
                foreach (var exchangeServer in serversList)
                {
                    if (server.SubItems[1].Text != exchangeServer.ServerCredentials.Ip) continue;

                    exchangeServer.ServerGeneratorStatus = Server.GeneratorStatus.Stopped;
                    exchangeServer.Cts.Cancel();
                }
            }
        }
    }
}
