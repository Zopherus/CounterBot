using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CounterBot
{
    class Program
    {
        private static IWebDriver driver = new ChromeDriver(Directory.GetCurrentDirectory());

        static void Main(string[] args)
        {
            driver.Navigate().GoToUrl("https://www.messenger.com");

            IWebElement lastMessage = driver.FindElement(By.Id("js_2")).FindElements(By.TagName("div")).Last();
        }
    }
}
