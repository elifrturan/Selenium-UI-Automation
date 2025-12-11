using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestUI.Tests
{
    public class LoginTest
    {
        public static void Run()
        {
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("🔹 Giriş Testi Başlatıldı...");

            driver.Navigate().GoToUrl("http://localhost:5173/signin");
            Thread.Sleep(2000);

            driver.FindElement(By.Id("email")).SendKeys("test@example.com");
            driver.FindElement(By.Id("password")).SendKeys("123456789Aa");
            driver.FindElement(By.Id("loginButton")).Click();

            Thread.Sleep(2000);

            if (driver.Url.Contains("/home"))
            {
                Console.WriteLine("✅ Giriş Testi Başarılı: /home yönlendirmesi yapıldı.");
            }
            else
            {
                Console.WriteLine("❌ Giriş Testi Başarısız: Yönlendirme yapılmadı.");
            }

            driver.Quit();
        }
    }
}
