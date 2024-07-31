using OpenQA.Selenium;

namespace ExerciseSeleniumWebDriverPOM.Pages
{
    public class CheckoutPage : BasePage
    {
        private readonly By firstNameFiled = By.XPath("//*[@id='first-name']");
        private readonly By lastNameFiled = By.XPath("//*[@id='last-name']");
        private readonly By postalCodeFiled = By.XPath("//*[@id='postal-code']");
        private readonly By continueButton = By.XPath("//*[@id='continue']");
        private readonly By finishButton = By.Id("finish");
        private readonly By competeHeader = By.CssSelector(".complete-header");

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
        }

        public void EnterFirstName(string firsName)
        {
            Type(firstNameFiled, firsName);
        }

        public void EnterLastName(string lastName)
        {
            Type(lastNameFiled, lastName);
        }
        public void EnterPostalCode(string PostalCode)
        {
            Type(postalCodeFiled, PostalCode);
        }
        public void ClickContinue()
        {
            Click(continueButton);
        }
        public void ClickFinish()
        {
            Click(finishButton);
        }

        public bool IsPageLoaded()
        {
            return driver.Url.Contains("checkout-step-one.html") ||driver.Url.Contains("checkout-step-two.html");
        }

        public bool IsCheckoutComplete()
        {
            return GetText(competeHeader) == "Thank you for your order!";
        }
    }
}
