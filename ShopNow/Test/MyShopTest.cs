using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using MyShopApplication.Common;
using MyShopApplication.Data;
using MyShopApplication.PageRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace MyShopApplication.Test
{
    class MyShopTest
    {
        private static IWebDriver driver;
        HomePage _home;
        CommonFunction _common;
        ProductDetailsPage _product;


        //Open Browser in Chrome and Maximize the window
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _home  = new HomePage(driver);
            _common = new CommonFunction(driver);
            _product = new ProductDetailsPage(driver);
        }


        // Navigate to the url that we have passed and verify whether it is navigated to correct page.
        [Test]
        public void Load_And_Verify_Home_Page()
        {
            _common.LoadBrowser(ConfigurationManager.AppSettings.Get("url"));
            _home.FindTitle();
        }

        //click on ShopNow Button and verify whether it is navigated to the correct product page.
        //Also check whether product page contain some product details
        [Test]
        public void  Verify_Shop_Now_Button_Functionality()
        {
            Load_And_Verify_Home_Page();
            ProductDetailsPage _product = _home.ClikckOnButton();
            _product.FindTitle();
            _product.FindImage();
            _product.FindContent();
        }

        //Verify whether the correct product is added to Shopping Cart by clicking AddToCart button in ProductDetails page 
        [Test]
        public void Verify_AddToCart_Functionality()
        {
            Verify_Shop_Now_Button_Functionality();
            _product.ClickAddToCartButton();
            ShoppingCartPage _cart =  _product.ClickSHoppingCartIcon();
            _cart.VerifyProductTitle();

        }

        //Verify whether search bar is working properly
        [Test]
        public void Verify_SearchBar()
        {
            Load_And_Verify_Home_Page();
            _home.ClickOnSearchIcon();
        }


        //Close the browser
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
