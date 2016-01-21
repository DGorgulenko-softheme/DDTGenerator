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
        public static ICoreClient GetDefaultCoreClient(CoreConnectionCredentials coreCredentials)
        {
            var coreClientFactory = new CoreClientFactory();

            var coreClient = coreClientFactory.Create(CreateApiUri(coreCredentials.Hostname, coreCredentials.Port));
            coreClient.UseDefaultCredentials();

            return coreClient;
        }

        // This method is used to connect to Core API with specific credentials
        public static ICoreClient GetFullCoreClient(CoreConnectionCredentials coreCredentials)
        {
            var networkCreds = new NetworkCredential(coreCredentials.Username, coreCredentials.Password);
            var factory = new CoreClientFactory();
            var coreClient = factory.Create(CreateApiUri(coreCredentials.Hostname, coreCredentials.Port));
            coreClient.UseSpecificCredentials(networkCreds);

            return coreClient;
        }

        //This method returns collection of Agent's objects
        public static List<Server> GetServersToListFromCore(CoreConnectionCredentials coreCredentials)
        {
            List<Server> serversList = new List<Server>();
            ICoreClient _coreClient = CoreConnector.GetFullCoreClient(coreCredentials);

            var protectedAgents = _coreClient.AgentsManagement.GetProtectedAgents();
           

            foreach (var agent in protectedAgents)
            {
                if ((agent.AgentType != AgentType.EsxServer) && (agent.AgentType != AgentType.EsxVirtualMachine))
                {
                    // This to hide linux agents from GUI, but it is dramatically reduce performance
                    //if (!_coreClient.AgentsManagement.GetAgentMetadataById(agent.Id.ToString()).OSVersion.ToString().Contains("Linux"))   
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
