using Microsoft.Exchange.WebServices.Data;

namespace ChangeGen_v2
{
    internal class ExchangeServer : Server
    {
        public ExchangeGeneratorParameters ExchangeGenParameters { get; set; }
        public ExchangeServer(string ip, string displayname, string repository, string username, string password) : base(ip, displayname, repository, username, password)
        {
        }

        public void StartExchangeGenerator()
        {
            try
            {
                ExchangeGenerator.StartGenerator(ServerCredentials, ExchangeGenParameters, Cts.Token);
            }
            catch (ServiceRequestException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
            }
            catch (ServiceResponseException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
            }
        }
    }
}
