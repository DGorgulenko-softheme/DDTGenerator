using System;
using System.Linq;
using System.Threading;
using Microsoft.Exchange.WebServices.Data;
using NLog;

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

            Logger.Log("Exchange data generation started for server: " + serverCredentials.Ip + " . With mail size: " + genParameters.MessageSize.ToString(), Logger.LogLevel.Info, serverCredentials.Ip);

            while (true)
            {
                SendMessages(service, genParameters, serverCredentials);
                if (token.IsCancellationRequested)
                    break;
            }

        }

        private static void SendMessages(ExchangeService service, ExchangeGeneratorParameters genParameters, ServerConnectionCredentials serverCreds)
        {
            var email = new EmailMessage(service);

            email.ToRecipients.Add(genParameters.Recipient);            
            email.Body = new MessageBody(RandomString((int)genParameters.MessageSize));
            email.Subject = "Exchange Generator (" + genParameters.MessageSize+")";

            try
            {
                email.Send();
            }
            catch (ServiceRequestException e)
            {
                Logger.LogError("Something wrong with exchange server.", serverCreds.Ip, e);
                throw;
            }
            catch (ServiceResponseException e)
            {
                Logger.LogError("Something wrong with exchange server.", serverCreds.Ip, e);
                throw;
            }
            
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
