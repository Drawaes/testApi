using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using CondenserDotNet.Client;

namespace testApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceManager = new ServiceManager("TestService");
            serviceManager.AddHttpHealthCheck("health", 10)
                .AddApiUrl("/api/someObject")
                .AddApiUrl("/api/someOtherObject")
                .RegisterServiceAsync();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseUrls($"http://*:{serviceManager.ServicePort}")
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}
