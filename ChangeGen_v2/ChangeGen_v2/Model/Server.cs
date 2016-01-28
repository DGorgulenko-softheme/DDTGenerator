using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    // This class represents the Server object, which used to store information about remote machine, parameters and current state of DDT
    class Server
    {
        // Cancelation token to cancel DDT operations on server
        public CancellationTokenSource CTS { get; set; }

        // Used to create separate async task for each server
        public Task Task { get; set; }

        // Server display name on Core if available
        public string DisplayName { get; set; }

        // Server repository on Core if available
        public string Repository { get; set; }

        // Current status of DDT on server
        public DDTStatus DdtStatus { get; set; } = DDTStatus.Stopped;

        // Server username and password for connection
        public ServerConnectionCredentials ServerCredentials { get; set; }

        // DDT Parameters for current server
        public DDTParameters DdtParameters { get; set; }

        // This construcor is using when creating new instance using data from Core.
        public Server(string ip, string displayname, string repository, string username, string password)
        {
            DisplayName = displayname;
            Repository = repository;
            ServerCredentials = new ServerConnectionCredentials();
            ServerCredentials.Username = username;
            ServerCredentials.Password = password;
            ServerCredentials.IP = ip;
        }

        // Enumeraion of possible status for DDT tool on server
        public enum DDTStatus
        {
            Failed,
            Running,
            Stopped,
            WrongCredentials      
        }

        // Method used to run DDT on server side
        public void Runddt()
        {
            try
            {
                //DDT.Runddtremotely(IP, ServerCredentials, DdtParameters, CTS.Token);
                DDT.Runddtremotely(ServerCredentials, DdtParameters, CTS.Token);

            }
            catch(COMException)
            {
                DdtStatus = DDTStatus.Failed;
            }
            catch(System.UnauthorizedAccessException)
            {
                DdtStatus = DDTStatus.WrongCredentials;
            }
            catch (IOException)
            {
                DdtStatus = DDTStatus.Failed;
            }
        }
    }
}
