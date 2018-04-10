using System;
using EasyNetQ;
using FP.MsRmq.Cluster.Contracts;

namespace FP.MsRmq.Cluster.Capture
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost:5672,localhost:5673,localhost:5674;prefetchcount=1");
                //PublishManual(myBus);
                PublishAutomatic(myBus);

                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }
            Console.ReadLine();

        }

        private static void PublishAutomatic(IBus myBus)
        {
            Console.WriteLine("Start publish 250 cluster messages");
            for (int i = 0; i < 250; i++)
            {
                var msg = new ClusterMessage
                {
                    Timestamep = DateTime.Now,
                    Host = System.Net.Dns.GetHostName(),
                    Message = $"Automatic message {i}"
                };
                myBus.Publish(msg);

                System.Threading.Thread.Sleep(150);
            }
        }

        private static void PublishManual(IBus myBus)
        {
            var message = string.Empty;
            do
            {
                Console.WriteLine("Enter the message or nothing to leave");
                message = Console.ReadLine();
                if (!string.IsNullOrEmpty(message))
                {
                    var msg = new ClusterMessage
                    {
                        Timestamep = DateTime.Now,
                        Host = System.Net.Dns.GetHostName(),
                        Message = message
                    };
                    myBus.Publish(msg);
                }
            } while (string.IsNullOrEmpty(message));

        }

        
    }
}
