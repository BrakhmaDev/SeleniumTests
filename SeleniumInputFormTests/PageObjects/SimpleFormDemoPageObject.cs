using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumInputFormTests.PageObjects
{
    class SimpleFormDemoPageObject
    {
        private IWebDriver webDriver;
        private readonly By inputField = By.XPath("//input[@placeholder='Please enter your Message']");
        private readonly By showMessageButton = By.XPath("//button[@onclick='showInput();']");
        private readonly By yourMessageField = By.XPath("//div[@id='user-message']/child::span[text()[contains(.,'Hello World!')]]");
        private readonly By enterAField = By.Id("sum1");
        private readonly By enterBField = By.Id("sum2");
        private readonly By getTotalButton = By.XPath("//button[@onclick='return total()']");
        private readonly By totalField = By.XPath("//div[@style]/child::span[text()[contains(.,'666')]]");
        public SimpleFormDemoPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject SimpleFormDemo()
        {
            webDriver.FindElement(inputField).SendKeys(ValuesForFields.EnterMessageField);
            webDriver.FindElement(showMessageButton).Click();
            WaitUntil.WaitElement(webDriver, yourMessageField);
            webDriver.FindElement(enterAField).SendKeys(ValuesForFields.EnterAfield);
            webDriver.FindElement(enterBField).SendKeys(ValuesForFields.EnterBfield);
            webDriver.FindElement(getTotalButton).Click();
            WaitUntil.WaitElement(webDriver, totalField);
            return new MainMenuPageObject(webDriver);
        }
    }

}
