using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Linq;

namespace RemoteOk
{
    class Program
    {      
        static void Main(string[] args)
        {
            IWebDriver Driver;

            using (Driver = new ChromeDriver())
            {
                Driver.Url = Consts.SiteJobsURL;
                var jobs = Driver
                    .FindElements(By.ClassName("job"))
                    .AsMessages()
                    .ToList();
            }
        }
    }
}
