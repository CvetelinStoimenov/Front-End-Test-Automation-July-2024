using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace _4.ExplicitWaits
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
        public void AddBoxWithExplicitWait()
        {
            driver.FindElement(By.XPath("//*[@id='adder']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            IWebElement newBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible((By.XPath("//*[@id='box0']"))));

            Assert.That(newBox.Displayed);
        }

        [Test]
        public void RevealInputWithExplicitWaits()
        {

            IWebElement inputField = driver.FindElement(By.XPath("//*[@id='revealed']"));

            driver.FindElement(By.XPath("//*[@id='reveal']")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            wait.Until(d => inputField.Displayed);

            inputField.SendKeys("Displayed!");

            Assert.That(inputField.Displayed);
            Assert.IsTrue(inputField.Displayed);
            Assert.That(inputField.GetAttribute("value"), Is.EqualTo("Displayed!"));
            Assert.That(inputField.TagName, Is.EqualTo("input"));
        }
    }
}