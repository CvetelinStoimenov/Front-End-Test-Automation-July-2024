using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _2.UsingThreadSleep
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
        public void AddBoxWithThreadSleep()
        {
            // While Thread.Sleep can make tests pass by introducing fixed delays, it is inefficient and can make tests slow and unreliable.

            driver.FindElement(By.XPath("//*[@id='adder']")).Click();

            Thread.Sleep(3000);

            IWebElement newBox = driver.FindElement(By.XPath("//*[@id='box0']"));

            Assert.That(newBox.Displayed);
        }

        [Test]
        public void RevealInputWithoutWaitsFail() 
        {
            driver.FindElement(By.XPath("//*[@id='reveal']")).Click();

            Thread.Sleep(3000);

            IWebElement inputField = driver.FindElement(By.XPath("//*[@id='revealed']"));

            inputField.SendKeys("While Thread.Sleep can make tests pass by introducing fixed delays, it is inefficient and can make tests slow and unreliable.");

            Assert.That(inputField.Displayed);
            Assert.IsTrue(inputField.Displayed);
            Assert.That(inputField.GetAttribute("value"), Is.EqualTo("While Thread.Sleep can make tests pass by introducing fixed delays, it is inefficient and can make tests slow and unreliable."));
            Assert.That(inputField.TagName, Is.EqualTo("input"));
        }
    }
}