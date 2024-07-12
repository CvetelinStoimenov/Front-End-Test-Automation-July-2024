using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;

namespace LocatorsPractice
{
    public class Tests
    {
        private IWebDriver driver;
        private string baseUrl = "file:///C:/Users/cvete/source/repos/Front-End-Test-Automation-July-2024/03.Selenium WebDriver/SimpleForm/Locators.html";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {            
            // Creates a new instance of ChromeDriver
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl);

        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Creates a new instance of ChromeDriver
            driver.Quit();
            //driver.Dispose();
        }

        [Test]
        public void Test1()
        {
            var lastName = driver.FindElement(By.Id("lname"));
            Console.WriteLine(lastName.TagName);
            var newsletter = driver.FindElement(By.Name("newsletter"));
            Console.WriteLine(newsletter.TagName);
            var page = driver.FindElement(By.TagName("a"));
            Console.WriteLine(page.Text);
            var informationFields = driver.FindElement(By.ClassName("information"));
            Console.WriteLine(informationFields.TagName);


            driver.FindElement(By.CssSelector("#fname"));
            driver.FindElement(By.CssSelector(""));
            driver.FindElement(By.CssSelector(""));
            driver.FindElement(By.CssSelector(""));
            driver.FindElement(By.CssSelector(""));


            driver.FindElement(By.XPath(""));
            driver.FindElement(By.XPath(""));
            driver.FindElement(By.XPath(""));
            driver.FindElement(By.XPath(""));
            driver.FindElement(By.XPath(""));
            driver.FindElement(By.XPath(""));
        }
    }
}