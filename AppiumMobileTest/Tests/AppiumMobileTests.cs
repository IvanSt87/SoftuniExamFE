using AppiumMobileTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Android;

namespace AppiumMobileTests;

public class AppiumMobileTests : BaseTest
{

    private AppiumPages pages;

    [SetUp]
    public void PreparePages()
    {
        pages = new AppiumPages(driver);
    }

    [Test]
    public void Test_AssertSearchByKeywordIsReturningCorrectContact()
    {
        // Arrange and Act
        var expectedResult = "Steve Jobs";
        var actualResult = pages.SearchForSpecificContactAndReturnResult("https://contactbook-1.ivanstalev.repl.co/api", "steve");

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedResult));
    }
}
