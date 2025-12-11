using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace TestUI.Tests
{
    public class ResetPasswordTest
    {
        public static void Run()
        {
            IWebDriver driver = new ChromeDriver();
            Console.WriteLine("🔹 Şifre Yenileme Testi Başlatıldı...");

            driver.Navigate().GoToUrl("http://localhost:5173/reset-password?email=test@example.com");
            Thread.Sleep(2000);

            driver.FindElement(By.Id("newPassword")).SendKeys("NewPassword123");
            driver.FindElement(By.Id("confirmPassword")).SendKeys("NewPassword123");

            driver.FindElement(By.Id("resetButton")).Click();
            Thread.Sleep(3000);

            try
            {
                var successAlert = driver.FindElement(By.ClassName("alert-success"));
                if (successAlert.Text.Contains("Şifre başarıyla yenilendi"))
                {
                    Console.WriteLine("✅ Şifre Yenileme Testi Başarılı: Şifre başarıyla yenilendi.");
                }
                else
                {
                    Console.WriteLine("❌ Şifre Yenileme Testi Başarısız: Mesaj beklenenden farklı.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ Şifre Yenileme Testi Başarısız: Başarı mesajı bulunamadı.");
            }

            try
            {
                var errorAlert = driver.FindElement(By.ClassName("alert-danger"));
                if (errorAlert.Text.Contains("Şifreler uyuşmuyor"))
                {
                    Console.WriteLine("❌ Şifre Yenileme Testi Başarısız: Şifreler uyuşmuyor hatası doğru.");
                }
                else
                {
                    Console.WriteLine("❌ Şifre Yenileme Testi Başarısız: Beklenmeyen hata.");
                }
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("❌ Şifre Yenileme Testi Başarısız: Hata mesajı bulunamadı.");
            }

            driver.Quit();
        }
    }
}
