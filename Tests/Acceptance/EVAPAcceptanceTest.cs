using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETestProject.Tests
{
    class EVAPAcceptanceTest
    {
        public Dictionary<string, bool> RunTest()
        {
            IWebDriver driver = new ChromeDriver();

            var report = new Dictionary<string, bool>();

            #region Login, Logout Success and Failure


            bool go = false;

            while (!go)
            {

                driver.Url = "http://evapp.azurewebsites.net/";
                try
                {
                    var x = driver.FindElement(By.Id("univ")) == null;
                    go = true;
                }
                catch { go = false; }
            }

            Console.Write("Login Success -> ");
            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("emailid")).SendKeys("fura@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");


            driver.FindElement(By.Id("loginbtn")).Click();

            report.Add("Login Success", driver.Url.EndsWith("View/home.php", StringComparison.Ordinal));


            Console.Write("Logout Success -> ");

            driver.FindElement(By.Id("logout")).Click();

            report.Add("Logout Success", driver.Url.EndsWith("/indexx.php", StringComparison.Ordinal));



            Console.Write("Login Failure -> ");

            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("emailid")).SendKeys("fura@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0d");


            driver.FindElement(By.Id("loginbtn")).Click();

            report.Add("Logout Failure", driver.FindElements(By.XPath("//*[contains(text(),'Login Error')]")).Count > 0);


            #endregion


            #region Navigations After Login

            driver.Url = "http://evapp.azurewebsites.net/";

            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("emailid")).SendKeys("fura@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");

            driver.FindElement(By.Id("loginbtn")).Click();


            //Discussion Panel
            Console.Write("Discussion Panel -> ");
            driver.FindElement(By.Id("godiscussion")).Click();

            report.Add("Navigate to Discussion Panel", driver.Url.EndsWith("/DiscussionPanel.php", StringComparison.Ordinal));


            //Share Material
            Console.Write("Share Material -> ");
            driver.FindElement(By.Id("goexercise")).Click();

            report.Add("Navigate to Share Material", driver.Url.EndsWith("/exersiseView.php", StringComparison.Ordinal));


            //Host Group Project
            Console.Write("Host Group Project -> ");
            driver.FindElement(By.Id("gohostproject")).Click();

            report.Add("Navigate to Host Group Project", driver.Url.EndsWith("/hostGroupProject.php", StringComparison.Ordinal));


            //Get Exercises
            Console.Write("Get Exercises -> ");
            driver.FindElement(By.Id("gogetex")).Click();

            report.Add("Navigate to Get Exercise", driver.Url.EndsWith("/getexercise.php", StringComparison.Ordinal));


            //Assignment Submission
            Console.Write("Assignment Submission -> ");
            driver.FindElement(By.Id("gosubmitassign")).Click();

            report.Add("Navigate to Assignment Submission", driver.Url.EndsWith("/submitAssignment.php", StringComparison.Ordinal));



            //Browse Content by category
            Console.Write("Browse Content by category -> ");
            driver.FindElement(By.Id("gocontentBrowse")).Click();


            report.Add("Navigate to Browse Content by category", driver.Url.EndsWith("/BrowseContentByCategory.php", StringComparison.Ordinal));

            #endregion
            return report;

        }

    }
}
