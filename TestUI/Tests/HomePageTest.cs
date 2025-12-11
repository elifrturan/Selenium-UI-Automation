using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUI.Tests
{
    public class HomePageTest
    {
        public static void Run()
        {
            IWebDriver driver = new ChromeDriver();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            Console.WriteLine("🔹 Home Sayfası UI Testi Başlatıldı...");

            driver.Navigate().GoToUrl("http://localhost:5173/home");

            wait.Until(d => d.FindElement(By.CssSelector(".user-name")).Displayed);

            try
            {
                var userNameElement = driver.FindElement(By.CssSelector(".user-name h2"));
                if (userNameElement.Text.Contains("Hoş Geldiniz"))
                {
                    Console.WriteLine("✅ Hoş Geldiniz mesajı doğru şekilde görüntüleniyor.");
                }
                else
                {
                    Console.WriteLine("❌ Hoş Geldiniz mesajı yanlış.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ Hoş Geldiniz mesajı bulunamadı.");
            }

            try
            {
                var tableRows = driver.FindElements(By.CssSelector(".last-seven-days table tbody tr"));

                if (tableRows.Count > 0)
                {
                    Console.WriteLine($"✅ Son 7 gün verileri {tableRows.Count} adet veri ile görüntüleniyor.");
                }
                else
                {
                    Console.WriteLine("❌ Son 7 gün verisi bulunamadı.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ Son 7 gün verileri tablosu bulunamadı.");
            }

            try
            {
                var recommendationElement = driver.FindElement(By.CssSelector(".recommendation .note-content"));
                if (!string.IsNullOrEmpty(recommendationElement.Text))
                {
                    Console.WriteLine("✅ Öneri doğru şekilde görüntüleniyor.");
                }
                else
                {
                    Console.WriteLine("❌ Öneri boş.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ Öneri alanı bulunamadı.");
            }

            driver.Quit();
        }
    }
}
