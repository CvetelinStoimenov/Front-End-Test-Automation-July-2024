using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LocatorsPractice
{
    public class Tests
    {
        private IWebDriver driver;
        private string baseUrl = "file:///C:/Users/cvete/source/repos/Front-End-Test-Automation-July-2024/03.Selenium WebDriver/SimpleForm/Locators.html";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {            
            // Creates a new instance of ChromeDriver
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl);

        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Creates a new instance of ChromeDriver
            driver.Quit();
            //driver.Dispose();
        }

        [Test]
        public void LocatorsPractice()
        {
            // Locate the "Last name" input field
            driver.FindElement(By.Id("lname"));

            // Locate the "Newsletter" checkbox
            driver.FindElement(By.Name("newsletter"));

            // Locate the anchor tag
            driver.FindElement(By.TagName("a"));

            // Locate the element with class name "information"
            driver.FindElement(By.ClassName("information"));

            // Locate the link by its full text
            driver.FindElement(By.LinkText("Softuni Official Page"));

            // Locate the link by partial text
            driver.FindElement(By.PartialLinkText("Official Page"));

            // Locate the "First name" input field by ID
            driver.FindElement(By.CssSelector("#fname"));

            // Locate the "First name" input field by name attribute
            driver.FindElement(By.CssSelector("input[name='fname']"));

            // Locate the submit button by class name
            driver.FindElement(By.CssSelector("input[class*='button']"));

            // Locate the "Phone Number" input field by CSS selector
            driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']"));

            // Locate the "Phone Number" input field using a more specific CSS selector
            driver.FindElement(By.CssSelector("div.additional-info input[type='text']"));

            // Locate the male radio button using absolute XPath
            driver.FindElement(By.XPath("/html/body/form/input[1]"));

            // Locate the male radio button using relative XPath
            driver.FindElement(By.XPath("//input[@value='m']"));

            // Locate the last name input field using relative XPath
            driver.FindElement(By.XPath("//input[@name='lname']"));

            // Locate the newsletter checkbox using relative XPath
            driver.FindElement(By.XPath("//input[@type='checkbox']"));

            // Locate the submit button using relative XPath 
            driver.FindElement(By.XPath("//input[@class='button']"));

            // Locate the phone number input field within additional info using relative XPath
            driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']"));
        }
    }
}