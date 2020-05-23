using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using StackOverflow.Jobs.Configuration;
using StackOverflow.Jobs.Services.Factories;

namespace StackOverflow.Jobs.Services
{
    public class JobsQuery
    {
        private readonly TargetSiteConfiguration _siteOptions;
        private readonly WebDriverFactory _driverFactory;

        public JobsQuery(IOptions<TargetSiteConfiguration> siteOptionsAccessor, WebDriverFactory driverFactory)
        {
            _siteOptions = siteOptionsAccessor.Value;
            _driverFactory = driverFactory;
        }

        public virtual Task Execute(CancellationToken ct = default)
        {
            using var driver = _driverFactory.Create();

            driver.Navigate().GoToUrl(_siteOptions.Url);            
            var jobItems = driver
                .FindElements(By.ClassName("s-link stretched-link"))
                .Select(x => x.GetAttribute("href"));
            
            var rawJobsUris = new List<string>();
            rawJobsUris.AddRange(jobItems);            

            foreach(var uri in rawJobsUris)
            {
                driver.Navigate().GoToUrl(uri);
                
                var title = driver.FindElement(By.ClassName("fc-black-900")).Text;


            }

            return Task.CompletedTask;
        }
    }
}