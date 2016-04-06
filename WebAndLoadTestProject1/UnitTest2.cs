using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium;
using System.Diagnostics;
using System.IO;

namespace WebAndLoadTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void WebTestScenario2()
        {
            PhantomJSDriver driver = new PhantomJSDriver();
            Stopwatch st = new Stopwatch();
            st.Start();
            driver.Navigate().GoToUrl("http://localhost:11281/");
            
            
                IWebElement firstDiv = driver.FindElement(By.XPath(".//*[@id=\"advanced_search\"]/div[2]/row[1]/div/div[" + 1 + "]/input"));
                firstDiv.Click();

                IWebElement secondDiv = driver.FindElement(By.XPath(".//*[@id=\"advanced_search\"]/div[2]/row[2]/div/div[" + 1 + "]/input"));
                secondDiv.Click();
            
           
            
            Console.WriteLine("Page title is: " + driver.Title);
            st.Stop();
                      
            /*
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"E:\tests\2\note2.txt", true))
            {
                file.WriteLine(st.Elapsed);
            }
            */

            driver.Quit();

        }
    }
}
