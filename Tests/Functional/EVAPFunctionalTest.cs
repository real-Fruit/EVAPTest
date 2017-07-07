using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SETestProject.Tests
{
    class EVAPFunctionalTest
    {
        public IWebDriver driver { get; set; }

        public EVAPFunctionalTest()
        {
            driver = new ChromeDriver();

        }
        /// <summary>
        /// Test all the mandatory fields should be validated.        
        ///Test the system should not display the error message for optional fields.
        ///Test all input fields for empty entry
        ///Test all input fields for special characters.
        ///Test the functionality of the buttons available
        ///Test the Privacy Policy & Help is clearly defined and should be available for users.
        ///Test if any functionality fails the user gets redirected to the custom error page.
        /// </summary>
        public Dictionary<string,bool> RunTest()
        {

            #region Login Logout Functionalities
            driver.Url = "http://evapp.azurewebsites.net/";
            var report = new Dictionary<string, bool>();

            //Check Empty Entry Case
            Console.Write("Login Page > Empty Form Check -> ");
            driver.FindElement(By.Id("loginbtn")).Click();
            report.Add("Login Page > Empty Form Check", driver.FindElement(By.Id("loginbtn")) != null);
            
            

            //Special Characters
            Console.Write("Login Page > Special Characters -> ");
            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("emailid")).SendKeys("mail@x.'--");
            driver.FindElement(By.Name("password")).SendKeys("\"'--");


            driver.FindElement(By.Id("loginbtn")).Click();            
            report.Add("Login Page > Special Characters", driver.FindElement(By.Id("loginbtn")) != null);

            //Wrong Username &|| Pwd Case
            Console.Write("Login Page > Wrong Credentials -> ");
            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("emailid")).SendKeys("fura@gmail.com");
            driver.FindElement(By.Name("password")).SendKeys("wrongpass");

            driver.FindElement(By.Id("loginbtn")).Click();            
            report.Add("Login Page > Wrong Credentials", driver.FindElement(By.Id("loginbtn")) != null);


            //Correct Credntl, Wrong Role
            Console.Write("Login Page > Wrong Role -> ");
            driver.FindElement(By.Id("highs")).Click();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("emailid")).SendKeys("fura@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");


            driver.FindElement(By.Id("loginbtn")).Click();            
            report.Add("Login Page > Wrong Role", driver.FindElement(By.Id("loginbtn")) != null);



            //Correct Username Pwd Case
            Console.Write("Login Page > Correct Credentials -> ");
            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("emailid")).SendKeys("fura@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");


            driver.FindElement(By.Id("loginbtn")).Click();           
            report.Add("Login Page > Correct Credentials", driver.FindElements(By.Id("loginbtn")).Count == 0 && driver.FindElement(By.Id("logout")) != null);


            //Check Logout
            Console.Write("Login Page > Logout Functionality -> ");
            driver.FindElement(By.Id("logout")).Click();
            
            report.Add("Login Page > Logout Functionality", driver.FindElement(By.Id("loginbtn")) != null && driver.FindElements(By.Id("logout")).Count == 0);
            #endregion


            #region Registration Functionality
            driver.Url = "http://evapp.azurewebsites.net/View/createAccount.php";
            driver.FindElement(By.Name("agreement")).Click();

            //Check Empty Entries
            Console.Write("Registration Page > Empty Entries -> ");
            driver.FindElement(By.Id("createAcc")).Click();
            
            report.Add("Registration Page > Empty Entries", driver.FindElement(By.Id("createAcc")) != null);

            //Check University Role
            Console.Write("Registration Page > University Role -> ");
            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("demoname");
            driver.FindElement(By.Name("emailid")).SendKeys($"demo{new Random().Next(1, 40)}@mail.com");
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");
            driver.FindElement(By.Name("confirm_password")).Clear();
            driver.FindElement(By.Name("confirm_password")).SendKeys("P4$$w0rd");

            new SelectElement(driver.FindElement(By.Name("university"))).SelectByText("Jimma");
            new SelectElement(driver.FindElement(By.Name("field"))).SelectByText("Enginering");
            new SelectElement(driver.FindElement(By.Name("department"))).SelectByText("Mechanical");
            new SelectElement(driver.FindElement(By.Name("year"))).SelectByText("3rd year");

            report.Add("Registration Page > University Role", driver.FindElements(By.XPath("//*[contains(text(),'REGISTRATION SUCCESS')]")).Count > 0);

            //Check High School Role
            driver.Url = "http://evapp.azurewebsites.net/View/createAccount.php";

            Console.Write("Registration Page > High School Role -> ");
            driver.FindElement(By.Id("highs")).Click();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("demoname");
            driver.FindElement(By.Name("emailid")).SendKeys("demo@mail.com");
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");
            driver.FindElement(By.Name("confirm_password")).Clear();
            driver.FindElement(By.Name("confirm_password")).SendKeys("P4$$w0rd");

            

            driver.FindElement(By.Id("createAcc")).Click();
           
            report.Add("Registration Page > High School Role", driver.FindElements(By.XPath("//*[contains(text(),'REGISTRATION SUCCESS')]")).Count > 0);

            //Check Instructor Role
            driver.Url = "http://evapp.azurewebsites.net/View/createAccount.php";

            Console.Write("Registration Page > Instructor Role -> ");
            driver.FindElement(By.Id("inst")).Click();
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("username")).SendKeys("demoname");
            driver.FindElement(By.Name("emailid")).SendKeys("demo@mail.com");
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");
            driver.FindElement(By.Name("confirm_password")).Clear();
            driver.FindElement(By.Name("confirm_password")).SendKeys("P4$$w0rd");

            report.Add("Registration Page > Instructor Role", driver.FindElements(By.XPath("//*[contains(text(),'REGISTRATION SUCCESS')]")).Count > 0);

            #endregion




            #region Privacy Policy and Help
            driver.Url = "http://evapp.azurewebsites.net/";

            Console.Write("Privacy Policy Functionality -> ");
            driver.FindElement(By.Id("policies")).Click();            

            report.Add("Privacy Policy Functionality", !driver.FindElement(By.Id("policies")).GetAttribute("href").Equals(""));


            driver.Url = "http://evapp.azurewebsites.net/";

            Console.Write("Help Functionality -> ");
            driver.FindElement(By.Id("helpImg")).Click();          

            report.Add("Help Functionality", !(driver.FindElements(By.XPath("//*[contains(text(),'temporarily unavailable')]")).Count > 0));


            #endregion


            #region Discussion Panel Question Post
            driver.Url = "http://evapp.azurewebsites.net/";

            Console.Write("Discussion Panel -> ");
            driver.FindElement(By.Id("univ")).Click();
            driver.FindElement(By.Name("emailid")).Clear();
            driver.FindElement(By.Name("emailid")).SendKeys("fura@gmail.com");
            driver.FindElement(By.Name("password")).Clear();
            driver.FindElement(By.Name("password")).SendKeys("P4$$w0rd");


            driver.FindElement(By.Id("loginbtn")).Click();
            driver.FindElement(By.Id("godiscussion")).Click();

            //Check Empty question entry
            Console.Write("Discussion Panel > Empty QUestion Entry -> ");
            driver.FindElement(By.Name("ask")).Click();          

            report.Add("Discussion Panel > Empty QUestion Entry", driver.FindElements(By.XPath("//*[contains(text(),'Empty Question Error')]")).Count > 0);

            //Check special character validation
            Console.Write("Discussion Panel > Special Character Validation -> ");
            driver.FindElement(By.Name("post_content")).SendKeys("'--");
            driver.FindElement(By.Name("ask")).Click();
            
            report.Add("Discussion Panel > Special Character Validation", driver.FindElements(By.XPath("//*[contains(text(),'Empty Question Error')]")).Count > 0);

            #endregion



            #region Search Func
            driver.Url = "http://evapp.azurewebsites.net/";
            Console.Write("Search Functionality -> ");

            driver.FindElement(By.Name("search")).SendKeys("content");
            try
            {
                driver.FindElement(By.Name("submit")).Click();
                report.Add("Search Functionality", !(driver.FindElements(By.XPath("//*[contains(text(),'temporarily unavailable')]")).Count > 0));

            }
            catch
            {
                report.Add("Search Functionality", false);

            }
            
            #endregion
            return report;
        }



    }
}
