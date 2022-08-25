using EasyNetQ;
using FP.MsRmq.Basics.SendReceive;

IBus? myBus = null;
try
{
    myBus = RabbitHutch.CreateBus("host=localhost");
    myBus.SendReceive.Receive("MyMessageQueue", x => x
        .Add<MyMessageA>(a => { Console.WriteLine("Recive MyMessageA: {0}", a.Content); })
        .Add<MyMessageB>(b => { Console.WriteLine("Recive MyMessageB: {0}", b.Content); }));


    Console.Write("Please enter content for A:");
    var msgA = Console.ReadLine();
    Console.Write("Please enter  content for B:");
    var msgB = Console.ReadLine();

    myBus.SendReceive.Send("MyMessageQueue", new MyMessageA { Content = msgA });
    myBus.SendReceive.Send("MyMessageQueue", new MyMessageB { Content = msgB });



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