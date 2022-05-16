using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using System;
using TINYpulse.Entity;

namespace TINYpulse.Pages
{

    public class TestBase
    {
        protected string url = "https://staging.tinyserver.info/engage/signup";
        public IWebDriver driver = Browser.getDriver();
        //public WebDriver driver;
        protected string username = "thanh.hau90@gmail.com";
        protected string password = "Thanhtam12";
        public int _timeout = 5000;
        public LoginPage _loginPage;
        public DashboardPage _dashboard;
        public AddPeoplePage _addPeople;
        public CongratulationsPage _congratulationsPage;

        public PeopleEntity _employee1;




        [SetUp]
        public void start_Browser()
        {
            driver = Browser.getDriver();
            driver.Navigate().GoToUrl(url);

            Wait_for_complete(1000);
            driver.Manage().Window.Maximize();
            
        }

        [TearDown]
        public void close_Browser()
        {
            Browser.close_Browser();

            driver = null;
        }

        public void WaitThenClick(IWebElement element)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }
        //public IWebElement FindElementUntilExists(IWebDriver driver, By by, int timeoutInSeconds)
        //{
        //    if (timeoutInSeconds > 0)
        //    {
        //        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        //        return wait.Until(drv => drv.FindElement(by));
        //    }
        //    return driver.FindElement(by);
        //}

        public static void WaitForElement(IWebDriver driver, IWebElement element, int timeout)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeout)).Until(ElementIsVisible(element));
        }

        private static Func<IWebDriver, bool> ElementIsVisible(IWebElement element)
        {
            return driver =>
            {
                try
                {
                    return element.Displayed;
                }
                catch (Exception)
                {
                    // If element is null, stale or if it cannot be located
                    return false;
                }
            };
        }

        //public void Wait_for_complete()
        //{
        //    System.Threading.Thread.Sleep(5000);
        //}
        public void Wait_for_complete(int waitingTime)
        {
            System.Threading.Thread.Sleep(waitingTime);
        }

        public void LoginToTINYpulse()
        {
            _loginPage = new LoginPage();
            _loginPage.OpenLoginPage();

            _loginPage.login();

        }

        public void GoToAddPeople()
        {
            _dashboard = new DashboardPage();

            _dashboard.ClickSettings();
            _dashboard.ClickAddPeople();
        }

        


    }
}
