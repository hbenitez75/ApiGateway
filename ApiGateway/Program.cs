using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ocelot.Middleware;

namespace ApiGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder();
            
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                 .ConfigureAppConfiguration((hostingContext, config) =>
                 {
                     config.AddJsonFile(ConfigurationPath.Combine("ocelot.json"), optional: false, reloadOnChange:true)
                     .AddJsonFile("appsettings.json", optional : true, reloadOnChange : true) ;
                 })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                 
                    webBuilder.UseStartup<Startup>();
                });
                
    }
}
