using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _3.ImplicitWaits
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
        public void AddBoxWithImplicitWait()
        {
            //Implicit waits instruct Selenium to wait up to a specified amount of time before throwing an exception if the element is not found, improving reliability for dynamic content. This wait is set globally, meaning it applies to all elements in the WebDriver session.
            driver.FindElement(By.XPath("//*[@id='adder']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    
            IWebElement newBox = driver.FindElement(By.XPath("//*[@id='box0']"));

            Assert.That(newBox.Displayed);
        }

        [Test]
        public void RevealInputWithImplicitWaits()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("//*[@id='reveal']")).Click();

            IWebElement inputField = driver.FindElement(By.XPath("//*[@id='revealed']"));

            inputField.SendKeys("Implicit waits instruct Selenium to wait up to a specified amount of time before throwing an exception if the element is not found, improving reliability for dynamic content. This wait is set globally, meaning it applies to all elements in the WebDriver session.");

            Assert.That(inputField.Displayed);
            Assert.IsTrue(inputField.Displayed);
            Assert.That(inputField.GetAttribute("value"), Is.EqualTo("Implicit waits instruct Selenium to wait up to a specified amount of time before throwing an exception if the element is not found, improving reliability for dynamic content. This wait is set globally, meaning it applies to all elements in the WebDriver session."));
            Assert.That(inputField.TagName, Is.EqualTo("input"));
        }
    }
}