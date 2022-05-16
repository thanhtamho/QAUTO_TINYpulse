using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace TINYpulse
{
    public class Browser
    {
        public static ChromeDriver driver;

        //public static Iwe Instance { get; set; }

        public static ChromeDriver getDriver()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();

            }
            return driver;
        }

        public static void close_Browser()
        {
            driver.Close();
            driver.Quit();
            driver = null;
        }

    }
}

    



