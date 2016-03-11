using Replay.Core.Client;
using Replay.Core.Contracts.Agents;
using Replay.ServiceHost.Contracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;

namespace ChangeGen_v2
{
    // This class represents the object which used to connect to Core API anrd retrieve info about Agent's machines
    internal static class CoreConnector
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
        private static ICoreClient GetFullCoreClient(CoreConnectionCredentials coreCredentials)
        {
            var networkCreds = new NetworkCredential(coreCredentials.Username, coreCredentials.Password);
            var factory = new CoreClientFactory();
            var coreClient = factory.Create(CreateApiUri(coreCredentials.Hostname, coreCredentials.Port));
            coreClient.UseSpecificCredentials(networkCreds);

            return coreClient;
        }

        //This method returns collection of all Agent's objects
        public static List<Server> GetServersToListFromCore(CoreConnectionCredentials coreCredentials)
        {
            var serversList = new List<Server>();
            var coreClient = GetFullCoreClient(coreCredentials);
            var protectedAgents = coreClient.AgentsManagement.GetProtectedAgents();
           
            foreach (var agent in protectedAgents)
            {
                if ((agent.AgentType != AgentType.EsxServer) && (agent.AgentType != AgentType.EsxVirtualMachine))
                {
                    serversList.Add(new Server(agent.Descriptor.HostUri.Host, agent.DisplayName, agent.RepositoryName, 
                    agent.Descriptor.MetadataCredentials.DefaultCredentials.UserName, agent.Descriptor.MetadataCredentials.DefaultCredentials.PasswordDecrypted));
                }
                //MessageBox.Show(
                //   coreClient.AgentsManagement.GetAgentMetadataById(agent.Id.ToString()).IPAddresses.Count.ToString());
            }
            return serversList;
        }

        //This method returns collection of Agent's objects with Exchange Server only
        public static List<ExchangeServer> GetExchangeServersToListFromCore(CoreConnectionCredentials coreCredentials)
        {
            var exchangeServersList = new List<ExchangeServer>();
            var coreClient = CoreConnector.GetFullCoreClient(coreCredentials);
            var protectedAgents = coreClient.AgentsManagement.GetProtectedAgents();

            foreach (var agent in protectedAgents)
            {
                if ((agent.AgentType != AgentType.EsxServer) && (agent.AgentType != AgentType.EsxVirtualMachine) && agent.HasExchangeInstance)
                {
                    exchangeServersList.Add(new ExchangeServer(agent.Descriptor.HostUri.Host, agent.DisplayName,
                        agent.RepositoryName,
                        agent.Descriptor.MetadataCredentials.DefaultCredentials.UserName,
                        coreClient.AgentsManagement.GetCachedAgentMetadataById(agent.Id.ToString()).FullyQualifiedDomainName.Remove(0, coreClient.AgentsManagement.GetCachedAgentMetadataById(agent.Id.ToString()).HostName.Length + 1),
                        agent.Descriptor.MetadataCredentials.DefaultCredentials.PasswordDecrypted));
                }
               
            }
            return exchangeServersList;
        }

        //This method returns collection of Agent's objects with SQL Server only
        public static List<SQLServer> GetSQLServersToListFromCore(CoreConnectionCredentials coreCredentials)
        {
            var sqlServersList = new List<SQLServer>();
            var coreClient = CoreConnector.GetFullCoreClient(coreCredentials);
            var protectedAgents = coreClient.AgentsManagement.GetProtectedAgents();

            foreach (var agent in protectedAgents)
            {
                if ((agent.AgentType != AgentType.EsxServer) && (agent.AgentType != AgentType.EsxVirtualMachine) && agent.HasSqlInstance)
                {
                    sqlServersList.Add(new SQLServer(agent.Descriptor.HostUri.Host, agent.DisplayName,
                        agent.RepositoryName,
                        agent.Descriptor.MetadataCredentials.DefaultCredentials.UserName,
                        agent.Descriptor.MetadataCredentials.DefaultCredentials.PasswordDecrypted));
                }

            }
            return sqlServersList;
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
