﻿using System;
using EasyNetQ;

namespace FP.MsRmq.Basics.PublishSubscribe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IBus myBus = null;
            try
            {
                myBus = RabbitHutch.CreateBus("host=docker");
                //SimpleSubscription(myBus);
                //PolymorphicSubscription(myBus);
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

        private static void PolymorphicSubscription(IBus myBus)
        {
           

            var stromVertrag = new StromVertrag {Vertragsnummer = "ST 0042", Zählernummer = "94184613"};
            var handyVertrag = new HandyVertrag {Rufnummer = "0171 123456789", Vertragsnummer = "MD 00151"};

           
            Console.WriteLine("Verträge wurden erstellt");
            Console.ReadLine();
        }

        private static void SimpleSubscription(IBus myBus)
        {
            string input = string.Empty;
            do
            {
                Console.WriteLine("Enter a name or nothing to leave");
                input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
            
                }
                System.Threading.Thread.Sleep(2000);
            } while (!string.IsNullOrEmpty(input));
        }
    }
}
