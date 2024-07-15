using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestFormSubmission
{
    public class Tests
    {
        private IWebDriver driver;
        WebDriverWait wait;
        private string baseUrl = "file:///C:/Users/cvete/source/repos/Front-End-Test-Automation-July-2024/03.Selenium WebDriver/SimpleForm/Locators.html";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Creates a new instance of ChromeDriver
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
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
        public void Test_Form()
        {
            var title = driver.FindElement(By.XPath("//h2"));
            Assert.That(title.Text, Is.EqualTo("Contact Form"), "Contact Form title is incorrect");

            var maleRadioButton = driver.FindElement(By.CssSelector("input[type='radio'][value='m']"));
            maleRadioButton.Click();

            Assert.IsTrue(maleRadioButton.Selected, "Male radio button is not selected");

            var fnameField = driver.FindElement(By.Id("fname"));
            fnameField.Clear();
            fnameField.SendKeys("Butch");
            Assert.That(fnameField.GetAttribute("value"), Is.EqualTo("Butch"), "First name value is incorrect after entering new value");

            var lnameField = driver.FindElement(By.Id("lname"));
            lnameField.Clear();
            lnameField.SendKeys("Coolidge");
            Assert.That(lnameField.GetAttribute("value"), Is.EqualTo("Coolidge"), "Last name value is incorrect after entering new value");

            var additionalInfo = driver.FindElement(By.XPath("//div[@class='additional-info']"));
            Assert.IsTrue(additionalInfo.Displayed, "Additional Info is not displayed");

            var phoneNumber = driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']"));
            phoneNumber.SendKeys("0888999777");
            Assert.That(phoneNumber.GetAttribute("value"), Is.EqualTo("0888999777"), "Phone number is incorrect");

            var newsletter = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            newsletter.Click();
            Assert.That(newsletter.GetAttribute("type"), Is.EqualTo("checkbox"), "Incorrect attribute type for newsletter checkbox");

            var submitButton = driver.FindElement(By.CssSelector("input[class*='button']"));
            submitButton.Click();

            var greeting = wait.Until(driver => driver.FindElement(By.XPath("//h1")));
            Assert.That(greeting.Text, Is.EqualTo("Thank You!"), "Thank You! message is missing");
    }
    }
}