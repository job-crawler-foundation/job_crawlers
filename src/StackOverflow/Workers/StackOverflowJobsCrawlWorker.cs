using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StackOverflow.Jobs.Workers
{
    public class StackOverflowJobsCrawlWorker : BackgroundService
    {
        private readonly ILogger<StackOverflowJobsCrawlWorker> _logger;

        public StackOverflowJobsCrawlWorker(ILogger<StackOverflowJobsCrawlWorker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
