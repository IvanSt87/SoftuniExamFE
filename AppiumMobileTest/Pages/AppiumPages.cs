using AppiumMobileTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMobileTests.Pages
{
    public class AppiumPages : BasePage
    {
        public AppiumPages(AndroidDriver<AndroidElement> driver) : base(driver)
        {
        }

        public AndroidElement contactBookAPIField => driver.FindElementById("contactbook.androidclient:id/editTextApiUrl");
        public AndroidElement connectAPIButton => driver.FindElementById("contactbook.androidclient:id/buttonConnect");
        public AndroidElement keywordField => driver.FindElementById("contactbook.androidclient:id/editTextKeyword");
        public AndroidElement searchButton => driver.FindElementById("contactbook.androidclient:id/buttonSearch");
        public AndroidElement searchedContactFirstName => driver.FindElementById("contactbook.androidclient:id/textViewFirstName");
        public AndroidElement searchedContactLastName => driver.FindElementById("contactbook.androidclient:id/textViewLastName");

        public string SearchForSpecificContactAndReturnResult(string apiUrl, string searchForText)
        {
            contactBookAPIField.Clear();
            contactBookAPIField.SendKeys(apiUrl);
            connectAPIButton.Click();
            keywordField.SendKeys(searchForText);
            searchButton.Click();

            return $"{searchedContactFirstName.Text} {searchedContactLastName.Text}";
        }
    }
}
