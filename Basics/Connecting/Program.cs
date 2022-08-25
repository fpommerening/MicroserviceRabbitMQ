using EasyNetQ;

IBus? myBus = null;
try
{
    myBus = RabbitHutch.CreateBus("host=localhost");
    Console.WriteLine("Verbindung wurde aufgebaut: {0}", myBus.Advanced.IsConnected);
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