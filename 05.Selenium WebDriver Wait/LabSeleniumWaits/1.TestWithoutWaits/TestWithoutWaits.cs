using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _1.TestWithoutWaits
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
        public void AddBoxWithoutWaitsFails()
        {
            driver.FindElement(By.XPath("//*[@id='adder']")).Click();

            IWebElement newBox = driver.FindElement(By.XPath("//*[@id='box0']"));

            Assert.That(newBox.Displayed);
        }

        [Test]
        public void RevealInputWithoutWaitsFail()
        {
            driver.FindElement(By.XPath("//*[@id='reveal']")).Click();

            IWebElement newInputFiled = driver.FindElement(By.XPath("//*[@id='revealed']"));

            newInputFiled.SendKeys("reviled");
            
            Assert.IsTrue(newInputFiled.Displayed);
            Assert.That(newInputFiled.GetAttribute("value"), Is.EqualTo("Displayed"));
        }
    }
}