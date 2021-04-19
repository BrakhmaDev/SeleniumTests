using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumInputFormTests.PageObjects
{
    class MainMenuPageObject
    {
        private IWebDriver webDriver;
        private readonly By inputFormsButton = By.XPath("//a[text()[contains(.,'Input Forms')]]/preceding-sibling::i[@class]");
        private readonly By simpleFormDemoButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Simple Form Demo')]]");
        private readonly By waitInputField = By.XPath("//input[@placeholder='Please enter your Message']");
        private readonly By skipAdvertisementButton = By.XPath("//a[text()[contains(.,'No, thanks!')]]");
        private readonly By checkboxDemoButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Checkbox Demo')]]");
        public MainMenuPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public SimpleFormDemoPageObject ChoosingSimpleForm()
        {
            WaitUntil.WaitElement(webDriver, skipAdvertisementButton);
            webDriver.FindElement(skipAdvertisementButton).Click();
            webDriver.FindElement(inputFormsButton).Click();
            WaitUntil.WaitElement(webDriver, inputFormsButton);
            webDriver.FindElement(simpleFormDemoButton).Click();
            WaitUntil.WaitElement(webDriver, waitInputField);
            return new SimpleFormDemoPageObject(webDriver);
        }
        public CheckboxDemoPageObject ChoosingCheckbox()
        {
            webDriver.FindElement(inputFormsButton).Click();
            WaitUntil.WaitElement(webDriver, inputFormsButton);            
            return new CheckboxDemoPageObject(webDriver);
        }
        public RadioButtonsDemoPageObject ChoosingRadioButtons()
        {
            webDriver.FindElement(inputFormsButton).Click();
            WaitUntil.WaitElement(webDriver, inputFormsButton);
            return new RadioButtonsDemoPageObject(webDriver);
        }
    }
}
