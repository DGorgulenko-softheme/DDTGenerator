using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    class DDTWrapper
    {
        // This method used to initiate start of DDT on remote machine
        public static void StartDDT(ListView listview, List<Server> serversList, DDTParameters ddtparameters)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList(); // Creating list of selected servers

            for (int x = 0; x < selectedServers.Count; x++)
            {
                for (int y = 0; y < serversList.Count; y++)
                {
                    if (selectedServers[x].SubItems[1].Text == serversList[y].ServerCredentials.IP)
                    {
                        int index = y;

                        if (serversList[y].Task != null)
                        {
                            serversList[y].CTS.Cancel();
                        }

                        serversList[y].DdtStatus = Server.DDTStatus.Running;
                        serversList[y].CTS = new CancellationTokenSource();
                        serversList[y].DdtParameters = ddtparameters;
                     
                        serversList[y].Task = new Task(() => serversList[index].Runddt());
                        serversList[y].Task.Start();

                    }
                }
            }
        }

        // Cancel DDT for selected server
        public static void StopDDT(ListView listview, List<Server> serversList)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList();

            for (int x = 0; x < selectedServers.Count; x++)
            {
                for (int y = 0; y < serversList.Count; y++)
                {
                    if (selectedServers[x].SubItems[1].Text == serversList[y].ServerCredentials.IP)
                    {
                        int index = y;

                        serversList[y].DdtStatus = Server.DDTStatus.Stopped;
                        serversList[y].CTS.Cancel();
                    }
                }
            }
        }
    }
}
