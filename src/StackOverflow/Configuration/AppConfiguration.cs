namespace StackOverflow.Jobs.Configuration
{
    public class AppConfiguration
    {
        public ChromeDriverConfiguration ChromeDriverConfiguration { get; set; }
    }

    public class ChromeDriverConfiguration
    {
        public string Path { get; set; }
    }

    public class TargetSiteConfiguration
    {
        public int PageDelayTimeMs { get; set; }
        public int JobItemDelayTimeMs { get; set;}
        public string Url { get; set; }
    }
}