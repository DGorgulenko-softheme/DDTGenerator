using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ChangeGen_v2
{
    // This class represents the Server object, which used to store information about remote machine, parameters and current state of DDT
    internal class Server
    {
        // Cancelation token to cancel DDT operations on server
        public CancellationTokenSource Cts { get; set; }

        // Used to create separate async task for each server
        public Task Task { get; set; }

        // Server display name on Core if available
        public string DisplayName { get; set; }

        // Server repository on Core if available
        public string Repository { get; set; }

        // Current status of DDT on server
        public GeneratorStatus ServerGeneratorStatus { get; set; } = GeneratorStatus.Stopped;

        // Server username and password for connection
        public ServerConnectionCredentials ServerCredentials { get; set; }

        // DDT Parameters for current server
        public DdtParameters DdtParameters { get; set; }

        // This constructor is using when creating new instance using data from Core.
        public Server(string ip, string displayname, string repository, string username, string password)
        {
            DisplayName = displayname;
            Repository = repository;
            ServerCredentials = new ServerConnectionCredentials
            {
                Username = username,
                Password = password,
                Ip = ip
            };
        }

        public Server(string ip, string username, string password)
        {
            ServerCredentials = new ServerConnectionCredentials
            {
                Username = username,
                Password = password,
                Ip = ip
            };
        }

        // Enumeration of possible status for DDT tool on server
        public enum GeneratorStatus
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
                Ddt.Runddtremotely(ServerCredentials, DdtParameters, Cts.Token);
            }
            catch(COMException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
            }
            catch(System.UnauthorizedAccessException)
            {
                ServerGeneratorStatus = GeneratorStatus.WrongCredentials;
            }
            catch (IOException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
            }
        }
    }
}
