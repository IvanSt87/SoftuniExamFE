using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class HomePage
    {
        private WebDriver driver;
        private const string baseUrl = "https://contactbook-1.ivanstalev.repl.co/";

        public HomePage(WebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement ContactsSideButton => driver.FindElement(By.XPath("//a[text()='Contacts']"));
        public IWebElement SearchSideButton => driver.FindElement(By.XPath("//a[text()='Search']"));
        public IWebElement CreateSideButton => driver.FindElement(By.XPath("//a[text()='Create']"));

        public void Open()
        {
            driver.Navigate().GoToUrl(baseUrl);
        }
    }
}
