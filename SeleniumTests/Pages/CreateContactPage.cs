using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class CreateContactPage
    {
        private WebDriver driver;

        public CreateContactPage(WebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement FirstNameField => driver.FindElement(By.Id("firstName"));
        public IWebElement LastNameField => driver.FindElement(By.Id("lastName"));
        public IWebElement EmailField => driver.FindElement(By.Id("email"));
        public IWebElement PhoneField => driver.FindElement(By.Id("phone"));
        public IWebElement CommentsField => driver.FindElement(By.Id("comments"));
        public IWebElement CreateContactButton => driver.FindElement(By.Id("create"));
        public IWebElement ErrorMessage => driver.FindElement(By.ClassName("err"));
        public IWebElement CreatedContactFirstName => driver.FindElements(By.CssSelector(".contacts-grid > a > table > tbody > tr.fname > td")).Last();
        public IWebElement CreatedContactLastName => driver.FindElements(By.CssSelector(".contacts-grid > a > table > tbody > tr.lname > td")).Last();

        public void CreateContact(string firstName, string lastName, string email, string phone)
        {
            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            EmailField.SendKeys(email);
            PhoneField.SendKeys(phone);

            CreateContactButton.Click();
        }
    }
}
