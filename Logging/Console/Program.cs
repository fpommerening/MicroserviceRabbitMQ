using System;
using EasyNetQ;
using FP.MsRmq.Logging.Contacts;

namespace FP.MsRmq.Logging.ConsoleListener
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;

            try
            {
              
                Console.WriteLine("Logger gestartet...");
                Console.ReadLine();
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

            Console.WriteLine("Logger beendet...");
        }
    }
}
