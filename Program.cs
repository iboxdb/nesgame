using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Game
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (App.Start())
            {
                BuildWebHost(args).Run();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseKestrel((opt) =>
                {
                    opt.Listen(IPAddress.Any, 5000);
                })
                .ConfigureLogging((logging) =>
                {
                    logging.SetMinimumLevel(LogLevel.Warning);
                })
                .Build();
    }
}
