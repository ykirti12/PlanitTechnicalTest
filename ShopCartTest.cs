using NUnit.Framework;
using PlanitTechnicalTestLibrary.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary
{
    class ShopCartTest
    {
        [TestFixture]
        class SubmissionTest : BaseTest
        {
            [Test]
            public void VerifyShopCartMenu()
            {
                int FunnyCowQuanity = 3;
                int FluffyBunnyQuanity = 1;

                TopMenuRibbon topMenuRibbon = new TopMenuRibbon();
                ShoppingPage shoppingPage = new ShoppingPage();
                CartPage cartPage = new CartPage();

                topMenuRibbon.ClickShopButton(driver);
                shoppingPage.ClickFunnyCow(driver, FunnyCowQuanity);
                shoppingPage.ClickFluffyBunny(driver, FluffyBunnyQuanity);
                topMenuRibbon.ClickCartMenu(driver);
                Assert.IsTrue(
                    cartPage.VerifyFunnyCowIsListed(driver) &&
                    cartPage.VerifyFluffyBunnyIsListed(driver) &&
                    cartPage.VerifyFunnyCowQuantity(driver, FunnyCowQuanity) &&
                    cartPage.VerifyFluffyBunnyQuantity(driver, FluffyBunnyQuanity)
                    );
            }
        }
    }
}

