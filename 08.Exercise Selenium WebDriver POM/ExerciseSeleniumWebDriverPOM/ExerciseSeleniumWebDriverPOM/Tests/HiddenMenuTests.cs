using ExerciseSeleniumWebDriverPOM.Pages;

namespace ExerciseSeleniumWebDriverPOM.Tests
{
    [TestFixture]
    public class HiddenMenuTests : BaseTest
    {
        HiddenMenuPage hiddenMenuPage;

        [SetUp]
        public void Login()
        {
            Login("standard_user", "secret_sauce");
            hiddenMenuPage = new HiddenMenuPage(driver);
        }

        [Test]
        public void TestOpenMenu()
        {
            hiddenMenuPage.ClickMenuButton();

            Assert.That(hiddenMenuPage.IsMenuOpen(), Is.True, "The hidden menu is not open.");
        }

        [Test]
        public void TestLogout()
        {
            hiddenMenuPage.ClickMenuButton();
            hiddenMenuPage.ClickLogoutButton();

            Assert.That(driver.Url.Contains("/"), Is.True, "The user was not logout.");
        }
    }
}
