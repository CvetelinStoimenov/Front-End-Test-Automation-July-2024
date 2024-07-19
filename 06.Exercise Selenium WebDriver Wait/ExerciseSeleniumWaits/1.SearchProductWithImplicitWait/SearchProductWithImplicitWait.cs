using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace _1.SearchProductWithImplicitWait
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://practice.bpbonline.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        // Implicit Waits Explained: The implicit wait is set once in the setup method and applies to all elements throughout the test. It helps in synchronizing the test by waiting up to a specified time for elements to appear.


                [Test]
        public void SearchProduct_Keyboard_ShouldAddToCart_ImplicitWait()
        {
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("keyboard");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                driver.FindElement(By.LinkText("Buy Now")).Click();

                Assert.IsTrue(driver.PageSource.Contains("keyboard"), "The product 'keyboard' was not find in the cart page.");
                Console.WriteLine("Scenario completed");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }

        [Test]
        public void SearchProduct_Junk_ShouldThrowNoSuchElementException_ImplicitWait()
        {
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("junk");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                driver.FindElement(By.LinkText("Buy Now")).Click();
            }
            catch (NoSuchElementException ex)
            { 
                Assert.Pass("Expected NoSuchElementException was thrown.");
                Console.WriteLine("Timeout - " + ex.Message);
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }
    }
}