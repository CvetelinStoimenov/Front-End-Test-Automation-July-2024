using ExerciseSeleniumWebDriverPOM.Pages;

namespace ExerciseSeleniumWebDriverPOM.Tests
{
    [TestFixture]
    public class CartTests : BaseTest
    {
        CartPage cartPage;
        InventoryPage inventoryPage;

        [SetUp]
        public void Login()
        {
            Login("standard_user", "secret_sauce");
            cartPage = new CartPage(driver);
            inventoryPage = new InventoryPage(driver);
            inventoryPage.AddToCartByIndex(0);
        }

        [Test]
        public void TestCartItemDisplayed()
        {
            inventoryPage.ClickCartLink();

            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "Cart items are not displayed.");
        }
        [Test]
        public void TestClickCheckout()
        {
            inventoryPage.ClickCartLink();
            cartPage.ClickCheckout();

        }

    }
}
