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
        const string defaultChatRoom = "530610663768168";

        static void Main(string[] args)
        {
            driver.Navigate().GoToUrl("https://www.messenger.com");
            SignIn();

            IWebElement lastMessageAuthor = driver.FindElement(By.Id("js_2")).FindElements(By.TagName("h5")).Last();
            IWebElement lastMessage = driver.FindElement(By.Id("js_2")).FindElements(By.TagName("div")).Last();
        }

        static void SignIn()
        {
            IWebElement emailEntry = driver.FindElement(By.Name("email"));
            IWebElement passwordEntry = driver.FindElement(By.Name("pass"));
            IWebElement submitButton = driver.FindElement(By.Name("login"));

            Console.Write("Username: ");
            string email = Console.ReadLine();
            Console.Write("Password: ");
            string password = string.Empty;
            char typedKey = Console.ReadKey(true).KeyChar;
            while (typedKey != '\r')
            {
                password += typedKey;
                typedKey = Console.ReadKey(true).KeyChar;
            }
            Console.WriteLine();

            emailEntry.SendKeys(email);
            passwordEntry.SendKeys(password);

            submitButton.Click();
            if (driver.Url == "https://www.messenger.com/login/password/") { throw new Exception("Sign-in failed"); }
            driver.Navigate().GoToUrl("https://www.messenger.com/t/" + defaultChatRoom);
        }

    }
}
