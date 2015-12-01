using Replay.Core.Client;
using Replay.Core.Contracts.Agents;
using Replay.ServiceHost.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Windows.Forms;

namespace ChangeGen_v2
{
    // This class represents the object which used to connect to Core API anrd retrieve info about Agent's machines
    static class CoreConnector
    {
        // This method used to connect to Core API with creds from current active seesion
        public static ICoreClient GetDefaultCoreClient(string hostname, int port)
        {
            var coreClientFactory = new CoreClientFactory();

            var coreClient = coreClientFactory.Create(CreateApiUri(hostname, port));
            coreClient.UseDefaultCredentials();

            return coreClient;
        }

        // This method is used to connect to Core API with specific credentials
        public static ICoreClient GetFullCoreClient(string hostname, int port, string username, string password)
        {
            var networkCreds = new NetworkCredential(username, password);
            var factory = new CoreClientFactory();
            var coreClient = factory.Create(CreateApiUri(hostname, port));
            coreClient.UseSpecificCredentials(networkCreds);

            return coreClient;
        }

        //This method returns collection of Agent's objects
        public static List<Server> GetServersToListFromCore(string hostname, int port, string username, string password)
        {
            List<Server> serversList = new List<Server>();
            ICoreClient _coreClient = CoreConnector.GetFullCoreClient(hostname, port, username, password);
           
            var  protectedAgents = _coreClient.AgentsManagement.GetProtectedAgents();
            Logger.Log("Successfully connected to Core Server: " + hostname, Logger.LogLevel.Info, hostname);
           

            foreach (var agent in protectedAgents)
            {
                if ((agent.AgentType != AgentType.EsxServer) && (agent.AgentType != AgentType.EsxVirtualMachine))
                {
                    serversList.Add(new Server(agent.Descriptor.HostUri.Host, agent.DisplayName, agent.RepositoryName));
                }

            }

            return serversList;
        }

        // This method creats url for Core API
        private static Uri CreateApiUri(string host, int port)
        {
            var apiUri = string.Format(
                                        CultureInfo.InvariantCulture,
                                        "https://{0}:{1}/{2}/api/core/",
                                        host,
                                        port,
                                        ServiceHostConstants.RootOfServiceHostAddress);

            return new Uri(apiUri);
        }
    }
}
