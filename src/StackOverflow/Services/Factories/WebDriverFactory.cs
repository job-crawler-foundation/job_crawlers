using Microsoft.Extensions.Options;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using StackOverflow.Jobs.Configuration;

namespace StackOverflow.Jobs.Services.Factories
{
    public class WebDriverFactory
    {
        private readonly ChromeDriverConfiguration _chromeDriverConfiguration;

        public WebDriverFactory(IOptions<ChromeDriverConfiguration> configurationAccessor)
        {
            _chromeDriverConfiguration = configurationAccessor.Value;
        }

        public virtual IWebDriver Create()
        {
            return new ChromeDriver(_chromeDriverConfiguration.Path);
        }
    }

}