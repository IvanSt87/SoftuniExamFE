using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class SearchContactsPage
    {
        private WebDriver driver;

        public SearchContactsPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement SearchKeywordField => driver.FindElement(By.Id("keyword"));
        public IWebElement SearchSubmitButton => driver.FindElement(By.Id("search"));
        public IWebElement SearchResult => driver.FindElement(By.Id("searchResult"));
        public IWebElement SearchResultContactFirstName => driver.FindElement(By.CssSelector("tr.fname > td"));
        public IWebElement SearchResultContactLastName => driver.FindElement(By.CssSelector("tr.lname > td"));
    }
}
