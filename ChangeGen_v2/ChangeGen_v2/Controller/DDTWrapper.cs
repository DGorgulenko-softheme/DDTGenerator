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
        public static void StartDDT(ListView listview, List<Server> serversList, int filesize, int compression, int interval, string filepath, 
            string username, string password)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList(); // Creating list of selected servers

            for (int x = 0; x < selectedServers.Count; x++)    
            {
                for (int y = 0; y < serversList.Count; y++)
                {
                    if (selectedServers[x].SubItems[1].Text == serversList[y]._ip)
                    {
                        int index = y;

                        serversList[y]._fileSize = filesize;
                        serversList[y]._compression = compression;
                        serversList[y]._interval = interval;
                        serversList[y].FilePath = filepath;
                        serversList[y]._ddtStatus = Server.DDTStatus.Running;
                        serversList[y]._cts = new CancellationTokenSource();
                        serversList[y]._username = username;
                        serversList[y]._password = password;
                       

                        if (serversList[y]._task == null || serversList[y]._task.Status != TaskStatus.Running)
                        {
                            serversList[y]._task = new Task(() => serversList[index].Runddt());
                            serversList[y]._task.Start();
                        }
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
                    if (selectedServers[x].SubItems[1].Text == serversList[y]._ip)
                    {
                        int index = y;

                        serversList[y]._ddtStatus = Server.DDTStatus.Stopped;
                        serversList[y]._cts.Cancel();
                    }
                }
            }
        }
    }
}
