using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace RemoteOk
{
    class Program
    {
       

        static void Main(string[] args)
        {
            IWebDriver Driver;

            using (Driver = new ChromeDriver())
            {
                Driver.Url = "https://remoteok.io/remote-dev-jobs";
            }
        }
    }
}
