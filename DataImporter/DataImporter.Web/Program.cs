using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DataImporter.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

            var emailinfo = new EmailConnectionInfo
            {
                FromEmail = configBuilder["Serilog:WriteTo:2:Args:FromEmail"],
                ToEmail = configBuilder["Serilog:WriteTo:2:Args:MailServer"],
                MailServer = configBuilder["Serilog:WriteTo:2:Args:MailServer"],
                EmailSubject = configBuilder["Serilog:WriteTo:2:Args:EmailSubject"],
                Port = int.Parse(configBuilder["Serilog:WriteTo:2:Args:Port"]),
                EnableSsl = bool.Parse(configBuilder["Serilog:WriteTo:2:Args:EnableSsl"]),
                NetworkCredentials = new NetworkCredential(
                    configBuilder["Serilog:WriteTo:2:Args:UserName"],
                    configBuilder["Serilog:WriteTo:2:Args:Password"])
            };

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Email(emailinfo,
                    outputTemplate: "Time : {Timestamp:HH:mm:ss}\t\n" +
                        "{Level:u3}\t\n" +
                        "{sourceContext}\t\n" +
                        "{message}{NewLine}{Exception}",
                    LogEventLevel.Fatal, 1)
                .ReadFrom.Configuration(configBuilder)
                .CreateLogger();

            try
            {
                Log.Information("Application Starting up");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseUrls("http://*:80");
                });
    }
}
