using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using System.Net;
using Serilog.Sinks.Email;
using Serilog;
using Serilog.Events;

namespace TicketBookingSystem.Web
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
                FromEmail = "exapmle@demo.com",
                ToEmail = "example@demo.com",
                MailServer = "smtp.gmail.com",
                EmailSubject = "An Log Error Occured in TicketBookingSystem.Web Project, Please check it",
                Port = 465,
                EnableSsl = true,
                NetworkCredentials = new NetworkCredential("example@demo", "password")
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
