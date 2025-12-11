using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TestUI.Tests
{
    public class SituationTest
    {
        public static void Run()
        {
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("🔹 Situation Sayfası Testi Başlatıldı...");

            driver.Navigate().GoToUrl("http://localhost:5173/signin");
            Thread.Sleep(2000);

            driver.FindElement(By.Id("email")).SendKeys("test@example.com");
            driver.FindElement(By.Id("password")).SendKeys("123456789Aa");
            driver.FindElement(By.Id("loginButton")).Click();
            Thread.Sleep(2000);

            driver.Navigate().GoToUrl("http://localhost:5173/health-page");
            Thread.Sleep(3000);

            try
            {
                var table = driver.FindElement(By.TagName("table"));
                if (table.Displayed)
                    Console.WriteLine("✅ Tablo başarıyla görüntülendi.");
                else
                    Console.WriteLine("❌ Tablo görüntülenemedi.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ Tablo elementi bulunamadı.");
            }

            try
            {
                var goalDropdown = driver.FindElement(By.Name("goalId"));
                goalDropdown.Click();
                Thread.Sleep(1000);
                goalDropdown.FindElement(By.TagName("option")).Click();

                driver.FindElement(By.Name("recordDescription")).SendKeys("Test açıklama");
                driver.FindElement(By.Name("recordDate")).SendKeys(DateTime.Now.ToString("yyyy-MM-dd"));
                driver.FindElement(By.Name("recordTime")).SendKeys("12:00");
                driver.FindElement(By.Name("recordDuration")).SendKeys("30");

                var unitDropdown = driver.FindElement(By.Name("durationUnit"));
                unitDropdown.Click();
                unitDropdown.FindElement(By.TagName("option")).Click();

                var checkbox = driver.FindElement(By.Name("isApplied"));
                checkbox.Click();

                driver.FindElement(By.Id("addRecordButton")).Click();
                Thread.Sleep(2000);

                if (driver.PageSource.Contains("Veri başarıyla kaydedildi"))
                    Console.WriteLine("✅ Yeni veri kaydı başarıyla eklendi.");
                else
                    Console.WriteLine("❌ Veri kaydı başarısız.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Veri ekleme sırasında hata: {ex.Message}");
            }

            try
            {
                var recommendation = driver.FindElement(By.XPath("//*[contains(text(), 'Öneri burada görüntüleniyor')]"));
                if (recommendation.Displayed)
                    Console.WriteLine("✅ Öneri alanı görüntüleniyor.");
                else
                    Console.WriteLine("❌ Öneri alanı görüntülenemiyor.");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ Öneri elementi bulunamadı.");
            }

            driver.Quit();
            Console.WriteLine("🔚 Situation Sayfası Testi Tamamlandı.");
        }
    }
}
