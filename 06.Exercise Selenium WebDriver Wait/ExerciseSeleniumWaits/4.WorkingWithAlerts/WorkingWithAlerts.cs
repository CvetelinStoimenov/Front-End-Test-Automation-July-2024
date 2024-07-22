using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _4.WorkingWithAlerts
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void HandlingBasicAlerts()
        {
            driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[1]/button")).Click();
            driver.SwitchTo().Alert().Accept();
            IWebElement result = driver.FindElement(By.XPath("//*[@id='result']"));
            Assert.That(result.Text, Is.EqualTo("You successfully clicked an alert"), "The alert massage is not closed.");
        }

        [Test]
        public void HandlingConfirmationAlertsAccept()
        {
            driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button")).Click();
            driver.SwitchTo().Alert().Accept();
            IWebElement result = driver.FindElement(By.XPath("//*[@id='result']"));
            Assert.That(result.Text, Is.EqualTo("You clicked: Ok"), "The alert massage is not closed.");
        }

        [Test]
        public void HandlingConfirmationAlertsDismiss()
        {
            driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[2]/button")).Click();
            driver.SwitchTo().Alert().Dismiss();
            IWebElement result = driver.FindElement(By.XPath("//*[@id='result']"));
            Assert.That(result.Text, Is.EqualTo("You clicked: Cancel"), "The alert massage is not closed.");
        }

        [Test]
        public void HandlingPromptAlerts()
        {
            driver.FindElement(By.XPath("//*[@id='content']/div/ul/li[3]/button")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.SendKeys("I will learn Selenium!!!");
            alert.Accept();
            IWebElement result = driver.FindElement(By.XPath("//*[@id='result']"));
            Assert.That(result.Text, Is.EqualTo("You entered: I will learn Selenium!!!"), "The alert massage is not closed.");
        }
    }
}