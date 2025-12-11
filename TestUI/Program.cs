using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestUI.Tests;

namespace TestUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("📌 Selenium Testleri Başlatılıyor...\n");

            /*RegisterTest.Run();
            Console.WriteLine("----------------------------");
            LoginTest.Run();
            Console.WriteLine("----------------------------");*/
            CheckEmailTest.Run();
            /*Console.WriteLine("----------------------------");
            ResetPasswordTest.Run();
            HomePageTest.Run();
            Console.WriteLine("----------------------------");
            ProfilePageTest.Run();
            Console.WriteLine("----------------------------");
            SituationTest.Run();
            GoalTest.Run();*/
             
            Console.WriteLine("\n🧪 Tüm testler tamamlandı.");
        }
    }
}
