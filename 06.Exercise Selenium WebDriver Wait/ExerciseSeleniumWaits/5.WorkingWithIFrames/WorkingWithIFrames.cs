using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace _5.WorkingWithIFrames
{
    public class Tests
    {
        IWebDriver driver;
        WebDriverWait wait;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "https://codepen.io/pervillalva/full/abPoNLd";
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void HandlingIFramesByIndex()
        {
            // Wait until iFrame is available and switch to it by finding the firs iFrame
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

            // click the dropdown button
            var dropdownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
            dropdownButton.Click();

            // select the link inside the dropdown menu
            var dropdownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

            // Verify and print the link text
            foreach (var link in dropdownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.IsTrue(link.Displayed, "Link inside the dropdown is nor displayed as expected");
            }
            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void HandlingIFramesById()
        {
            // Wait until iFrame is available and switch to it by id
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("result"));

            // click the dropdown button
            var dropdownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
            dropdownButton.Click();

            // select the link inside the dropdown menu
            var dropdownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

            // Verify and print the link text
            foreach (var link in dropdownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.IsTrue(link.Displayed, "Link inside the dropdown is nor displayed as expected");
            }
            driver.SwitchTo().DefaultContent();
        }

        [Test]
        public void HandlingIFramesByWebElement()
        {
            // Locate the frame element
            var frameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#result")));

            // Switch to the frame by web element
            driver.SwitchTo().Frame(frameElement);

            // click the dropdown button
            var dropdownButton = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
            dropdownButton.Click();

            // select the link inside the dropdown menu
            var dropdownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector(".dropdown-content a")));

            // Verify and print the link text
            foreach (var link in dropdownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.IsTrue(link.Displayed, "Link inside the dropdown is nor displayed as expected");
            }
            driver.SwitchTo().DefaultContent();
        }
    }
}