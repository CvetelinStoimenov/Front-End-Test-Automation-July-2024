using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Xml.Linq;

namespace PracticeLocatorsExtended
{
    public class Tests
    {
        private IWebDriver driver;
        private string baseUrl = "file:///C:/Users/cvete/source/repos/Front-End-Test-Automation-July-2024/03.Selenium WebDriver/SimpleForm/Locators.html";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {            
            // Creates a new instance of ChromeDriver
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl);

        }


        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Creates a new instance of ChromeDriver
            driver.Quit();
            //driver.Dispose();
        }

        [Test]
        public void Verify_Input_Filed_Value()
        {
            // Locate the "Last name" input field and verify its value
            var lastName = driver.FindElement(By.Id("lname"));
            Assert.That(lastName.GetAttribute("value"), Is.EqualTo("Vega"), "Last name value is incorrect");
            Console.WriteLine(lastName.GetAttribute("value"));
        }

        [Test]
        public void Verify_Newsletter_Checkbox_Is_Not_Selected()
        {
            // Locate the "Newsletter" checkbox and verify it is not selected
            var newsletter = driver.FindElement(By.Name("newsletter"));
            Assert.IsFalse(newsletter.Selected, "Newsletter checkbox should not be selected");
            Console.WriteLine(newsletter.Selected);
        }

        [Test]
        public void Verify_Anchor_Text()
        {
            // Locate the anchor tag and verify its text
            var anchorTag = driver.FindElement(By.TagName("a"));
            Assert.That(anchorTag.Text, Is.EqualTo("Softuni Official Page"), "Anchor text is incorrect");
            Console.WriteLine(anchorTag.Text);
        }

        [Test]
        public void Verify_Background_Color()
        {
            // Locate the element with class name "information" and verify its background color
            var informationFields = driver.FindElement(By.ClassName("information"));
            Assert.That(informationFields.GetCssValue("background-color"), Is.EqualTo("rgba(255, 255, 255, 1)"), "Background color is incorrect");
            Console.WriteLine(informationFields.GetCssValue("background-color"));
        }
        [Test]
        public void Verify_Link_Text()
        {
            // Locate the link by its full text and verify its href attribute
            var linkedText = driver.FindElement(By.LinkText("Softuni Official Page"));
            Assert.That(linkedText.GetAttribute("href"), Is.EqualTo("http://www.softuni.bg/"), "The href attribute is incorrect");
            Console.WriteLine(linkedText.GetAttribute("href"));
        }
        [Test]
        public void Verify_Partial_Text()
        {
            // Locate the link by partial text and verify its displayed text
            var partialText = driver.FindElement(By.PartialLinkText("Official Page"));
            Assert.That(partialText.Text, Is.EqualTo("Softuni Official Page"), "The displayed text is incorrect");
            Console.WriteLine(partialText.Text);
        }

        [Test]
        public void Verify_First_Name_Value()
        {
            // Locate the "First name" input field by ID and verify its value
            var fnameFieldById = driver.FindElement(By.CssSelector("#fname"));
            Assert.That(fnameFieldById.GetAttribute("value"), Is.EqualTo("Vincent"), "First name value is incorrect by ID");
            Console.WriteLine(fnameFieldById.GetAttribute("value"));
        }

        [Test]
        public void Verify_First_Name_Value_By_attribute()
        {
            // Locate the "First name" input field by name attribute and verify its value
            var fnameFieldByName = driver.FindElement(By.CssSelector("input[name='fname']"));
            Assert.That(fnameFieldByName.GetAttribute("Value"), Is.EqualTo("Vincent"), "First name value is incorrect by name");
            Console.WriteLine(fnameFieldByName.GetAttribute("Value"));
        }

        [Test]
        public void Verify_Button_Value()
        {
            // Locate the submit button by class name and verify its value attribute
            var submitButton = driver.FindElement(By.CssSelector("input[class*='button']"));
            Assert.That(submitButton.GetAttribute("Value"), Is.EqualTo("Submit"), "Submit button value is incorrect");
            Console.WriteLine(submitButton.GetAttribute("Value"));
        }

        [Test]
        public void Verify_Phone_Number_Displayed()
        {
            // Locate the "Phone Number" input field by CSS selector and verify it is displayed
            var phoneNumberField = driver.FindElement(By.CssSelector("div.additional-info > p > input[type='text']"));
            Assert.IsTrue(phoneNumberField.Displayed, "Phone number field is not displayed by CSS selector");
            Console.WriteLine(phoneNumberField.Displayed);
        }

        [Test]
        public void Verify_Phone_Number_Displayed_Specific()
        {
            // Locate the "Phone Number" input field using a more specific CSS selector and verify it is displayed
            var phoneNumberFieldSpecific = driver.FindElement(By.CssSelector("div.additional-info input[type='text']"));
            Assert.IsTrue(phoneNumberFieldSpecific.Displayed, "Phone number field is not displayed by specific CSS selector");
            Console.WriteLine(phoneNumberFieldSpecific.Displayed);
        }

        [Test]
        public void Verify_Male_Radio_Button_Absolute_Value()
        {
            // Locate the male radio button using absolute XPath and verify its value attribute
            var maleRadioButton = driver.FindElement(By.XPath("/html/body/form/input[1]"));
            Assert.That(maleRadioButton.GetAttribute("Value"), Is.EqualTo("m"), "The radio button attribute is not 'm'");
            Console.WriteLine(maleRadioButton.GetAttribute("Value"));
        }

        [Test]
        public void Verify_Male_Radio_Button_Value()
        {
            // Locate the male radio button using relative XPath and verify its value attribute
            var maleRadioButtonRelative = driver.FindElement(By.XPath("//input[@value='m']"));
            Assert.That(maleRadioButtonRelative.GetAttribute("Value"), Is.EqualTo("m"), "The radio button attribute is not 'm'");
            Console.WriteLine(maleRadioButtonRelative.GetAttribute("Value"));
        }

        [Test]
        public void Verify_Last_Name_Input_Field()
        {
            // Locate the last name input field using relative XPath and verify its value
            var lastNameRelative = driver.FindElement(By.XPath("//input[@name='lname']"));
            Assert.That(lastNameRelative.GetAttribute("Value"), Is.EqualTo("Vega"), "Incorrect last name input");
            Console.WriteLine(lastNameRelative.GetAttribute("Value"));
        }

        [Test]
        public void Verify_Male_Radio_Button_Value_XPath()
        {
            // Locate the newsletter checkbox using relative XPath and verify its type attribute
            var newsletterRelative = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            Assert.That(newsletterRelative.GetAttribute("type"), Is.EqualTo("checkbox"), "Incorrect attribute type for newsletter checkbox");
            Console.WriteLine(newsletterRelative.GetAttribute("type"));
        }

        [Test]
        public void Verify_Submit_Button_Value_XPath()
        {
            // Locate the submit button using relative XPath and verify its value attribute
            var submitButtonRelative = driver.FindElement(By.XPath("//input[@class='button']"));
            Assert.That(submitButtonRelative.GetAttribute("Value"), Is.EqualTo("Submit"), "The button attribute is incorrect");
            Console.WriteLine(submitButtonRelative.GetAttribute("Value"));
        }

        [Test]
        public void Verify_Phone_Number_Value_XPath()
        {
            // Locate the phone number input field within additional info using relative XPath and verify it is displayed
            var phoneNumberRelative = driver.FindElement(By.XPath("//div[@class='additional-info']//input[@type='text']"));
            Assert.IsTrue(phoneNumberRelative.Displayed, "Phone number field is not displayed by relative XPath");
            Console.WriteLine(phoneNumberRelative.Displayed);
        }
    }
}