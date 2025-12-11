using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestUI.Tests
{
    public class ProfilePageTest
    {
        public static void Run()
        {
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("🔹 Profil Sayfası Testi Başlatıldı...");

            try
            {
                driver.Navigate().GoToUrl("http://localhost:5173/signin");
                Thread.Sleep(2000);

                driver.FindElement(By.Id("email")).SendKeys("test@example.com");
                driver.FindElement(By.Id("password")).SendKeys("123456789Aa");
                driver.FindElement(By.Id("loginButton")).Click();

                Thread.Sleep(3000); 

                driver.Navigate().GoToUrl("http://localhost:5173/profile");
                Thread.Sleep(2000);

                if (driver.Url.Contains("/profile"))
                {
                    Console.WriteLine("✅ Profil sayfasına başarılı bir şekilde yönlendirildi.");
                }
                else
                {
                    Console.WriteLine("❌ Profil sayfasına yönlendirme başarısız.");
                    return;
                }

                var emailInput = driver.FindElement(By.CssSelector("input[type='email']"));
                var fullNameInput = driver.FindElement(By.CssSelector("input[type='text']"));
                var birthDateInput = driver.FindElement(By.CssSelector("input[type='date']"));

                Console.WriteLine($"E-posta: {emailInput.GetAttribute("value")}");
                Console.WriteLine($"Ad Soyad: {fullNameInput.GetAttribute("value")}");
                Console.WriteLine($"Doğum Tarihi: {birthDateInput.GetAttribute("value")}");

                if (!string.IsNullOrEmpty(emailInput.GetAttribute("value")) &&
                    !string.IsNullOrEmpty(fullNameInput.GetAttribute("value")) &&
                    !string.IsNullOrEmpty(birthDateInput.GetAttribute("value")))
                {
                    Console.WriteLine("✅ Kullanıcı bilgileri başarıyla yüklendi.");
                }
                else
                {
                    Console.WriteLine("❌ Kullanıcı bilgileri eksik veya yüklenemedi.");
                }

                fullNameInput.Clear();
                fullNameInput.SendKeys("Test Kullanıcı Güncellendi");

                var saveButton = driver.FindElement(By.XPath("//button[text()='Kaydet']"));
                saveButton.Click();

                Thread.Sleep(2000);

                var alert = driver.FindElement(By.ClassName("alert"));
                Console.WriteLine($"Güncelleme mesajı: {alert.Text}");
                Console.WriteLine("✅ Profil bilgileri güncelleme testi başarılı.");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Hata oluştu: {ex.Message}");
            }
            finally
            {
                driver.Quit();
                Console.WriteLine("Test tamamlandı, tarayıcı kapatıldı.");
            }
        }
    }
}
