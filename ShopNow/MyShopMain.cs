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
        public IWebDriver driver = new ChromeDriver();
        CommonFunctions commonFunction = new CommonFunctions();
        //MyShopHomePage myShopFunctions = new MyShopHomePage();

        [Test]
        public void TestCommonMethod()
        {

            commonFunction.LoadExcelSheet();
            neudesicwebsiteURL = commonFunction.xRange.Cells[1][1].value;
            commonFunction.LoadBrowser(neudesicwebsiteURL);
        }

        [Test]
        public void TestMyShop()
        {
            commonFunction.LoadExcelSheet();
            myshopUrl = commonFunction.xRange.Cells[2][1].value;
            commonFunction.LoadBrowser(myshopUrl);

            ExplicitWaitForElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div[1]/a"), 5);
            IWebElement titleElement = driver.FindElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div[1]/a"));
            string actualApptitle = titleElement.Text;
            string requiredAppTitle = "MY SHOP";
            Assert.AreEqual(requiredAppTitle, actualApptitle);
            Console.WriteLine(actualApptitle);
        }

        public IWebElement ExplicitWaitForElement(By locator, int seconds)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds)).Until(ExpectedConditions.ElementExists(locator));
        }

        public void ImplicitWaitForElement(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

    }
}
