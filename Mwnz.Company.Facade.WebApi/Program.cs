using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mwnz.Company.Facade.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                  .UseContentRoot(Directory.GetCurrentDirectory())
                  .ConfigureWebHostDefaults(webBuilder =>
                  {
                      webBuilder.ConfigureAppConfiguration((context, builder) =>
                      {
                          var basePath = Environment.GetEnvironmentVariable("CONFIG_DIR") ?? Directory.GetCurrentDirectory();
                          var environment = Environment.GetEnvironmentVariable("ENVIRONMENT");
                          builder.SetBasePath(basePath);
                          builder.AddJsonFile("appsettings.json", false, false);
                          if (!string.IsNullOrEmpty(environment))
                              builder.AddJsonFile($"appsettings.{environment}.json", false, false);
                          builder.AddEnvironmentVariables();
                      }).UseKestrel(o =>
                      {

                          o.ListenAnyIP(int.TryParse(Environment.GetEnvironmentVariable("PORT_NUMBER"), out var result) ? result : 5001,
                          lo =>
                          {
                              lo.Protocols = HttpProtocols.Http1;
                          });
                      })
                      .UseStartup<Startup>();
                  });
    }
}
