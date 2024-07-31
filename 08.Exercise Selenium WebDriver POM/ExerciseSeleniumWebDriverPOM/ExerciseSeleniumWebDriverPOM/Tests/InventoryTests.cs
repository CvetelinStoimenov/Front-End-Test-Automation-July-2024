using ExerciseSeleniumWebDriverPOM.Pages;

namespace ExerciseSeleniumWebDriverPOM.Tests
{
    [TestFixture]
    public class InventoryTests : BaseTest
    {
        InventoryPage inventoryPage;

        [SetUp]
        public void Login()
        {
            Login("standard_user", "secret_sauce");
            inventoryPage = new InventoryPage(driver);
        }

        [Test]
        public void TestInventoryDisplay() 
        {
            Assert.That(inventoryPage.IsInventoryDisplayed(), Is.True, "Inventory items are not displayed.");
        }

        [Test]
        public void TestAddToCartByIndex()
        {
            inventoryPage.AddToCartByIndex(0);

            var cartPage = new CartPage(driver);
            inventoryPage.ClickCartLink();

            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "The item was not added to the cart.");

        }

        [Test]
        public void TestAddToCartByName()
        {
            inventoryPage.AddToCartByName("Sauce Labs Backpack");

            var cartPage = new CartPage(driver);
            inventoryPage.ClickCartLink();

            Assert.That(cartPage.IsCartItemDisplayed(), Is.True, "The item was not added to the cart.");
        }

        [Test]
        public void TestPageTitle()
        {
            Assert.That(inventoryPage.IsPageLoaded(), Is.True, "The inventory page did not load correctly.");
        }
    }
}
