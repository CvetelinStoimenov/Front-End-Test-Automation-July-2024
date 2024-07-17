using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WorkingWithHTMLElements
{
    public class TestsHandlingFormInput
    {
        private IWebDriver driver;
        private string baseURL = "http://practice.bpbonline.com/";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Creates a new instance of ChromeDriver
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseURL);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        private string Email()
        {
            Random random = new Random();
            int num = random.Next(1000, 9999);
            return "pesho" + num.ToString() + "@gmail.com";
        }

        [Test]
        public void Login_WithValidData()
        {

            var myAccountButton = driver.FindElement(By.XPath("//span//a[@id='tdb3']"));
            myAccountButton.Click();
            var continueButton = driver.FindElement(By.XPath("//a[@id='tdb4']"));
            continueButton.Click();
            driver.FindElement(By.XPath("//input[@value='m']")).Click();
            driver.FindElement(By.XPath("//input[@name='firstname']")).SendKeys("Pesho");
            driver.FindElement(By.XPath("//input[@name='lastname']")).SendKeys("Petrov");
            driver.FindElement(By.XPath("//input[@id='dob']")).SendKeys("07/16/1932");
            driver.FindElement(By.XPath("//input[@name='email_address']")).SendKeys(Email());
            driver.FindElement(By.XPath("//input[@name='company']")).SendKeys("Pasho&Co");
            driver.FindElement(By.XPath("//input[@name='street_address']")).SendKeys("Pesho Avn.");
            driver.FindElement(By.XPath("//input[@name='postcode']")).SendKeys("1000");
            driver.FindElement(By.XPath("//input[@name='city']")).SendKeys("NYC");
            driver.FindElement(By.XPath("//input[@name='state']")).SendKeys("NY");

            //IWebElement countryDropdown = driver.FindElement(By.Name("country"));
            //SelectElement selectCountry = new SelectElement(countryDropdown);
            //selectCountry.SelectByText("United States");

            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("United States");

            driver.FindElement(By.XPath("//input[@name='telephone']")).SendKeys("0545454521");
            driver.FindElement(By.XPath("//input[@name='password']")).SendKeys("123456");
            driver.FindElement(By.XPath("//input[@name='confirmation']")).SendKeys("123456");
            driver.FindElement(By.XPath("//button[@id='tdb4']")).Click();

            Assert.IsTrue(driver.PageSource.Contains("Your Account Has Been Created!"), "Account creation filed.");
            driver.FindElement(By.XPath("//a[@id='tdb4']")).Click();
            driver.FindElement(By.XPath("//a[@id='tdb4']")).Click();
            Console.WriteLine($"Account created with email: {Email()}");
        }
    }
}