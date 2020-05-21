using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RemoteOk
{
    public static class Extensions
    {
        public static IEnumerable<JobMessage> AsMessages(this IEnumerable<IWebElement> jobs)
        {
            return jobs.Select(x =>
            new JobMessage
            {
                URL = string.Concat(
                    Consts.SiteURL,
                    x.GetAttribute(Consts.JobUrlAttributeKey)),
                Time = Convert.ToInt64(x.GetAttribute(Consts.TimeAttributeKey))
            });
        }
    }
}