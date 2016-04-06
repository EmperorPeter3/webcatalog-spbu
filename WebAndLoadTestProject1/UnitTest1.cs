using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System.Diagnostics;
using System.IO;

namespace WebAndLoadTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        // Пример выбора одного чекбокса пользователем
        [TestMethod]
        public void WebTestScenario1()
        {
            PhantomJSDriver driver = new PhantomJSDriver();

            Stopwatch st = new Stopwatch();
            st.Start();

            driver.Navigate().GoToUrl("http://localhost:11281/");

            IWebElement query = driver.FindElement(By.Name("Assessment"));
            query.Click();

            IWebElement result;
            do
            {
                result = driver.FindElement(By.XPath(".//*[@id='results_table']/tbody/tr[2]/td/div/div[1]"));
            }
            while (result.Text != "SocialSciences,MathematicalMethods");

            st.Stop();
            /*
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"E:\tests\2\note1.txt", true))
            {
                file.WriteLine(st.Elapsed);
            }
            */
            driver.Quit();
        }
    }
}
