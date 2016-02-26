using Microsoft.Exchange.WebServices.Data;

namespace ChangeGen_v2
{
    internal class ExchangeServer : Server
    {
        public ExchangeGeneratorParameters ExchangeGenParameters { get; set; }
        public ExchangeServer(string ip, string displayname, string repository, string username, string password) : base(ip, displayname, repository, username, password)
        {
        }

        public ExchangeServer(string ip, string domain, string username, string password) : base(ip, username, password)
        {
            if (ExchangeGenParameters == null)
                ExchangeGenParameters = new ExchangeGeneratorParameters();
            ExchangeGenParameters.Recipient = username + '@' + domain;
        }

        public void StartExchangeGenerator()
        {
            try
            {
                ExchangeGenerator.StartGenerator(ServerCredentials, ExchangeGenParameters, Cts.Token);
            }
            catch (ServiceRequestException e)
            {
                ServerGeneratorStatus = e.Message.Contains("401") ? GeneratorStatus.WrongCredentials : GeneratorStatus.Failed;             
            }
            catch (ServiceResponseException)
            {
                ServerGeneratorStatus = GeneratorStatus.Failed;
            }
        }
    }
}
