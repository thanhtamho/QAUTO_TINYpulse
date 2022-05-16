using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;
using TINYpulse.Entity;
using System.Collections.Generic;

namespace TINYpulse.Pages
{
    public class CongratulationsPage : TestBase
    {
        private string finishUrl = "https://staging.tinyserver.info/home/tps/invite/finish";
        private string errormsg = "error\r\nUh oh! Unable to add user because email already exists";

        private IWebElement SumaryLable
        {

            get { return driver.FindElement(By.XPath("//table[@data-cucumber='user-list-engage']/preceding-sibling::div")); }
        }

        private IWebElement ErrorMessage
        {

            get { return driver.FindElement(By.XPath("//i[text()='error']/parent::div")); }
        }

        public void Check_Finish_Page_Loaded(List<PeopleEntity> employees)
        {
            Wait_for_complete(_timeout);
            String currentURL = driver.Url;
            string summaryText = "";
            Assert.AreEqual(finishUrl, currentURL);

            if (employees.Count > 1)
            {
                summaryText = "employees have been added to TINYpulse";
            }
            else
            {
                summaryText = "employee has been added to TINYpulse";
            }
            Assert.AreEqual(employees.Count + " " + summaryText, SumaryLable.Text);


        }


        public void Check_Error_Message_Displays()
        {
            WaitForElement(driver, ErrorMessage, _timeout);
            Assert.AreEqual(errormsg, ErrorMessage.Text);
        }

        public void Check_People_is_added(int i, PeopleEntity employee)
        {
            int rowStart = i + 1;



            IWebElement efirstName = driver.FindElement(By.XPath("//tbody/tr[" + rowStart + "]/td[1]//child::span/span/span"));
            IWebElement elastName = driver.FindElement(By.XPath("//tbody/tr[" + rowStart + "]/td[2]//child::span/span/span"));
            //IWebElement eemail = driver.FindElement(By.XPath("//tbody/tr[" + rowStart + "]/td[3]//child::span/span/span"));
            IWebElement eemail = driver.FindElement(By.XPath("//tbody/tr[" + rowStart + "]/td[3]/div"));

            string emailString = eemail.GetAttribute("data-original-title");

            Assert.AreEqual(employee.FirstName, efirstName.Text);
            Assert.AreEqual(employee.LastName, elastName.Text);
            Assert.AreEqual(employee.Email, emailString);



            // Start Date
            try
            {
                var estartDate = driver.FindElement(By.XPath("//tbody/tr[" + rowStart + "]/td[4]//child::span/span/span"));
                Assert.AreEqual(employee.StartDate, estartDate.Text);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Start Date value is blank");
            }

            //Manager
            //try
            //{
            //    var emanager = driver.FindElement(By.XPath("//tbody/tr[" + rowStart + "]/td[5]//child::span/span/span"));
            //    Assert.AreEqual(employee.Manager, emanager.Text);
            //}
            //catch (NoSuchElementException)
            //{
            //    Console.WriteLine("Manager value is blank");
            //}

            //PositionTile
            try
            {
                var epositionTile = driver.FindElement(By.XPath("//tbody/tr[" + rowStart + "]/td[6]//child::span/span/span"));
                Assert.AreEqual(employee.PositionTile, epositionTile.Text);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Position Tile value is blank");
            }


        }
    }
}
