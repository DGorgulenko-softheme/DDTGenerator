using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    class DDTWrapper
    {
        public static void StartDDT(ListView listview, List<Server> serversList, int filesize, int compression, int interval, string filepath, 
            string coreUsername, string corePassword, string customUsername, string customPassword, bool useCoreCreds)
        {
            var selectedServers = listview.Items.Cast<ListViewItem>().Where(item => item.Checked).ToList();

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


                        if (useCoreCreds)
                        {
                            serversList[y]._username = coreUsername;
                            serversList[y]._password = corePassword;
                        }
                        else
                        {
                            serversList[y]._username = customUsername;
                            serversList[y]._password = customPassword;
                        }

                        if (serversList[y]._task == null || serversList[y]._task.Status != TaskStatus.Running)
                        {
                            serversList[y]._task = new Task(() => serversList[index].Runddt());
                            serversList[y]._task.Start();
                        }
                    }
                }
            }
        }

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
                        selectedServers[x].SubItems[3].Text = "Stopped";
                    }
                }
            }
        }
    }
}
