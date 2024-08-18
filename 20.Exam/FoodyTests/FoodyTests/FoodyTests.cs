using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace FoodyTests
{
    public class Tests
    {
        [TestFixture]
        public class FoodyTests
        {
            protected IWebDriver driver;
            private static readonly string BaseUrl = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:85/";
            private static string? lastFoodName;
            private static string? lastFoodDescription;
            private static string? originalFoodName;
            private Actions actions;

            [OneTimeSetUp]
            public void OneTimeSetup()
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
                chromeOptions.AddArgument("--disable-search-engine-choice-screen");

                driver = new ChromeDriver(chromeOptions);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                actions = new Actions(driver);

                driver.Navigate().GoToUrl(BaseUrl);
                var loginBtn = driver.FindElement(By.XPath("//*[@id='navbarResponsive']/ul/ul/li[2]/a"));

                loginBtn.Click();

                driver.FindElement(By.XPath("//*[@id='username']")).SendKeys("usertest");
                driver.FindElement(By.XPath("//*[@id='password']")).SendKeys("123456");
                var loginBtnSubmit = driver.FindElement(By.XPath("//*[@type='submit']"));
                actions.MoveToElement(loginBtnSubmit).Perform();
                loginBtnSubmit.Click();
            }

            [Test, Order(1)]
            public void AddFoodWithInvalidData()
            {
                string invalidFoodName = "";
                string invalidDescription = "";

                driver.Navigate().GoToUrl($"{BaseUrl}Food/Add");

                driver.FindElement(By.XPath("//*[@id='name']")).SendKeys(invalidFoodName);
                driver.FindElement(By.XPath("//*[@id='description']")).SendKeys(invalidDescription);

                var add = driver.FindElement(By.XPath("//*[@type='submit']"));
                actions.MoveToElement(add).Perform();
                add.Click();

                string currentUrl = driver.Url;
                Assert.That(currentUrl, Is.EqualTo($"{BaseUrl}Food/Add"), "The page should remain on the creation page with invalid data.");

                var mainErrorMessage = driver.FindElement(By.CssSelector(".validation-summary-errors li"));
                var requiredFieldsErrors = driver.FindElements(By.XPath("//span[@class='text-danger field-validation-error']"));

                Assert.That(mainErrorMessage.Text.Trim(), Is.EqualTo("Unable to add this food revue!"), "The main error message is not displayed as expected.");

                Assert.True(requiredFieldsErrors[0].Text.Equals("The Name field is required."), "Name field required error not displayed");

                Assert.True(requiredFieldsErrors[1].Text.Equals("The Description field is required."), "Description field required error not displayed");
            }


            [Test, Order(2)]
            public void AddFoodWithRandomTitleTest()
            {
                lastFoodName = "Food: " + GenerateRandomString(5);
                lastFoodDescription = "Food Description: " + GenerateRandomString(10);

                driver.Navigate().GoToUrl($"{BaseUrl}Food/Add");

                driver.FindElement(By.XPath("//*[@id='name']")).SendKeys(lastFoodName);
                driver.FindElement(By.XPath("//*[@id='description']")).SendKeys(lastFoodDescription);

                var add = driver.FindElement(By.XPath("//*[@type='submit']"));
                actions.MoveToElement(add).Perform();
                add.Click();

                string expectedUrl = BaseUrl;
                Assert.That(driver.Url, Is.EqualTo(expectedUrl), "The URL after creation did not match the expected URL.");

                VerifyLastFoodName(lastFoodName);
            }

            [Test, Order(3)]
            public void EditLastAddedFoodTest()
            {
                driver.Navigate().GoToUrl(BaseUrl);

                var foods = driver.FindElements(By.XPath("//*[@id='scroll']"));
                var lastFoodElement = foods.Last();
                var editButton = lastFoodElement.FindElement(By.CssSelector("a[href*='/Food/Edit']"));
                actions.MoveToElement(editButton).Click().Perform();

                var inputName = driver.FindElement(By.XPath("//*[@id='name']"));
                originalFoodName = lastFoodName;

                lastFoodName = "Edited " + originalFoodName;
                inputName.Clear();
                inputName.SendKeys(lastFoodName);

                var add = driver.FindElement(By.XPath("//*[@type='submit']"));
                actions.MoveToElement(add).Perform();
                add.Click();

                driver.Navigate().GoToUrl(BaseUrl);
                foods = driver.FindElements(By.XPath("//*[@id='scroll']"));
                lastFoodElement = foods.Last();
                var lastFoodElementName = lastFoodElement.FindElement(By.CssSelector("h2"));

                string actualFoodName = lastFoodElementName.Text.Trim();
                if (actualFoodName == originalFoodName)
                {
                    Console.WriteLine("The food title remains unchanged as expected due to incomplete functionality.");
                }
                else
                {
                    Assert.Fail("The food title was unexpectedly changed.");
                }
            }

            [Test, Order(4)]
            public void SearchForFoodTitleTest()
            {
                driver.Navigate().GoToUrl(BaseUrl);

                var searchBox = driver.FindElement(By.XPath("//*[@type='search']"));
                searchBox.SendKeys(originalFoodName);

                var searchButton = driver.FindElement(By.XPath("//*[@type='submit']"));
                actions.MoveToElement(searchButton).Perform();
                searchButton.Click();

                var foodResults = driver.FindElements(By.XPath("//*[@id='scroll']"));
                Assert.That(foodResults.Count, Is.EqualTo(1), "The search did not return exactly one food item.");

                var resultFoodTitle = foodResults[0].FindElement(By.CssSelector("h2")).Text.Trim();
                Assert.That(resultFoodTitle, Is.EqualTo(originalFoodName), "The title of the searched food item does not match the expected title.");
            }

            [Test, Order(5)]
            public void DeleteLastAddedFoodTest()
            {
                driver.Navigate().GoToUrl(BaseUrl);

                var foods = driver.FindElements(By.XPath("//*[@id='scroll']"));
                int initialFoodCount = foods.Count;

                var lastFoodElement = foods.Last();
                actions.MoveToElement(lastFoodElement).Perform();

                var deleteButton = lastFoodElement.FindElement(By.CssSelector("a[href*='/Food/Delete']"));
                deleteButton.Click();

                foods = driver.FindElements(By.XPath("//*[@id='scroll']"));
                int currentFoodCount = foods.Count;

                Assert.That(currentFoodCount, Is.EqualTo(initialFoodCount - 1), "The food count did not decrease by one after deletion.");

                var lastFoodTitle = foods.Last().FindElement(By.CssSelector("h2")).Text.Trim();
                Assert.That(lastFoodTitle, Is.Not.EqualTo(lastFoodName), "The last food title still matches the deleted food title.");
            }



            [Test, Order(6)]
            public void SearchForDeletedFoodTest()
            {
                driver.Navigate().GoToUrl(BaseUrl);

                var searchBox = driver.FindElement(By.XPath("//*[@type='search']"));
                searchBox.SendKeys(originalFoodName);

                var searchButton = driver.FindElement(By.XPath("//*[@type='submit']"));
                actions.MoveToElement(searchButton).Perform();
                searchButton.Click();


                var addFoodButton = driver.FindElement(By.CssSelector("a.btn.btn-primary[href*='/Food/Add']"));
                Assert.True(addFoodButton.Displayed, "The Add Food button is not displayed as expected.");
            }

            [OneTimeTearDown]
            public void OneTimeTearDown()
            {
                driver.Quit();
                driver.Dispose();
            }

            private string GenerateRandomString(int length)
            {
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                return new string(Enumerable.Repeat(chars, length)
                  .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            private void VerifyLastFoodName(string expectedName)
            {
                var foods = driver.FindElements(By.XPath("//*[@id='scroll']"));
                var lastFoodElement = foods.Last();
                var lastFoodElementName = lastFoodElement.FindElement(By.CssSelector("h2"));

                string actualFoodName = lastFoodElementName.Text.Trim();
                Assert.That(actualFoodName, Is.EqualTo(expectedName), "The last movie title does not match the expected value.");
            }
        }
    }
}