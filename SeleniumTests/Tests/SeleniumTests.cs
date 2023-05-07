using NUnit.Framework;
using SeleniumTests.Tests;
using SeleniumTests.Pages;

namespace SeleniumTests;

public class SeleniumTests : BaseTest
{
    private HomePage homePage;
    private ContactsPage contactsPage;
    private SearchContactsPage searchContactsPage;
    private CreateContactPage createContactPage;
    private Random randomNumber;


    [SetUp]
    public void OpenPage()
    {
        homePage = new HomePage(driver);
        contactsPage = new ContactsPage(driver);
        searchContactsPage = new SearchContactsPage(driver);
        createContactPage = new CreateContactPage(driver);
        randomNumber = new Random();

        homePage.Open();
    }

    [Test]
    public void Test_AssertFirstContactIsSteveJobs()
    {
        // Click on the Contacts side link
        homePage.ContactsSideButton.Click();

        // Assert that first contact is Steve Jobs
        var expectedResult = "Steve Jobs";
        var actualResult = $"{contactsPage.ContactOneFirstName.Text} {contactsPage.ContactOneLastName.Text}";

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AssertSearchByKeywordIsReturningCorrectContact()
    {
        // Click on the Search side link, and search for keyword "albert"
        homePage.SearchSideButton.Click();
        searchContactsPage.SearchKeywordField.SendKeys("albert");

        // Click on the search button, and assert that first result holds Albert Einstein
        searchContactsPage.SearchSubmitButton.Click();
        var expectedResult = "Albert Einstein";
        var actualResult = $"{searchContactsPage.SearchResultContactFirstName.Text} {searchContactsPage.SearchResultContactLastName.Text}";

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }

    [Test]
    public void Test_AssertSearchByKeywordForNotExistingContact()
    {
        // Click on the Search side link, and search for not existing contact
        homePage.SearchSideButton.Click();
        searchContactsPage.SearchKeywordField.SendKeys($"missing{randomNumber.Next(100, 200)}");

        // Click on the search button, and assert that first result holds Albert Einstein
        searchContactsPage.SearchSubmitButton.Click();

        Assert.That(searchContactsPage.SearchResult.Text, Is.EqualTo("No contacts found."));
    }

    [Test]
    public void Test_CreateNewContactWithMissingFirstName()
    {
        // Click on the Create side link
        homePage.CreateSideButton.Click();

        // Create new contact with missing first name 
        createContactPage.CreateContact("", "Stalev", "ivan@abv.bg", "123516");

        Assert.That(createContactPage.ErrorMessage.Text, Is.EqualTo("Error: First name cannot be empty!"));
    }

    [Test]
    public void Test_CreateNewContactWithValidData()
    {
        // Click on the Create side link
        homePage.CreateSideButton.Click();

        // Create new contact with valid data
        createContactPage.CreateContact("Ivan", "Stalev", "ivan@abv.bg", "123516");

        // Assert that contact is added as the last in the list of contacts
        var expectedResult = "Ivan Stalev";
        var actualResult = $"{createContactPage.CreatedContactFirstName.Text} {createContactPage.CreatedContactLastName.Text}";

        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
