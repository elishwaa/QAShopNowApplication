using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopNow
{
    public class ProductPage 
    {
        private readonly Common common;
        public ProductPage()
        {
            common = new Common();
        }
        public void TestByPageTitle()
        {
            IWebElement element =  common.ExplicitWaitForElement(By.XPath("//div[@class='ui center aligned header break-words']"),5);
            string title = element.Text;
            Assert.AreEqual(title, "Happy Ninja");
            Console.WriteLine(title);
        }

    }
}
