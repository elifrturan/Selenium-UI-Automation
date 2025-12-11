using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestUI.Tests
{
    public class CheckEmailTest
    {
        public static void Run()
        {
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("🔹 E-posta Doğrulama Testi Başlatıldı...");

            driver.Navigate().GoToUrl("http://localhost:5173/forgotpassword");
            Thread.Sleep(2000);

            driver.FindElement(By.Id("email")).SendKeys("test@example.com");

            driver.FindElement(By.CssSelector("button[type='submit']")).Click();
            Thread.Sleep(3000); 

            Console.WriteLine("✅ E-posta Doğrulama Testi Başarılı: Form başarıyla gönderildi.");

            Console.ReadLine();
            driver.Quit();
        }
    }
}
