using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public class HomePage
    {
        private readonly IWebDriver driver;
        CommonFunction _common = new CommonFunction();
        public HomePage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            _common.ImplicitWaitForElement(driver);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='fitted item shop-name']//a")]
        public IWebElement TextTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@href='#/product/1299']//button")]
        public IWebElement ButtonShopNow { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='ui big circular icon button']")]
        public IWebElement IconSearch { get; set; }

        [FindsBy(How = How.Name, Using = "search")]
        public IWebElement SearchBar { get; set; }



        public ProductDetailsPage ClikckOnButton()
        {
            _common.ExplicitWaitForElement(By.XPath("//a[@href='#/product/1299']//button"), 10).Submit();
            return new ProductDetailsPage(driver);
        }


        public void FindTitle()
        {
            string Text  = _common.ExplicitWaitForElement(By.XPath("//div[@class='fitted item shop-name']//a"), 5).Text;
            Assert.AreEqual(ConfigurationManager.AppSettings.Get("appTitle"), Text);
        }

        public void ClickOnSearchIcon()
        {
            _common.ClickElement(IconSearch);
            Assert.IsTrue(SearchBar.Displayed);
            string productName = ConfigurationManager.AppSettings.Get("productName");
            SearchBar.SendKeys(productName);
            //Assert.IsNotNull(driver.FindElement(By.LinkText(productName)));
        }

    }
}
