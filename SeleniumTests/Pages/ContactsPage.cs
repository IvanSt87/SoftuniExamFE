using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class ContactsPage
    {
        private WebDriver driver;

        public ContactsPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ContactOneFirstName => driver.FindElement(By.CssSelector("#contact1 > tbody > tr.fname > td"));
        public IWebElement ContactOneLastName => driver.FindElement(By.CssSelector("#contact1 > tbody > tr.lname > td"));
    }
}
