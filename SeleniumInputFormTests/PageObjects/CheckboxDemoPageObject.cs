using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SeleniumInputFormTests.PageObjects
{
    class CheckboxDemoPageObject
    {
        private IWebDriver webDriver;
        private readonly By checkboxDemoButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Checkbox Demo')]]");
        private readonly By assertTitle = By.XPath("//div[text()[contains(.,'Single Checkbox Demo')]]");
        private readonly By clickOnthisCheck_box = By.XPath("//input[@type='checkbox' and @id='isAgeSelected']");
        private readonly By successMessage = By.XPath("//div[text()[contains(.,'Success - Check box is checked')]]");
        private readonly By checkAllButton = By.XPath("//input[@value='Check All']");
        private readonly By uncheckAllButton = By.XPath("//input[@value='Uncheck All']");     
        public CheckboxDemoPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject CheckboxDemo()
        {
            webDriver.FindElement(checkboxDemoButton).Click();
            WaitUntil.WaitElement(webDriver, assertTitle);
            webDriver.FindElement(clickOnthisCheck_box).Click();
            WaitUntil.WaitElement(webDriver, successMessage);
            webDriver.FindElement(checkAllButton).Click(); 
            WaitUntil.WaitElement(webDriver, uncheckAllButton);
            for (int i = 1; i < 5; i++)
            {
                webDriver.FindElement(By.XPath($"//label[text()[contains(.,'Option {i}')]]")).Click();                
            }            
            WaitUntil.WaitElement(webDriver, checkAllButton);
            return new MainMenuPageObject(webDriver);
        }
    }
}
