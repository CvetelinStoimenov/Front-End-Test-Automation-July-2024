using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Xml.Linq;

namespace WorkingWithHTMLElements
{
    public class WorkingWithWebTables
    {
        private IWebDriver driver;
        private string baseUrl = "http://practice.bpbonline.com/";

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(baseUrl);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void ExtractInformationFromWebTables()
        {
            // Identify the web table on the home page
            IWebElement productTable = driver.FindElement(By.XPath("//*[@id='bodyContent']/div/div[2]/table"));

            // Find all rows in the web table
            ReadOnlyCollection<IWebElement> tableRows = productTable.FindElements(By.XPath("//tbody/tr"));

            // Path to save csv file
            string path = System.IO.Directory.GetCurrentDirectory() + "/productInformation.csv";

            // ensures that if a CSV file with the same name already exists in the specified location, it will be deleted before creating a new one
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            // Traverse through table rows to find the table columns:
            // o Loop through each row and then each column within the row.
            // o Extract the text from each cell, split the text to separate product name and cost, and format it.
            // o Append the formatted text to the CSV file.
            foreach (IWebElement trow in tableRows)
            {
                // Find all cols in the web table
                ReadOnlyCollection<IWebElement> tableCols = trow.FindElements(By.XPath("td"));

                foreach (IWebElement tcol in tableCols)
                {
                    // Extract product name and cost
                    string data = tcol.Text;
                    string[] productInfo = data.Split('\n');
                    string printProductInfo = productInfo[0].Trim() + ", " + productInfo[1].Trim() + "\n";

                    // Write product information extracted to the file
                    File.AppendAllText(path, printProductInfo);
                }
            }

            Assert.IsTrue(File.Exists(path), "CSV file was not created");
            Assert.IsTrue(new FileInfo(path).Length > 0, "CSV file is empty");
        }
    }
}