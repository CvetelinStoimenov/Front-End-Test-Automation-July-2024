using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics.Tracing;

namespace _6.CustomWaitsConditions
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.selenium.dev/selenium/web/dynamic.html";
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void RevealInputWithCustomFluentWait()
        {

            IWebElement inputField = driver.FindElement(By.XPath("//*[@id='revealed']"));

            driver.FindElement(By.XPath("//*[@id='reveal']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5))
            {
                PollingInterval = TimeSpan.FromMilliseconds(200),
            };
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));

            wait.Until(d => 
            {
                inputField.SendKeys("This demonstrates how to create custom conditions that are not covered by predefined expected conditions, providing flexibility in handling unique scenarios in web automation.");
                return true;
            });

            Assert.That(inputField.Displayed);
            Assert.IsTrue(inputField.Displayed);
            Assert.That(inputField.GetAttribute("value"), Is.EqualTo("This demonstrates how to create custom conditions that are not covered by predefined expected conditions, providing flexibility in handling unique scenarios in web automation."));
            Assert.That(inputField.TagName, Is.EqualTo("input"));
        }
    }
}