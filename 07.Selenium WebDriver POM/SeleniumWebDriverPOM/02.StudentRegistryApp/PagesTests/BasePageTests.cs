using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _02.StudentRegistryApp.PagesTests
{
    public class BasePageTests
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            this.driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
