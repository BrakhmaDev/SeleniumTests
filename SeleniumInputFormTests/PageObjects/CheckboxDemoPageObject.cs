using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumInputFormTests.PageObjects
{
    class CheckboxDemoPageObject
    {
        private IWebDriver webDriver;
        private readonly By checkboxDemoButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Checkbox Demo')]]");
        private readonly By clickOnthisCheck_box = By.XPath("//div[@class='checkbox']/child::label[text()[contains(.,'Click on this check box')]]");

        public CheckboxDemoPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject CheckboxDemo()
        {
            webDriver.FindElement(checkboxDemoButton).Click();
            WaitUntil.WaitElement(webDriver, clickOnthisCheck_box);
            webDriver.FindElement(clickOnthisCheck_box).Click();
            return new MainMenuPageObject(webDriver);
        }
    }
}
