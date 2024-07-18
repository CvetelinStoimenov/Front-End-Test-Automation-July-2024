using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Data_DrivenTests
{
    public class DataDrivenTests
    {
        // Create fields for the driver and web elements
        IWebDriver driver;
        IWebElement textBoxFirstNum;
        IWebElement textBoxSecondNum;
        IWebElement dropDownOperation;
        IWebElement calcBtn;
        IWebElement resetBtn;
        IWebElement divResult;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Initialize the ChromeDriver and navigate to the application URL and locate the necessary web elements on the page.
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";

            textBoxFirstNum = driver.FindElement(By.Id("number1"));
            dropDownOperation = driver.FindElement(By.Id("operation"));
            textBoxSecondNum = driver.FindElement(By.Id("number2"));
            calcBtn = driver.FindElement(By.Id("calcButton"));
            resetBtn = driver.FindElement(By.Id("resetButton"));
            divResult = driver.FindElement(By.Id("result"));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }

        // Define a method that accepts strings for the first number, operator, second number, and expected result.
        // Implement the steps to interact with the web elements.
        public void PerformCalculation(string firsNumber, string operation, string secondNumber, string expectedResult)
        {
            // Click the reset button
            resetBtn.Click();

            // Send values to the corresponding fields if they ara not empty
            if (!string.IsNullOrEmpty(firsNumber))
            {
                textBoxFirstNum.SendKeys(firsNumber);
            }

            if (!string.IsNullOrEmpty(secondNumber))
            {
                textBoxSecondNum.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropDownOperation).SelectByText(operation);
            }

            // Click the calculate button
            calcBtn.Click();

            // Assert the expected result and actual result are the equal
            Assert.That(divResult.Text, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase("5", "+ (sum)", "10", "Result: 15")]
        [TestCase("3.5", "- (subtract)", "1.2", "Result: 2.3")]
        [TestCase("2e2", "* (multiply)", "1.5", "Result: 300")]
        [TestCase("5", "/ (divide)", "0", "Result: Infinity")]
        [TestCase("invalid", "+ (sum)", "1.5", "Result: invalid input")]
        [TestCase("", "+ (sum)", "3", "Result: invalid input")]
        [TestCase("", "- (subtract)", "3", "Result: invalid input")]
        [TestCase("", "* (multiply)", "3", "Result: invalid input")]
        [TestCase("", "/ (divide)", "3", "Result: invalid input")]
        [TestCase("1", "+ (sum)", "Infinity", "Result: Infinity")]
        [TestCase("1.5e53", "* (multiply)", "150", "Result: 2.25e+55")]
        [TestCase("1.5e53", "/ (divide)", "150", "Result: 1e+51")]
        [TestCase("12", "/ (divide)", "3", "Result: 4")]
        [TestCase("12.5", "/ (divide)", "4", "Result: 3.125")]
        [TestCase("2", "- (subtract)", "Infinity", "Result: -Infinity")]
        [TestCase("3", "!!!!", "7", "Result: invalid operation")]
        [TestCase("3", "", "7", "Result: invalid operation")]
        [TestCase("3", "@", "7", "Result: invalid operation")]
        [TestCase("3", "* (multiply)", "Infinity", "Result: Infinity")]
        [TestCase("4", "/ (divide)", "Infinity", "Result: 0")]
        [TestCase("3.14", "- (subtract)", "12.763", "Result: -9.623")]
        [TestCase("3.14", "* (multiply)", "-7.534", "Result: -23.65676")]
        [TestCase("3.14", "* (multiply)", "dfgdf", "Result: invalid input")]
        public void TestNumberCalculation(string firsNumber, string operation, string secondNumber, string expectedResult)
        {
            PerformCalculation(firsNumber, operation, secondNumber, expectedResult);
        }
    }
}