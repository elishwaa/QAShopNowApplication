using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using excel = Microsoft.Office.Interop.Excel;


namespace ShopNow
{
    public class CommonFunctions 
    {
        public IWebDriver driver;
        public excel.Range xRange;

        public void LoadBrowser(string url)
        {
            driver = new MyShopMain().driver;
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }

        public void LoadExcelSheet()
        {
            excel.Application xApplication = new excel.Application();
            excel.Workbook xWorkBook = xApplication.Workbooks.Open(@"C:\Users\Administrator\Desktop\url.xlsx");
            excel._Worksheet xWorkSheet = xWorkBook.Sheets[1];
            xRange = xWorkSheet.UsedRange;
        }
    }
}
