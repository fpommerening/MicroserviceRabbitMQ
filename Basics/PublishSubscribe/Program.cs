using EasyNetQ;
using FP.MsRmq.Basics.PublishSubscribe;

void PolymorphicSubscription(EasyNetQ.IBus myBus)
{
    myBus.PubSub.Subscribe<IVertrag>("VertragsSubstription", vertrag =>
    {
        Console.WriteLine("Vertrag {0} wurde abgeschlossen", vertrag.Vertragsnummer);
    });

    var stromVertrag = new StromVertrag { Vertragsnummer = "ST 0042", Zählernummer = "94184613" };
    var handyVertrag = new HandyVertrag { Rufnummer = "0171 123456789", Vertragsnummer = "MD 00151" };

    myBus.PubSub.Publish<IVertrag>(stromVertrag);
    myBus.PubSub.Publish<IVertrag>(handyVertrag);

    Console.WriteLine("Verträge wurden erstellt");
    Console.ReadLine();
}

void SimpleSubscription(IBus myBus)
{
    myBus.PubSub.Subscribe<MyMessage>("MyMessageSubscription", msg => Console.WriteLine("Say hallo to {0}", msg.Name));
    string input = string.Empty;
    do
    {
        Console.WriteLine("Enter a name or nothing to leave");
        input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            myBus.PubSub.Publish<MyMessage>(new MyMessage { Name = input });

        }
        System.Threading.Thread.Sleep(2000);
    } while (!string.IsNullOrEmpty(input));
}



IBus myBus = null;
try
{
    myBus = RabbitHutch.CreateBus("host=localhost");
    //SimpleSubscription(myBus);
    PolymorphicSubscription(myBus);
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