using Microsoft.VisualBasic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace WorkingWithHTMLElements
{
    public class DropDownPractice
    {
        private IWebDriver driver;
        private string baseURL = "http://practice.bpbonline.com/";

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseURL);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void DropDownNavigateAndExtractInformation()
        {
            // Determine the path to save the text file and delete any existing file with the same name.
            string path = Directory.GetCurrentDirectory() + "/manufacturer.txt";

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Identify the dropdown element using name property.
            SelectElement manufDropdown = new SelectElement(driver.FindElement(By.Name("manufacturers_id")));

            // Retrieve all options from the dropdown and store them in a list.
            IList<IWebElement> allManufacturers = manufDropdown.Options;

            //	Create a string list to fill in all manufacturers and remove the "Please Select" option.
            List<string> manufNames = new List<string>();

            foreach (IWebElement manufName in allManufacturers)
            {
                manufNames.Add(manufName.Text);
            }
            // Remove the "Please Select" option from the list
            manufNames.RemoveAt(0);

            // Iterate through the manufacturers to fetch the product information related to each:
            // o Loop through each manufacturer and select it from the dropdown.
            // o Check if there are no products available for the selected manufacturer.
            // o   If products are available, fetch all rows from the product table and print the information to the text file.
            foreach (string mname in manufNames)
            {
                manufDropdown.SelectByText(mname);
                manufDropdown = new SelectElement(driver.FindElement(By.XPath("//select[@name='manufacturers_id']")));

                if (driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(path, $"The manufacturer {mname} has no products\n");
                }
                else
                {
                    // Create the table elements
                    IWebElement productTable = driver.FindElement(By.ClassName("productListingData"));

                    // Fetch all table rows
                    File.AppendAllText(path, $"\n\nThe manufacturer {mname} products are listed--\n");
                    ReadOnlyCollection<IWebElement> rows = productTable.FindElements(By.XPath("//tbody/tr"));

                    // Print the product information in the file
                    foreach (IWebElement row in rows)
                    {
                        File.AppendAllText(path, row.Text + "\n");
                    }
                }
            }
        }
    }
}