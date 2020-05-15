using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShopApplication.Common
{
    public class CommonFunction
    {
        private static IWebDriver driver;
        public CommonFunction()
        {

        }
        public CommonFunction(IWebDriver driver)
        {
            CommonFunction.driver = driver;
        }

        //Browser is navigated to the url 
        public void LoadBrowser(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        //Perform Click action
        public void ClickElement(IWebElement locator)
        {
            locator.Click();
        }


        //Explicitly wait for the element, for the time that we have passed
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
