using System;
using Microsoft.AspNetCore.Hosting;
namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World 2!");
            var host = new WebHostBuilder()
            .UseUrls("http://*:3000")
            .UseKestrel()
            .UseStartup<StartUp>()
            .Build();
            host.Run();
        }
    }
}
