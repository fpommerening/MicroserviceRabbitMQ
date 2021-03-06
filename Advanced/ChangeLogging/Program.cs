﻿using System;
using System.IO;
using EasyNetQ;

namespace FP.MsRMQ.Advanced.ChangeLogging
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.XmlConfigurator.Configure(new FileInfo("log4net.xml"));

            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=localhost",
                    c => c.Register<IEasyNetQLogger, Log4NetLogger>());
                Console.WriteLine("Verbindung wurde aufgebaut: {0}", myBus.IsConnected);
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
            Console.ReadLine();
        }
    }
}
