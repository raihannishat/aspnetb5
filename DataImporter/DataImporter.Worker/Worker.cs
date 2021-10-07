using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataImporter.Worker.Model;
using Autofac;

namespace DataImporter.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        public static ILifetimeScope AutofacContainer { get; private set; }

        public Worker(ILogger<Worker> logger, ILifetimeScope lifetimeScope)
        {
            _logger = logger;
            AutofacContainer = lifetimeScope;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                var importer = new WorkerModel();
                importer.GetAllStatus();
                await Task.Delay(15000, stoppingToken);
            }
        }
    }
}
