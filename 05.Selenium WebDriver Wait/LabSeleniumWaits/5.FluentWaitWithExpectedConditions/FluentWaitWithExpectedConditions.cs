using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _5.FluentWaitWithExpectedConditions
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
        public void AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
        {
            driver.FindElement(By.XPath("//*[@id='adder']")).Click();

            // Set up FluentWait with ExpectedConditions
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement newBox = wait.Until(ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='box0']"))));

            Assert.That(newBox.Displayed);
        }
    }
}