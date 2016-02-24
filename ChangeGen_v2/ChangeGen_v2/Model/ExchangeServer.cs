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
            ExchangeGenerator.StartGenerator(this.ServerCredentials, ExchangeGenParameters, this.Cts.Token);
        }
    }
}
