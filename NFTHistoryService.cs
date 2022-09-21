using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTHistoryProject
{
    public class NFTHistoryService
    {
        public void GetHistory()
        {
            var driverService = ChromeDriverService.CreateDefaultService();
            var options = new ChromeOptions();
            options.AddArgument("disable-gpu");
            options.AddArgument("headless");
            options.AddArgument("--log-level=1");

            var driver = new ChromeDriver(driverService, options);

            driver.Navigate().GoToUrl("https://bscscan.com/token/0x80461f88de22b2363113226f0749a7a59cc2225a?a=8530628200002121");
            //driver.Navigate().GoToUrl("https://ko.wikipedia.org/wiki/%EB%8B%B7%EB%84%B7_%ED%94%84%EB%A0%88%EC%9E%84%EC%9B%8C%ED%81%AC_%EB%B2%84%EC%A0%84_%EC%97%AD%EC%82%AC");
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            var iframe = driver.FindElement(By.XPath("//*[@id=\"tokentxnsiframe\"]"));
            driver.SwitchTo().Frame(iframe);

            var table = driver.FindElement(By.XPath("//*[@id=\"maindiv\"]/div[2]/table"));
            //var table = driver.FindElement(By.XPath("//*[@id=\"mw-content-text\"]/div[1]/table"));
            var tbody = table.FindElement(By.TagName("tbody"));
            var trs = tbody.FindElements(By.TagName("tr"));

            foreach (var tr in trs)
            {
                var ths = tr.FindElements(By.TagName("th"));
                foreach (var th in ths)
                {
                    Console.WriteLine("th: " + th.Text);
                }

                var tds = tr.FindElements(By.TagName("td"));
                foreach (var td in tds)
                {
                    Console.WriteLine("td: " + td.Text);
                }
            }
        }
    }
}
