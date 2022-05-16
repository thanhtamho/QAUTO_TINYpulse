using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;

namespace TINYpulse.Pages
{
    public class AddPeoplePage : TestBase
    {
        private IWebElement SearchText
        {
            get { return driver.FindElement(By.XPath("//input[@placeholder='Search...']")); }
        }

        private IWebElement AddPeople
        {
            get { return driver.FindElement(By.XPath("//span[text()='Add People']/parent::div")); }
        }


        public void EnterFirstName(int i, string firstName)
        {
            Wait_for_complete(_timeout);

            var efirstname = driver.FindElement(By.XPath("//tr[" + i + "]//input[@field='firstName']"));

            efirstname.SendKeys(firstName);
        }

        public void EnterLastName(int i, string lastName)
        {
            //IWebElement elastname = FindElementUntilExists(driver, By.XPath("//tr[" + i + "]//input[@field='lastName']"), _timeout);
            var elastname = driver.FindElement(By.XPath("//tr[" + i + "]//input[@field='lastName']"));

            elastname.SendKeys(lastName);

        }

        public void EnterEmail(int i, string email)
        {
            //IWebElement eemail = FindElementUntilExists(driver, By.XPath("//tr[" + i + "]//input[@field='email']"), _timeout);
            var eemail = driver.FindElement(By.XPath("//tr[" + i + "]//input[@field='email']"));

            eemail.SendKeys(email);

        }

        public void SelectStartDate(int i, DateTime startDate)
        {
            // optional field
        }

        public void SelectManager(int i, string managerEmail)
        {
            var emanager = driver.FindElement(By.XPath("//tr[" + i + "]//span[text()='Select ...']"));
            emanager.Click();


            // Search
            SearchText.SendKeys(managerEmail);
            Wait_for_complete(_timeout);

            try
            {
                IWebElement button = driver.FindElement(By.XPath("//div[@class='select-email-item']//child::p"));
                button.Click();
            }
            catch (StaleElementReferenceException)
            {
                IWebElement button = driver.FindElement(By.XPath("//div[@class='select-email-item']//child::p"));
                button.Click();
            }


        }

        public void SelectPositionTile(int i, string positionTitle)
        {
            //optional field

        }

        public void AddPeopleToList(int i, string firstName, string lastName, string email, DateTime startDate, string manager, string positionTitle)
        {
            int rowStart = i + 1;

            EnterFirstName(rowStart, firstName);

            EnterLastName(rowStart, lastName);

            EnterEmail(rowStart, email);

            SelectStartDate(rowStart, startDate);

            SelectManager(rowStart, manager);

            SelectPositionTile(rowStart, positionTitle);
        }

        public void SubmitAddPeople()
        {
            AddPeople.Click();
        }
    }
}
