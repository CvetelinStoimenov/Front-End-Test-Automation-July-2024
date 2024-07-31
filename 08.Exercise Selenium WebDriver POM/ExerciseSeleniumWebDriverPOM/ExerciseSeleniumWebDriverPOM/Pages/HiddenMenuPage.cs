using OpenQA.Selenium;

namespace ExerciseSeleniumWebDriverPOM.Pages
{
    public class HiddenMenuPage : BasePage
    {
        public HiddenMenuPage(IWebDriver driver) : base(driver)
        {
        }

        private readonly By menuButton = By.CssSelector(".bm-burger-button");
        private readonly By logoutButton = By.Id("logout_sidebar_link");

        public void ClickMenuButton()
        {
            Click(menuButton);
        }
        public void ClickLogoutButton()
        {
            Click(logoutButton);
        }
        public bool IsMenuOpen()
        {
            return FindElement(logoutButton).Displayed;
        }
    }
}
