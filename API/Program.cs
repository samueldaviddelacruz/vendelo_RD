using System;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World 3!");
            var host = new WebHostBuilder()
            //.UseUrls("http://*:3000")
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .UseIISIntegration()
            .UseStartup<StartUp>()
            .Build();
            host.Run();
        }
    }
}
