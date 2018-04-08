using System;
using System.Collections.Generic;
using System.Net.Security;
using EasyNetQ;
using FP.MsRmq.IoTApp.Contracts;

namespace FP.Spartakiade2017.MsRmq.IoTApp.Hub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
                var connection = new ConnectionConfiguration
                {
                    Port = 5671,
                    UserName = "guest",
                    Password = "guest",
                    Product = "IoT Hub"
                };

                var hostConfiguration = new HostConfiguration();
                hostConfiguration.Host = "localhost";
                hostConfiguration.Port = 5671;
                hostConfiguration.Ssl.Enabled = true;
                hostConfiguration.Ssl.ServerName = "rabbitServer";
                hostConfiguration.Ssl.CertPath = @"c:\Temp\keycert.p12";
                hostConfiguration.Ssl.CertPassphrase = "strenggeheim";
                hostConfiguration.Ssl.AcceptablePolicyErrors =
                    SslPolicyErrors.RemoteCertificateNameMismatch |
                    SslPolicyErrors.RemoteCertificateChainErrors;
                connection.Hosts = new List<HostConfiguration> {hostConfiguration};
                connection.Validate();
                myBus = RabbitHutch.CreateBus(connection, services => { });
                //myBus = RabbitHutch.CreateBus("host=10.0.1.72");

                Console.WriteLine("IoT Hub is started");

                myBus.Subscribe<MeteringValue>("IoTHub", mv =>
                {
                    Console.WriteLine($"New metering value from {mv.Host} - {mv.ObisCode} - {mv.Value} W");
                });
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                myBus?.Dispose();
            }
        }
    }
}
