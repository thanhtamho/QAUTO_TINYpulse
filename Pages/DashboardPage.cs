using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System;

namespace TINYpulse.Pages
{
    public class DashboardPage : TestBase
    {

        //private IWebElement LeftMenu
        //{
        //    get { return driver.FindElement(By.XPath("//div[@data-cucumber='sitebar-menu-items']")); }
        //}



        //private IWebElement PrepForLaunch
        //{
        //    get { return driver.FindElement(By.XPath("//div[text()='Preparing for Launch']")); }
        //}



        public void ClickSettings()
        {
            ClickExpandLeftMenu("settings");
        }

        public void ClickAddPeople()
        {
            ClickLinkByName("Add People");
        }


        public void ClickExpandLeftMenu(string menuItem)
        {
            Wait_for_complete(30000);
            var link = driver.FindElement(By.XPath("//li[@data-name='" + menuItem + "']"));

            link.Click();
        }

        public void ClickLinkByName(string name)
        {
            Wait_for_complete(_timeout);
            var link = driver.FindElement(By.XPath("//span[text()='" + name + "']"));

            // Create instance of Javascript executor
            IJavaScriptExecutor je = (IJavaScriptExecutor)driver;



            //Identify the WebElement which will appear after scrolling down
            IWebElement element = driver.FindElement(By.XPath("//span[text()='" + name + "']"));


            //Attributes
            // IWebElement attElement = driver.FindElement(By.XPath("//span[text()='" + "Attributes" + "']"));

            // now execute query which actually will scroll until that element is not appeared on page.

            je.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            WaitThenClick(link);

            Wait_for_complete(_timeout);
        }


    }
}
