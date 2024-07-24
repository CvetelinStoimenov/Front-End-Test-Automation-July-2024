using OpenQA.Selenium;

// Page Object class declaration and configuration
namespace SumTwoNumbers
{
    public class SumNumberPage
    {
        private readonly IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
        }

        // This field holds the URL of the web page that the SumNumberPage class interacts with. It is a constant string that is used to navigate to the Sum Numbers page.
        const string PageUrl = "https://e019d602-5c73-4285-8bbb-34c0b7aabfcc-00-2q6j095lp1dn5.kirk.replit.dev/";

        // UI elements are mapped to C# properties
        public IWebElement FieldNum1 => driver.FindElement(By.CssSelector("input#number1"));
        public IWebElement FieldNum2 => driver.FindElement(By.CssSelector("input#number2"));
        public IWebElement ButtonCalc => driver.FindElement(By.CssSelector("#calcButton"));
        public IWebElement ButtonReset => driver.FindElement(By.CssSelector("#resetButton"));
        public IWebElement ElementResult => driver.FindElement(By.CssSelector("#result"));

        // Page actions are mapped to C# methods

        // Navigates to the Sum Numbers page.
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        // Resets the form to its initial state.
        public void ResetForm()
        {
            ButtonReset.Click();
        }

        // Checks if the form fields and result are empty.
        public bool IsFormEmpty()
        {
            return FieldNum1.Text + FieldNum2.Text + ElementResult.Text == "";
        }

        // Sends values to the input fields and clicks the Calculate button.
        public string AddNumber(string num1, string num2)
        {
            if (!IsFormEmpty())
            {
                ResetForm();
            }

            FieldNum1.SendKeys(num1);
            FieldNum2.SendKeys(num2);
            ButtonCalc.Click();
            string result = ElementResult.Text;
            return result;
        }
    }
}
