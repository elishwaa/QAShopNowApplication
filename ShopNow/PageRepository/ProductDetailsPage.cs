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
    public class ProductDetailsPage
    {
        private readonly IWebDriver driver;
        CommonFunction _common = new CommonFunction();
        public ProductDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            _common.ImplicitWaitForElement(driver);
        }

        [FindsBy(How = How.ClassName, Using = "//div[@class='ui center aligned header break-words']")]
        public IWebElement TextTitle { get; set; }

        [FindsBy(How = How.ClassName, Using = "image-gallery ")]
        public IWebElement Image { get; set; }

        [FindsBy(How=How.ClassName, Using = "content")]
        public IWebElement Content { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ui purple fluid button']")]
        public IWebElement ButtonAddToCart { get; set; }

        [FindsBy(How = How.ClassName, Using = "cart-link")]
        public IWebElement IconShoppingCart { get; set; }

        [FindsBy(How = How.ClassName, Using = "rrt-text")]
        public IWebElement PopUpMessage { get; set; }



        public void FindTitle()
        {
            string Text = _common.ExplicitWaitForElement(By.XPath("//div[@class='ui center aligned header break-words']"), 10).Text;
            Assert.AreEqual( ConfigurationManager.AppSettings.Get("productName"), Text);
        }

        public void FindImage()
        {
            Assert.IsNotNull(Image);
        }

        public void FindContent()
        {
            Assert.IsNotNull(Content);
        }

        public void ClickAddToCartButton()
        {
            _common.ClickElement(ButtonAddToCart);
            Assert.AreEqual(PopUpMessage.Text, ConfigurationManager.AppSettings.Get("successMessage"));

        }
        
        public ShoppingCartPage ClickSHoppingCartIcon()
        {
            _common.ClickElement(IconShoppingCart);
            return new ShoppingCartPage(driver);
        }
    }
}
