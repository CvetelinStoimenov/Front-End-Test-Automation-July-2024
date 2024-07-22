using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace _3.HandlingMultipleWindows
{
    public class Tests
    {
        IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "https://the-internet.herokuapp.com/windows";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            //driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void HandlingMultipleWindows()
        {
            driver.FindElement(By.XPath("//*[@id='content']/div/a")).Click();

            // Get all windows handles
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            Assert.That(windowHandles.Count, Is.EqualTo(2), "The should be 2 windows open.");

            // Switch to the new window
            driver.SwitchTo().Window(windowHandles[1]);

            // Verify the content of the new window
            string newWindowContent = driver.PageSource;
            Assert.IsTrue(newWindowContent.Contains("New Window"), "The content of the new window is not as expected");

            // Log the content of the new window in a file
            string path = Path.Combine(Directory.GetCurrentDirectory(), "window.txt");
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.AppendAllText(path, "Window handler for new handler: " + driver.CurrentWindowHandle + "\n\n");
            File.AppendAllText(path, "The page content: " + newWindowContent + "\n\n");

            // Close the new window
            driver.Close();

            // Switch driver to the original window
            driver.SwitchTo().Window(windowHandles[0]);

            // Verify the content of the original window
            string originalWindowContent = driver.PageSource;
            Assert.IsTrue(originalWindowContent.Contains("The Internet"), "The content of the original window is not as expected");

            // Log the content of the original window in a file

            File.AppendAllText(path, "Window handler for original handler: " + driver.CurrentWindowHandle + "\n\n");
            File.AppendAllText(path, "The page content: " + originalWindowContent + "\n\n");
        }

        [Test]
        public void NoSuchWindowException()
        {
            driver.FindElement(By.LinkText("Click Here")).Click();

            // Get all windows handles
            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            // Switch to the new window
            driver.SwitchTo().Window(windowHandles[1]);

            // Close the new window
            driver.Close();

            try
            { 
                // Switch to the new window
                driver.SwitchTo().Window(windowHandles[1]);
            }
            catch (NoSuchWindowException ex)
            {
                // Log the content of the new window in a file
                string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                File.AppendAllText(path, "NoSuchWindowException catch" + ex.Message + "\n\n");
                Assert.Pass("NoSuchWindowException was correctly handled");
            }
            catch (Exception ex)
            {
                Assert.Fail("An unexpected exception was thrown: " + ex.Message);
            }
            finally
            {
                // Switch driver to the original window
                driver.SwitchTo().Window(windowHandles[0]);
            }
        }
    }
}