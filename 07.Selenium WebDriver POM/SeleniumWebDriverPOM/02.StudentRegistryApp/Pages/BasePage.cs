using OpenQA.Selenium;

namespace _02.StudentRegistryApp.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public virtual string PageUrl { get; }

        public IWebElement LinkHomePage => driver.FindElement(By.LinkText("Home"));
        public IWebElement LinkViewStudentsPage => driver.FindElement(By.LinkText("View Students"));
        public IWebElement LinkAddStudentsPage => driver.FindElement(By.LinkText("Add Student"));
        public IWebElement ElementPageHeading => driver.FindElement(By.CssSelector("body > h1"));

        public void Open()
        {
            driver.Navigate().GoToUrl(this.PageUrl);
        }

        public bool IsOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public string GetPageHeadingText()
        {
            return ElementPageHeading.Text;
        }
    }
}
