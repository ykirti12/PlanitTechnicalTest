using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary.Pages
{
    public class ShoppingPage
    {
        string FunnyCowXpath = "//li[@id='product-6']/div/p/a";
        string FluffyBunnyXpath = "//li[@id='product-4']/div/p/a";
        string StuffedFrogXpath = "//li[@id='product-2']/div/p/a";
        string ValentineBearXpath = "//li[@id='product-7']/div/p/a";
        string CartMenuId = "nav-cart";

        public void BuyStuffedFrog(IWebDriver driver, int quantity)
        {
            Helper helper = new Helper();
            helper.WaitForElementToBeVisible(driver, StuffedFrogXpath);
            var StuffedFrogButton = driver.FindElement(By.XPath(StuffedFrogXpath));
            for (int i = 0; i < quantity; i++)
                StuffedFrogButton.Click();
        }
        public void BuyFluffyBunny(IWebDriver driver, int quantity)
        {
            var FluffyBunnyButton = driver.FindElement(By.XPath(FluffyBunnyXpath));
            for (int i = 0; i < quantity; i++)
                FluffyBunnyButton.Click();
        }
        public void BuyValentineBear(IWebDriver driver, int quantity)
        {
            var ValentineBearButton = driver.FindElement(By.XPath(ValentineBearXpath));
            for (int i = 0; i < quantity; i++)
                ValentineBearButton.Click();
        }
        public void ClickFunnyCow(IWebDriver driver, int quantity)
        {
            Thread.Sleep(1000);
            var FunnyCowButton = driver.FindElement(By.XPath(FunnyCowXpath));
            for(int i =0; i<quantity; i++)
                FunnyCowButton.Click();

        }
        public void ClickFluffyBunny(IWebDriver driver, int quantity)
        {
            var FluffyBunnyButton = driver.FindElement(By.XPath(FluffyBunnyXpath));
            for (int i = 0; i < quantity; i++)
                FluffyBunnyButton.Click();

        }
        public double GetItemPrice(IWebDriver driver, string itemName)
        {
            Helper helper = new Helper();
            helper.WaitForElementToBeVisible(driver, $"//h4[text()='{itemName}']/..//span");
            var ele = driver.FindElement(By.XPath($"//h4[text()='{itemName}']/..//span"));
            var price = ele.Text;
            price = price.Substring(1);
            return Convert.ToDouble(price);

        }
    }
}
