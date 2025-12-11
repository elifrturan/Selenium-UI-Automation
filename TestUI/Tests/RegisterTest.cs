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
    public class RegisterTest
    {
        public static void Run()
        {
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("🔹 Kayıt Testi Başlatıldı...");

            driver.Navigate().GoToUrl("http://localhost:5173/signup");
            Thread.Sleep(2000);

            string email = "test" + new Random().Next(1000, 9999) + "@example.com";

            driver.FindElement(By.Id("email")).SendKeys(email);
            driver.FindElement(By.Id("fullName")).SendKeys("Test Kullanıcı");
            driver.FindElement(By.Id("birthDate")).SendKeys("1995-01-01T00:00:00");
            driver.FindElement(By.Id("password")).SendKeys("123456789Aa");
            driver.FindElement(By.Id("confirmPassword")).SendKeys("123456789Aa");

            driver.FindElement(By.Id("registerButton")).Click();
            Thread.Sleep(3000);

            try
            {
                var successAlert = driver.FindElement(By.ClassName("alert-success"));
                if (successAlert.Text.Contains("Kayıt başarılı"))
                {
                    Console.WriteLine("✅ Kayıt Testi Başarılı: Başarı mesajı alındı.");
                }
                else
                {
                    Console.WriteLine("❌ Kayıt Testi Başarısız: Mesaj beklenenden farklı.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ Kayıt Testi Başarısız: Başarı mesajı bulunamadı.");
            }

            driver.Quit();
        }
    }
}
