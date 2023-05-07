using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMobileTests.Pages
{
    public class BasePage
    {
        protected AndroidDriver<AndroidElement> driver;

        public BasePage(AndroidDriver<AndroidElement> driver)
        {
            this.driver = driver;
        }
    }
}
