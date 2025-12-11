using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestUI.Tests
{
    public class GoalTest
    {
        public static void Run()
        {
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("🔹 Hedef Testi Başlatıldı...");

            driver.Navigate().GoToUrl("http://localhost:5173/signin");
            Thread.Sleep(2000);

            driver.FindElement(By.Id("email")).SendKeys("test@example.com");
            driver.FindElement(By.Id("password")).SendKeys("123456789Aa");
            driver.FindElement(By.Id("loginButton")).Click();

            Thread.Sleep(3000);

            driver.Navigate().GoToUrl("http://localhost:5173/health-page");
            Thread.Sleep(2000);

            driver.FindElement(By.Name("goalTitle")).SendKeys("Selenium Test Başlığı");
            driver.FindElement(By.Name("goalDescription")).SendKeys("Selenium ile test ekleniyor.");
            driver.FindElement(By.Name("goalPeriod")).SendKeys("2");
            driver.FindElement(By.Name("goalPriority")).SendKeys("Yüksek");

            var periodSelect = driver.FindElement(By.Name("periodUnit"));
            var options = periodSelect.FindElements(By.TagName("option"));
            foreach (var option in options)
            {
                if (option.Text == "Günde")
                {
                    option.Click();
                    break;
                }
            }

            driver.FindElement(By.Id("addGoalButton")).Click();

            Thread.Sleep(3000);

            var alerts = driver.FindElements(By.ClassName("alert-success"));
            if (alerts.Count > 0)
            {
                Console.WriteLine("✅ Hedef başarıyla eklendi.");
            }
            else
            {
                Console.WriteLine("❌ Hedef eklenemedi.");
            }

            var table = driver.FindElement(By.TagName("table"));
            if (table.Text.Contains("Selenium Test Başlığı"))
            {
                Console.WriteLine("✅ Eklenen hedef tabloda görüntülendi.");
            }
            else
            {
                Console.WriteLine("❌ Hedef tabloda bulunamadı.");
            }

            Console.ReadLine();
            driver.Quit();
        }
    }
}
