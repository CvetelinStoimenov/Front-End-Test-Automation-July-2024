using OpenQA.Selenium;

namespace _02.StudentRegistryApp.Pages
{
    public class AddStudentPage : BasePage
    {
        public AddStudentPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";

        public IWebElement FieldStudentName => driver.FindElement(By.XPath("//*[@id='name']"));
        public IWebElement FieldStudentEmail => driver.FindElement(By.XPath("//*[@id='email']"));
        public IWebElement ButtonAdd => driver.FindElement(By.XPath("/html/body/form/button"));

        public IWebElement ElementErrorMsg => driver.FindElement(By.XPath("/html/body/div"));

        public void AddStudent(string name, string email)
        {
            this.FieldStudentName.SendKeys(name);
            this.FieldStudentEmail.SendKeys(email);
            this.ButtonAdd.Click();
        }

        public string GetErrorMsg()
        {
            this.ButtonAdd.Click();
            return ElementErrorMsg.Text;
        }
    }
}
