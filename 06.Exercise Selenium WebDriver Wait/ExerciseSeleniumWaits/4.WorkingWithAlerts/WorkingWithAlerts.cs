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
        }
    }
}