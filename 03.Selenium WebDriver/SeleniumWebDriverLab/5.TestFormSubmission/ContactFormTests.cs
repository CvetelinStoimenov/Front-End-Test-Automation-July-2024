using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumNUnitTest
{
    [TestFixture]
    public class ContactFormTests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void Setup()
        {
            // Initialize the Chrome WebDriver
            driver = new ChromeDriver();
            // Initialize WebDriverWait with a longer timeout (e.g., 20 seconds)
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            // Load the HTML file (update the path to your file)
            driver.Navigate().GoToUrl("file:///C:/Users/cvete/source/repos/Front-End-Test-Automation-July-2024/03.Selenium WebDriver/SimpleForm/Locators.html");
        }

        [Test]
        public void Test_FormSubmission()
        {
            // Assert the "Contact Form" title
            var title = driver.FindElement(By.XPath("//h2"));
            Assert.That(title.Text, Is.EqualTo("Contact Form"), "Contact Form title is incorrect");

            // Select the male radio button and assert its selection
            var maleRadioButton = driver.FindElement(By.CssSelector("input[type='radio'][value='m']"));
            maleRadioButton.Click();
            Assert.IsTrue(maleRadioButton.Selected, "Male radio button is not selected");

            // Enter "Butch" as the first name and assert the entered value
            var fnameField = driver.FindElement(By.Id("fname"));
            fnameField.Clear();
            fnameField.SendKeys("Butch");
            Assert.That(fnameField.GetAttribute("value"), Is.EqualTo("Butch"), "First name value is incorrect after entering new value");

            // Enter "Coolidge" as the last name and assert the entered value
            var lnameField = driver.FindElement(By.Id("lname"));
            lnameField.Clear();
            lnameField.SendKeys("Coolidge");
            Assert.That(lnameField.GetAttribute("value"), Is.EqualTo("Coolidge"), "Last name value is incorrect after entering new value");

            // Assert the presence of the "Additional Information" section
            var additionalInfo = driver.FindElement(By.XPath("//div[@class='additional-info']"));
            Assert.IsTrue(additionalInfo.Displayed, "Additional Info section is not displayed");

            // Enter "0888999777" as the phone number and assert the entered value
            var phoneNumber = driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']"));
            phoneNumber.SendKeys("0888999777");
            Assert.That(phoneNumber.GetAttribute("value"), Is.EqualTo("0888999777"), "Phone number value is incorrect after entering new value");

            // Select the newsletter checkbox and assert its selection
            var newsletter = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            newsletter.Click();
            Assert.That(newsletter.Selected, Is.True, "Newsletter checkbox should be selected");

            // Click the submit button
            var submitButton = driver.FindElement(By.CssSelector("input[class*='button']"));
            submitButton.Click();

            // Wait for the "Thank You!" message to appear on the next page
            try
            {
                wait.Until(driver => driver.FindElement(By.XPath("//h1[text()='Thank You!']")));
            }
            catch (WebDriverTimeoutException)
            {
                // Optionally, take screenshots or additional actions upon timeout
                Assert.Fail("Timeout waiting for Thank You message to appear");
            }
        }

        [TearDown]
        public void TearDown()
        {
            // Close the WebDriver after tests
            driver.Quit();
        }
    }
}
