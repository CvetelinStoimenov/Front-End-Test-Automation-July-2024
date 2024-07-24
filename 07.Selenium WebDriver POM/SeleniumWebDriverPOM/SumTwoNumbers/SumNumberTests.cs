using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SumTwoNumbers
{
    public class SumNumberTests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test_AddTwoNumbers_ValidInput()
        {
            var sumPage = new SumNumberPage(driver);
            sumPage.OpenPage();
            var result = sumPage.AddNumber("5", "6");
            Assert.That(result, Is.EqualTo("Sum: 11"));
        }

        [Test]
        public void Test_AddTwoNumbers_InvalidInput()
        {
            var sumPage = new SumNumberPage(driver);
            sumPage.OpenPage();
            var result = sumPage.AddNumber("hello", "world");
            Assert.That(result, Is.EqualTo("Sum: invalid input"));
        }

        [Test]
        public void Test_FormReset()
        {
            var sumPage = new SumNumberPage(driver);
            sumPage.OpenPage();
            var result = sumPage.AddNumber("hello", "world");
            sumPage.ResetForm();
            Assert.IsTrue(sumPage.IsFormEmpty());
        }

        [Test]
        [TestCase("2", "3", "Sum: 5")]
        [TestCase("-2", "-3", "Sum: -5")]
        [TestCase("-2", "0", "Sum: -2")]
        [TestCase("2", "0", "Sum: 2")]
        [TestCase("0", "0", "Sum: 0")]
        [TestCase("-1", "0", "Sum: -1")]
        [TestCase("1", "0", "Sum: 1")]
        [TestCase("0.1", "0.4", "Sum: 0.5")]
        [TestCase("hello", "world", "Sum: invalid input")]
        public void Test_AddTwoNumbers(string num1, string num2, string expectedResult)
        {
            var sumPage = new SumNumberPage(driver);
            sumPage.OpenPage();
            var result = sumPage.AddNumber(num1, num2);
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}