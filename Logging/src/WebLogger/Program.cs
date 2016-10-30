using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace FP.MsRmq.Logging.WebLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel()
                .UseStartup<Startup>()
                .UseUrls("http://0.0.0.0:8080")
                .Build();

            host.Run();
        }
    }
}
