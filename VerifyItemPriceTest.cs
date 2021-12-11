using NUnit.Framework;
using PlanitTechnicalTestLibrary.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary
{
    [TestFixture]
    public class VerifyItemPriceTest : BaseTest
    {
        [Test]
        public void VerifyItemPrice()
        {
            TopMenuRibbon topMenuribbon = new TopMenuRibbon();
            ShoppingPage shoppingPage = new ShoppingPage();
            CartPage cartPage = new CartPage();

            int stuffedfrogquantity = 2;
            int fuffybunnyquantity = 3;
            int valentinebearquantity = 1;

            topMenuribbon.ClickShopButton(driver);
            shoppingPage.BuyStuffedFrog(driver, stuffedfrogquantity);
            shoppingPage.BuyFluffyBunny(driver, fuffybunnyquantity);
            shoppingPage.BuyValentineBear(driver, valentinebearquantity);
            double stuffedFrogPrice = shoppingPage.GetItemPrice(driver, "Stuffed Frog");
            double fluffyBunnyPrice = shoppingPage.GetItemPrice(driver, "Fluffy Bunny");
            double valentineBearPrice = shoppingPage.GetItemPrice(driver, "Valentine Bear");

            topMenuribbon.ClickCartMenu(driver);

            Assert.Multiple(() =>
            {
                Assert.IsTrue(stuffedFrogPrice == cartPage.GetItemPriceFromCart(driver, "Stuffed Frog"));
                Assert.IsTrue(fluffyBunnyPrice == cartPage.GetItemPriceFromCart(driver, "Fluffy Bunny"));
                Assert.IsTrue(valentineBearPrice == cartPage.GetItemPriceFromCart(driver, "Valentine Bear"));

                Assert.IsTrue(stuffedFrogPrice*stuffedfrogquantity == cartPage.GetSubTotal(driver, "Stuffed Frog"));
                Assert.IsTrue(fluffyBunnyPrice*fuffybunnyquantity == cartPage.GetSubTotal(driver, "Fluffy Bunny"));
                Assert.IsTrue(valentineBearPrice*valentinebearquantity == cartPage.GetSubTotal(driver, "Valentine Bear"));
                
                Assert.AreEqual(stuffedFrogPrice * stuffedfrogquantity
                    + fluffyBunnyPrice * fuffybunnyquantity
                    + valentineBearPrice * valentinebearquantity, cartPage.GetTotalPrice(driver));
            });
        }

    }
}
