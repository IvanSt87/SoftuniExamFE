using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMobileTests
{
    public class BaseTest
    {
        protected const string appiumBaseUrl = "http://[::1]:4723/wd/hub";
        protected const string appLocation = @"/Users/ivanstalev/Downloads/contactbook-androidclient.apk";
        protected AndroidDriver<AndroidElement> driver;
        protected AppiumOptions options;

        [SetUp]
        public void OpenApplication()
        {
            options = new AppiumOptions();
            options.AddAdditionalCapability("platformName", "Android");
            options.AddAdditionalCapability("app", appLocation);
            driver = new AndroidDriver<AndroidElement>(new Uri(appiumBaseUrl), options);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
