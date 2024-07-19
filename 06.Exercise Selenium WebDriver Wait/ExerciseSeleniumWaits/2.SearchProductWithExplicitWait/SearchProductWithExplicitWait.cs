using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace _2.SearchProductWithExplicitWait
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "http://practice.bpbonline.com/ ";

            //Note: The initial implicit wait ensures that the driver will wait up to 10 seconds for elements to appear during the initial setup phase.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void SearchProduct_Keyboard_ShouldAddToCart_ExplicitWait()
        {
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("keyboard");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            //Note: Setting the implicit wait to zero before using explicit wait ensures that the implicit wait does not interfere with the explicit wait. This gives precise control over specific elements' wait times.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
                //Note: Explicit wait is used here to wait for up to 10 seconds for the "Buy Now" button to appear, allowing the test to handle dynamic content effectively.

                // Create WebDriverWait object with timeout set to 10
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Wait to identify the Buy nol link by using LinkText property 
                IWebElement buyNowLink = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

                // Set implicit wait back to 10 seconds
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                buyNowLink.Click();

                //Verify text
                Assert.IsTrue(driver.PageSource.Contains("keyboard"), "The product 'keyboard' was not found in the cart page.");
                Console.WriteLine("Scenario completed.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
        }

        //Explicit Waits Explained: Explicit waits are used for specific conditions and elements, providing better control over synchronization issues.By setting the implicit wait to zero, we avoid interference with the explicit wait, allowing for precise timing control. It helps in handling scenarios where different elements require different wait times. Useful for dynamic content where certain elements may take varying amounts of time to appear.

        [Test]
        public void SearchProduct_Junk_ShouldThrowNoSuchElementException_ExplicitWait()
        {
            driver.FindElement(By.XPath("//input[@type='text']")).SendKeys("junk");
            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            //Note: Setting the implicit wait to zero before using explicit wait ensures that the implicit wait does not interfere with the explicit wait. This gives precise control over specific elements' wait times.
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);

            try
            {
                //Note: Explicit wait is used here to wait for up to 10 seconds for the "Buy Now" button to appear, allowing the test to handle dynamic content effectively.

                // Create WebDriverWait object with timeout set to 10
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Wait to identify the Buy nol link by using LinkText property 
                IWebElement buyNowLink = wait.Until(e => e.FindElement(By.LinkText("Buy Now")));

                // If found, fail the test as is should not exist
                buyNowLink.Click();
                Assert.Fail("The 'Buy Now' link is found for a non-existing product.");
            }
            catch (WebDriverTimeoutException)
            { 
                Assert.Pass("Expected WebDriverTimeoutException was thrown.");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
            finally
            {
                // Set implicit wait back to 10 seconds
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
        }

    }
}