using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using MyShopApplication.Common;
using MyShopApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MyShopApplication.PageRepository
{
    public class ShoppingCartPage
    {
        //four wide column break-words
        CommonFunction _common = new CommonFunction();
        public ShoppingCartPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _common.ImplicitWaitForElement(driver);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='four wide column break-words']")]
        public IWebElement ProductTitle { get; set; }


        public void VerifyProductTitle()
        {
            Assert.AreEqual(ProductTitle.Text, ConfigurationManager.AppSettings.Get("productName"));
        }
    }
}
