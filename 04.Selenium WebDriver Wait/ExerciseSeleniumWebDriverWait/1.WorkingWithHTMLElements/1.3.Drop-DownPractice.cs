using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WorkingWithHTMLElements
{
    public class DropDownPractice
    {
        private IWebDriver driver;
        private string baseURL = "http://practice.bpbonline.com/";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseURL);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}