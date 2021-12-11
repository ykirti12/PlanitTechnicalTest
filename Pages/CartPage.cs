using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PlanitTechnicalTestLibrary.Pages
{
    class CartPage
    {
        string FunnyCowItemXPath = "//td[text()=' Funny Cow']";
        string FunnyCowItemQuanity = "//td[text()=' Funny Cow']/../td/input";
        string FluffyBunnyItemXPath = "//td[text()=' Fluffy Bunny']";
        string FluffyBunnyItemQuantity = "//td[text()=' Fluffy Bunny']/../td/input";
        Helper helper = new Helper();
       
        public bool VerifyFunnyCowIsListed(IWebDriver driver)
        {
            Thread.Sleep(1000);
            var ele = driver.FindElement(By.XPath(FunnyCowItemXPath));
            if (ele.Text.Equals("Funny Cow"))
                return true;
            else
                return false;
        }

        public bool VerifyFunnyCowQuantity(IWebDriver driver, int quantity)
        {
            var ele = driver.FindElement(By.XPath(FunnyCowItemQuanity));
            string num = ele.GetAttribute("value");
            if (num.Equals(quantity.ToString()))
                return true;
            else
                return false;
        }

        public bool VerifyFluffyBunnyIsListed(IWebDriver driver)
        {
            var ele = driver.FindElement(By.XPath(FluffyBunnyItemXPath));
            if (ele.Text.Equals("Fluffy Bunny"))
                return true;
            else
                return false;
        }

        public bool VerifyFluffyBunnyQuantity(IWebDriver driver, int quantity)
        {
            var ele = driver.FindElement(By.XPath(FluffyBunnyItemQuantity));
            var num = ele.GetAttribute("value");
            if (num.Equals(quantity.ToString()))
                return true;
            else
                return false;
        }
        public double GetItemPriceFromCart(IWebDriver driver, string itemName)
        {

            helper.WaitForElementToBeVisible(driver, $"//td[text()=' {itemName}']/../td[2]");
            var ele = driver.FindElement(By.XPath($"//td[text()=' {itemName}']/../td[2]"));
            return Convert.ToDouble(ele.Text.Substring(1));
        }
     
        public double GetSubTotal(IWebDriver driver, string itemName)
        {
            var subTot = driver.FindElement(By.XPath($"//td[text()=' {itemName}']/../td[4]")).Text;
            subTot = subTot.Substring(1);
            return Convert.ToDouble(subTot);
        }
        public double GetTotalPrice(IWebDriver driver)
        {
            var total = driver.FindElement(By.XPath("//td/strong")).Text;
            total = total.Substring(7); //Total: 116.9
            return Convert.ToDouble(total);
        }
    }
}
