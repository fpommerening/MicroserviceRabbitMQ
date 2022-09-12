using EasyNetQ;
using FP.MsRmq.Basics.TopicBasedRouting;

IBus? myBus = null;
try
{
    myBus = RabbitHutch.CreateBus("host=rabbitmq.ddc-cloud.de");
    myBus.PubSub.Subscribe<MyMessage>("BlueLine", msg =>
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Say hallo to {0}", msg.Name);
            Console.ForegroundColor = ConsoleColor.White;
        },
        x => x.WithTopic("BLUE"));

    myBus.PubSub.Subscribe<MyMessage>("RedLine", msg =>
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Say hallo to {0}", msg.Name);
            Console.ForegroundColor = ConsoleColor.White;
        },
        x => x.WithTopic("RED"));
    string input;

    do
    {
        Console.WriteLine("select a color (valid are 'red' or 'blue')");
        var color = Console.ReadLine();
        Console.WriteLine("Enter a name or nothing to leave");
        input = Console.ReadLine();

        if (!string.IsNullOrEmpty(input))
        {
            myBus.PubSub.Publish(new MyMessage { Name = input }, color.ToUpper());
        }
        Thread.Sleep(2000);
    } while (!string.IsNullOrEmpty(input));
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