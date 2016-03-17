using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Exchange.WebServices.Data;

namespace ChangeGen_v2
{
    internal static class ExchangeGenerator
    {
        private static Random _random;
        public static void StartGenerator(ServerConnectionCredentials serverCredentials, ExchangeGeneratorParameters genParameters, CancellationToken token)
        {
            ServicePointManager.ServerCertificateValidationCallback = OnValidationCallback;
            var service = new ExchangeService(ExchangeVersion.Exchange2007_SP1)
            {
                Credentials = new WebCredentials(serverCredentials.Username, serverCredentials.Password),
                Url = new Uri("https://" + serverCredentials.Ip + "/EWS/Exchange.asmx"),
                Timeout = 300000
            };

            Logger.Log("Exchange data generation started for server: " + serverCredentials.Ip + " . With mail size: " + genParameters.MessageSize, Logger.LogLevel.Info, serverCredentials.Ip);

            _random = new Random();

            while (true)
            {
                SendMessages(service, genParameters, serverCredentials, _random);
                if (token.IsCancellationRequested)
                    break;
            }
        }

        private static void SendMessages(ExchangeService service, ExchangeGeneratorParameters genParameters, ServerConnectionCredentials serverCreds, Random random1)
        {
            var email = new EmailMessage(service);

            email.ToRecipients.Add(genParameters.Recipient);            
            email.Body = new MessageBody(HelperMethods.RandomString((int)genParameters.MessageSize,random1));
            email.Subject = "Exchange Generator (" + genParameters.MessageSize+")";

            var serviceRequestRetryCount = 0;
            var serviceResponseRetryCount = 0;

            while (true)
            {
                try
                {
                    email.Send();
                    break;
                }
                catch (ServiceRequestException e)
                {
                    if (serviceRequestRetryCount < 3)
                    {
                        serviceRequestRetryCount++;
                        Logger.Log("ServiceRequestException has been caught, retry in 15 seconds.", Logger.LogLevel.Warning, serverCreds.Ip);
                        Thread.Sleep(15000);
                        
                    }
                    else
                    {
                        Logger.LogError("Something wrong with exchange server.", serverCreds.Ip, e);
                        throw;
                    }
                    
                }
                catch (ServiceResponseException e)
                {
                    if (serviceResponseRetryCount < 3)
                    {
                        serviceResponseRetryCount++;
                        Logger.Log("ServiceResponseException has been caught, retry in 15 seconds.", Logger.LogLevel.Warning, serverCreds.Ip);
                        Thread.Sleep(15000);
                    }
                    else
                    {
                        Logger.LogError("Something wrong with exchange server.", serverCreds.Ip, e);
                        throw;
                    }
                }
            }                     
        }

        

        private static bool OnValidationCallback(object sender, X509Certificate cert, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
