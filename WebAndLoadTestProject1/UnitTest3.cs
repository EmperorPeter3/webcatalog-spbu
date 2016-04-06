using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;
using System.Diagnostics;
using System.IO;

namespace WebAndLoadTestProject1
{
    [TestClass]
    public class UnitTest3
    {
        // Пример выбора трех чекбоксов пользователем
        [TestMethod]
        public void WebTestScenario3()
        {
            PhantomJSDriver driver = new PhantomJSDriver();
            Stopwatch st = new Stopwatch();
            st.Start();
            driver.Navigate().GoToUrl("http://localhost:11281/");

            IWebElement query1 = driver.FindElement(By.Name("Assessment"));
            query1.Click();

            IWebElement query2 = driver.FindElement(By.XPath("//input[@name=\"NameInEng\" and @value=\"engineering\"]"));
            query2.Click();

            IWebElement query3 = driver.FindElement(By.XPath("//input[@name=\"Requirements\" and @value=\"fullprofessor\"]"));
            query3.Click();

            IWebElement result;
            do
            {
                result = driver.FindElement(By.XPath(".//*[@id='results_table']/tbody/tr[2]/td/div/div[1]"));
                Console.WriteLine(result.Text);
            }
            while (result.Text != "Engineering,Chemical");

            st.Stop();
            /*
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"E:\tests\2\note3.txt", true))
            {
                file.WriteLine(st.Elapsed);
            }
            */
            driver.Quit();
        }
    }
}
