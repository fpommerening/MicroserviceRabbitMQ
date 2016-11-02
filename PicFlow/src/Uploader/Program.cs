using System;
using System.Threading;
using EasyNetQ;
using FP.MsRMQ.PicFlow.Contracts;

namespace FP.MsRMQ.PicFlow.Uploader
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
                myBus = RabbitHutch.CreateBus(EnvironmentVariable.GetValueOrDefault("ConnectionStringRabbitMQ", "host=localhost"));
                var cnnImageDb = EnvironmentVariable.GetValueOrDefault("ConnectionStringDocumentDB", "mongodb://localhost");
                var externalAppUrl = EnvironmentVariable.GetValueOrDefault("ExternalAppUrl", "http://localhost:8000/api/postimage");
                using (var transmittter = new Transmitter(myBus, cnnImageDb, externalAppUrl))
                {
                    transmittter.Init();
                    Console.WriteLine("Uploader gestartet...");
                    while (Console.ReadLine() != "quit") { Thread.Sleep(int.MaxValue); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Uploader ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            Console.WriteLine("Uploader beendet...");
        }
    }
}
