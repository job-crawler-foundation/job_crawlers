using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackOverflow.Jobs.Configuration;
using StackOverflow.Jobs.Workers;

namespace StackOverflow.Jobs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureHostConfiguration(c => 
                {
                    c.AddJsonFile("appsettings.json");
                })
                .ConfigureServices((hostContext, services) =>
                {
                    services.Configure<ChromeDriverConfiguration>(hostContext.Configuration.GetSection(nameof(ChromeDriverConfiguration)));
                    services.Configure<TargetSiteConfiguration>(hostContext.Configuration.GetSection("TargetSite"));
                    services.AddHostedService<StackOverflowJobsCrawlWorker>();
                });
    }
}
