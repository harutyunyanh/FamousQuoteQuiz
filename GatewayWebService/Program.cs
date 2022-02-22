using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GatewayWebService
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, configuration) => {
                configuration.Sources.Clear();
                IHostEnvironment env = hostingContext.HostingEnvironment;
                configuration.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);
            })
            .ConfigureLogging(logging => { logging.ClearProviders(); logging.AddConsole(); })
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
