using System;
using System.Collections.Generic;
using System.Net.Security;
using EasyNetQ;
using FP.MsRmq.IoTApp.Contracts;

namespace FP.Spartakiade2017.MsRmq.IoTApp.Device
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            Console.WriteLine("IoT Device is starting");
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

                

                Console.WriteLine("Please enter the count of metering values:");
                var countAsString = Console.ReadLine();

                var count = Convert.ToInt32(countAsString);
                var random = new Random(DateTime.Now.Second);
                for (int i = 0; i < count; i++)
                {
                    var value = random.Next(1, 1800);

                    MeteringValue mv = new MeteringValue
                    {
                        Timestamp = DateTime.UtcNow,
                        ObisCode = "1-1:1.6.0",
                        Value = value,
                        Host = System.Net.Dns.GetHostName()
                    };
                    myBus.Publish(mv);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                myBus?.Dispose();
            }
            Console.ReadLine();

        }
    }
}
