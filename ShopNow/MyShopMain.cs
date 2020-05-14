using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopNow
{
    public class MyShopMain
    {
        public string neudesicwebsiteURL;
        public string myshopUrl;
        Common homePage = new Common();
        ProductPage productPage;
       

        [Test, Order(1)]
        public void TestHomePageTitle()
        {
            homePage.LoadExcelSheet();
            myshopUrl = homePage.xRange.Cells[2][1].value;
            homePage.LoadBrowser(myshopUrl);
            homePage.TestHomePageByTitle();
            System.Threading.Thread.Sleep(2000);
            productPage = homePage.TestShopNowButtonClick();

            //shoppingCart.TestByPageTitle();
        }

        [Test, Order(2)]
        public void TestProductPageTitle()
        {
            productPage.TestByPageTitle();
        }

        //[Test]
        //public void TestShoppingCartNavigation()
        //{
           

        //}
        //[Test]
        //public void TestCommonMethod()
        //{

        //    homePage.LoadExcelSheet();
        //    neudesicwebsiteURL = homePage.xRange.Cells[1][1].value;
        //    homePage.LoadBrowser(neudesicwebsiteURL);
        //}

    }
}
