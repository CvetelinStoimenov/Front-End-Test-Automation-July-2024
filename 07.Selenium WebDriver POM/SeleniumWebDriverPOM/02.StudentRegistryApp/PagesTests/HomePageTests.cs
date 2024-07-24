using _02.StudentRegistryApp.Pages;

namespace _02.StudentRegistryApp.PagesTests
{
    public class HomePageTests : BasePageTests
    {
        [Test]
        public void Test_HomePage_Content()
        {
            var homePage = new HomePage(driver);
            homePage.Open();

            Assert.Multiple(() =>
            {
                Assert.That(homePage.GetPageTitle(), Is.EqualTo("MVC Example"));
                Assert.That(homePage.GetPageHeadingText(), Is.EqualTo("Students Registry"));
            });
            homePage.GetStudentsCount();
            Assert.Pass();

            Console.WriteLine(homePage.GetStudentsCount());
        }

        [Test]
        public void Test_HomePage_Links()
        {
            var homePage = new HomePage(driver);

            // Click on the Home page link and assert the Home page is open
            homePage.Open();
            homePage.LinkHomePage.Click();
            Assert.IsTrue(new HomePage(driver).IsOpen());

            // Click on the Home page link and assert the Add Students Page is open
            homePage.Open();
            homePage.LinkViewStudentsPage.Click();
            Assert.IsTrue(new ViewStudentsPage(driver).IsOpen());

            // Click on the Home page link and assert the View Students Page is open
            homePage.Open();
            homePage.LinkAddStudentsPage.Click();
            Assert.IsTrue(new AddStudentPage(driver).IsOpen());
        }
    }
}
