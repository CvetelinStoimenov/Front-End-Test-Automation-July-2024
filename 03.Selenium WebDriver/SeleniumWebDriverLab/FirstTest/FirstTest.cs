using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FirstTest
{
    public class Tests
    {
        // Start the Session
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Creates a new instance of ChromeDriver
            driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            // Creates a new instance of ChromeDriver
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test_NakovCom()
        {
            // Navigating to a web page
            driver.Navigate().GoToUrl("https://nakov.com");

            //Request the Title of the Current Web Page
            var windowTitle = driver.Title;


            Assert.That(windowTitle.Contains("Svetlin Nakov – Official Web Site"));

            Console.WriteLine(windowTitle);

            var searchLink = driver.FindElement(By.ClassName("smoothScroll"));
            Assert.That(searchLink.Text, Does.Contain("SEARCH"));
            Console.WriteLine(searchLink.Text);

            searchLink.Click();

            var message = driver.FindElement(By.Id("s"));
            var placeholderText = message.GetAttribute("placeholder");
            Assert.That(placeholderText, Is.EqualTo("Search this site"));
            Console.WriteLine(placeholderText);
        }
    }
}