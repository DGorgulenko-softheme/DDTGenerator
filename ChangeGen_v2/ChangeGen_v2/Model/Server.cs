using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    // This class represents the Server object, which used to store information about remote machine, parameters and current state of DDT
    class Server
    {
        public CancellationTokenSource _cts;                        // Cancelation token to cancel DDT operations on server
        public Task _task;                                          // Used to create separate async task for each server
        public string _ip;                                          // Server ip address
        public string _displayname;                                 // Server display name on Core if available
        public string _repository;                                  // Server repository on Core if available
        public DDTStatus _ddtStatus = DDTStatus.Stopped;            // Current status of DDT on server
        public ServerConnectionCredentials _serverCredentials;      // Server username and password for connection
        public DDTParameters _ddtParameters;                        // DDT Parameters for current server


        // This construcor is using when creating new instance using data from Core.
        public Server(string ip, string displayname, string repository)
        {
            _ip = ip;
            _displayname = displayname;
            _repository = repository;
        }


        // Enumaraion of possible status for DDT tool on server
        public enum DDTStatus
        {
            Running,
            Stopped,
            Failed
        }

        // Method used to run DDT on server side
        public void Runddt()
        {
            try
            {
                DDT.Runddtremotely(_ip, _serverCredentials, _ddtParameters, _cts.Token);
            }
            catch(COMException)
            {
                _ddtStatus = DDTStatus.Failed;
            }
            catch(System.UnauthorizedAccessException)
            {
                _ddtStatus = DDTStatus.Failed;
            }
            catch (IOException)
            {
                _ddtStatus = DDTStatus.Failed;
            }
        }
    }
}
