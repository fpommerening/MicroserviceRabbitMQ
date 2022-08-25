using EasyNetQ;
using FP.MsRmq.Basics.RequestResponse;

IBus? myBus = null;
try
{
    myBus = RabbitHutch.CreateBus("host=localhost");

    myBus.Rpc.Respond<MyRequest, MyResponse>(req =>
        new MyResponse { Sum = req.Number1 + req.Number2 });

    Console.Write("Please enter first number:");
    var number1Text = Console.ReadLine();
    Console.Write("Please enter second number:");
    var number2Text = Console.ReadLine();
    
    if (int.TryParse(number1Text, out var number1) && int.TryParse(number2Text, out var number2))
    {
        var myrequest = new MyRequest { Number1 = number1, Number2 = number2 };
        var result = myBus.Rpc.Request<MyRequest, MyResponse>(myrequest);
        Console.WriteLine("{0} + {1} = {2}", number1, number2, result.Sum);
    }
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