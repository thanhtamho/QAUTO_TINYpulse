using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;

namespace TINYpulse.Pages
{
    public class LoginPage : TestBase
    {
        private IWebElement LoginLink
        {

            get { return driver.FindElement(By.XPath("//*[text()='Login']")); }
        }

        private IWebElement UserName
        {
            get { return driver.FindElement(By.XPath("//input[@data-cucumber='input-login-email']")); }
        }

        private IWebElement Password
        {
            get { return driver.FindElement(By.XPath("//input[@data-cucumber='input-login-password']")); }
        }

        private IWebElement Continue
        {
            get { return driver.FindElement(By.XPath("//div[@data-cucumber='button-continue']")); }
        }

        private IWebElement SignIn
        {
            get { return driver.FindElement(By.XPath("//div[@data-cucumber='button-login']")); }
        }

        public void OpenLoginPage()
        {
            WaitThenClick(LoginLink);
        }

        public void login()
        {
            // Enter Username
            UserName.SendKeys(username);
            Continue.Click();

            WaitForElement(driver, Password, _timeout);

            // Enter Password
            Password.SendKeys(password);
            SignIn.Click();
        }





    }
}
