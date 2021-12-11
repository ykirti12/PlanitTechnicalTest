using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary.Pages
{
    public class TopMenuRibbon
    {
        string ShopButtonId = "nav-shop";
        string ContactButtonXPath = "//*[@id='nav-contact']";
        string CartMenuId = "nav-cart";
        public void ClickCartMenu(IWebDriver driver)
        {
            var CartButton = driver.FindElement(By.Id(CartMenuId));
            CartButton.Click();

        }
        public void ClickShopButton(IWebDriver driver)
        {
            var ShoppingButton = driver.FindElement(By.Id(ShopButtonId));
            ShoppingButton.Click();
        }
        public void ClickContactButton(IWebDriver driver)
        {
            var ContactButton = driver.FindElement(By.XPath(ContactButtonXPath));
            ContactButton.Click();
            Thread.Sleep(1000);
        }
    }
}
