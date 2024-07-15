using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        public void LocatorsPractice()
        {
            var lastName = driver.FindElement(By.Id("lname"));
            Console.WriteLine(lastName.TagName);
            var newsletter = driver.FindElement(By.Name("newsletter"));
            Console.WriteLine(newsletter.TagName);
            var page = driver.FindElement(By.TagName("a"));
            Console.WriteLine(page.Text);
            var informationFields = driver.FindElement(By.ClassName("information"));
            Console.WriteLine(informationFields.TagName);

            var linkedText = driver.FindElement(By.LinkText("Softuni Official Page"));
            Console.WriteLine(linkedText.TagName);
            var partialText = driver.FindElement(By.PartialLinkText("Official Page"));
            Console.WriteLine(partialText.TagName);

            var cssClass = driver.FindElement(By.CssSelector("#fname"));
            Console.WriteLine(cssClass.TagName);
            var cssName = driver.FindElement(By.CssSelector("input[name='fname']"));
            Console.WriteLine(cssClass.TagName);
            var cssButton = driver.FindElement(By.CssSelector("input[class*='button']"));
            Console.WriteLine(cssButton.TagName);
            var cssChild = driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']"));
            Console.WriteLine(cssChild.TagName);
            var cssType = driver.FindElement(By.CssSelector("div.additional-info input[type='text']"));
            Console.WriteLine(cssType.TagName);


            driver.FindElement(By.XPath("/html/body/form/input[1]"));
            driver.FindElement(By.XPath("//input[@value='m']"));
            driver.FindElement(By.XPath("//input[@name='lname']"));
            driver.FindElement(By.XPath("//input[@type='checkbox']"));
            driver.FindElement(By.XPath("//input[@class='button']"));
            driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']"));
        }
    }
}