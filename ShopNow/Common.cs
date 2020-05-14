using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;


namespace ShopNow
{
    public class Common
    {
        public IWebDriver driver;
        public excel.Range xRange;

        public void LoadExcelSheet()
        {
            excel.Application xApplication = new excel.Application();
            excel.Workbook xWorkBook = xApplication.Workbooks.Open(@"C:\Users\Administrator\Desktop\url.xlsx");
            excel._Worksheet xWorkSheet = xWorkBook.Sheets[1];
            xRange = xWorkSheet.UsedRange;
        }

        public void LoadBrowser(string url)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void TestHomePageByTitle()
        {
            string actualApptitle = ExplicitWaitForElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div[1]/a"), 5).Text;
            string requiredAppTitle = "MY SHOP";
            Assert.AreEqual(requiredAppTitle, actualApptitle);
            Console.WriteLine(actualApptitle);
        }

        public ProductPage TestShopNowButtonClick()
        { 
            ExplicitWaitForElement(By.XPath("//a[@href='#/product/1299']//button"), 5).Submit();
            //Actions action = new Actions(driver);
            //action.MoveToElement(element).Submit();
            return new ProductPage();
        }

        //public ShoppingCartPage ShoppingCartIconClick()
        //{
        //    ExplicitWaitForElement(By.XPath("/html/body/div/div/div/div[2]/div[1]/div/div[2]/div/i/a/i"), 6).Click();
            
        //    return new ShoppingCartPage();
        //}

        public IWebElement ExplicitWaitForElement(By locator, int seconds)
        {
            var wait = new WebDriverWait(driver, new TimeSpan(0, 0, seconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        public void ImplicitWaitForElement(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }


    }
}

