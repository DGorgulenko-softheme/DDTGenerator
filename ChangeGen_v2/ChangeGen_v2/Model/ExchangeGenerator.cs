using System;
using System.Linq;
using System.Threading;
using Microsoft.Exchange.WebServices.Data;

namespace ChangeGen_v2
{
    internal class ExchangeGenerator
    {
        public static void StartGenerator(ServerConnectionCredentials serverCredentials, ExchangeGeneratorParameters genParameters, CancellationToken token)
        {
            var service = new ExchangeService(ExchangeVersion.Exchange2007_SP1)
            {
                Credentials = new WebCredentials(serverCredentials.Username, serverCredentials.Password),
                Url = new Uri("https://" + serverCredentials.Ip + "/EWS/Exchange.asmx"),
                Timeout = 300000
            }; 

            while (true)
            {
                SendMessages(service, genParameters);
                if(token.IsCancellationRequested)
                    break;
            }
           
        }

        private static void SendMessages(ExchangeService service, ExchangeGeneratorParameters genParameters)
        {
            var email = new EmailMessage(service);

            email.ToRecipients.Add(genParameters.Recipient);            
            email.Body = new MessageBody(RandomString(genParameters.MessageSize));
            email.Subject = "Exchange Generator " + genParameters.MessageSize;


            email.Send();
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
