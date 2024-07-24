using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace _02.StudentRegistryApp.Pages
{
    public class ViewStudentsPage : BasePage
    {
        public ViewStudentsPage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/students";

        public ReadOnlyCollection<IWebElement> ListItemsStudents => driver.FindElements(By.CssSelector("Body > ul > li"));

        public string[] GetStudentsList()
        {
            var elementStudents = this.ListItemsStudents.Select(s => s.Text).ToArray();
            return elementStudents;
        }
    }
}
