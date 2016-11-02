using System;
using System.Threading;
using EasyNetQ;
using FP.MsRMQ.PicFlow.Contracts;

namespace FP.MsRMQ.PicFlow.ImageProcessor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
                myBus = RabbitHutch.CreateBus(EnvironmentVariable.GetValueOrDefault("ConnectionStringRabbitMQ", "host=localhost"));
                var mongoCnn = EnvironmentVariable.GetValueOrDefault("ConnectionStringDocumentDB", "mongodb://localhost");
                using (var worker = new ImageWorker(myBus, mongoCnn))
                {
                    worker.Init();
                    Console.WriteLine("ImageProcessor gestartet...");
                    while (Console.ReadLine() != "quit") { Thread.Sleep(int.MaxValue); }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Verbindung ist fehlgeschlagen");
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            Console.WriteLine("ImageProcessor beendet...");
        }
    }
}
