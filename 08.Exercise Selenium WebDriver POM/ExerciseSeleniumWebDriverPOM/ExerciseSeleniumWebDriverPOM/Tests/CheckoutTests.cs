using ExerciseSeleniumWebDriverPOM.Pages;

namespace ExerciseSeleniumWebDriverPOM.Tests
{
    [TestFixture]
    public class CheckoutTests : BaseTest
    {
        CartPage cartPage;
        InventoryPage inventoryPage;
        CheckoutPage checkoutPage;

        [SetUp]
        public void Login()
        {
            Login("standard_user", "secret_sauce");
            cartPage = new CartPage(driver);
            inventoryPage = new InventoryPage(driver);
            checkoutPage = new CheckoutPage(driver);
            inventoryPage.AddToCartByIndex(0);
            inventoryPage.ClickCartLink();
            cartPage.ClickCheckout();
        }

        [Test]
        public void TestCheckoutPageLoaded()
        {
            Assert.That(checkoutPage.IsPageLoaded(), Is.True, "The checkout page did not load correctly.");
        }

        [Test]
        public void TestContinueToNextStep()
        {
            checkoutPage.EnterFirstName("Ivan");
            checkoutPage.EnterLastName("Ivanov");
            checkoutPage.EnterPostalCode("1000");
            checkoutPage.ClickContinue();

            Assert.That(checkoutPage.IsPageLoaded(), Is.True, "The user was not redirected to the next step in the checkout process."); 
            
            Assert.That(driver.Url.Contains("checkout-step-two.html"), Is.True, "The user was not redirected to the next step in the checkout process.");

        }

        [Test]
        public void TestCompleteOrder()
        {
            TestContinueToNextStep();
            //checkoutPage.EnterFirstName("Ivan");
            //checkoutPage.EnterLastName("Ivanov");
            //checkoutPage.EnterPostalCode("1000");
            //checkoutPage.ClickContinue();

            checkoutPage.ClickFinish();

            Assert.That(driver.Url.Contains("checkout-complete.html"), Is.True, "The user was not redirected to the checkout complete page.");

            Assert.That(checkoutPage.IsCheckoutComplete(), Is.True, "Checkout is not completed.");
        }
    }
}
