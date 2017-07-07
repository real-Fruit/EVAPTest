using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETestProject.Tests
{
    class EVAPPerformanceTest
    {
        public Dictionary<string, TimeSpan> RunTest()
        {
            //Response Times
            var report = new Dictionary<string, TimeSpan>();
            IWebDriver driver = new ChromeDriver();

            //Main Page Navigation Response Time
            var startTime = DateTime.Now;

            driver.Url = "http://evapp.azurewebsites.net/";


            report.Add("Main Page (URL) Hit Response time", DateTime.Now.Subtract(startTime));


            //Login Response Time Test
            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("emailid")).SendKeys("fura@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");
            startTime = DateTime.Now;


            driver.FindElement(By.Id("loginbtn")).Click();

            report.Add("Login Response time", DateTime.Now.Subtract(startTime));



            return report;




        }

    }
}
