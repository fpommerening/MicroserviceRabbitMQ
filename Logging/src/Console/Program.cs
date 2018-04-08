using System;
using EasyNetQ;
using FP.MsRmq.Logging.Contracts;

namespace FP.MsRmq.Logging.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
                myBus = RabbitHutch.CreateBus(EnvironmentVariable.GetValueOrDefault("ConnectingStringRabbitMQ", "host=localhost"));
                myBus.Subscribe<LogItem>("ConsoleLogger", log =>
                {
                    System.Console.WriteLine("{0:HH:mm:ss.fff} [{1}] {2} -> {3} {4}",
                        log.Timestamp, log.SessionId, log.RemoteHost, log.InstanceHost, log.State);
                });
                System.Console.WriteLine("Logger gestartet...");
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Verbindung ist fehlgeschlagen");
                System.Console.WriteLine(ex);
            }
            finally
            {
                myBus?.Dispose();
            }

            System.Console.WriteLine("Logger beendet...");
        }
    }
}
