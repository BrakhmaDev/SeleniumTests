using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumInputFormTests.PageObjects
{
    class RadioButtonsDemoPageObject
    {
        private IWebDriver webDriver;
        private readonly By radioButtonsDemoButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Radio Buttons Demo')]]");
        private readonly By radioButtonDemo = By.XPath("//div[text()[contains(.,'Radio Button Demo')]]");
        private readonly By firstMaleButton = By.XPath("//input[@name='optradio' and @value='Male']");
        private readonly By firstFemaleButton = By.XPath("//input[@name='optradio' and @value='Female']");
        private readonly By getCheckedButton = By.XPath("//button[text()[contains(.,'Get Checked value')]]");
        private readonly By maleCheckedMessage = By.XPath("//p[@class='radiobutton' and text()[contains(.,'Radio button')]]");
        private readonly By femaleCheckedMessage = By.XPath("//p[@class='radiobutton' and text()[contains(.,'Radio button')]]");
        private readonly By getValuesButton = By.XPath("//button[@onclick='getValues();']");
        private readonly string[] sexes = new string[] { "Male", "Female" };
        private readonly string[] ages = new string[] { "0 - 5", "5 - 15", "15 - 50"};    
        public RadioButtonsDemoPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject RadioButtons()
        {
            webDriver.FindElement(radioButtonsDemoButton).Click();
            WaitUntil.WaitElement(webDriver, radioButtonDemo);
            webDriver.FindElement(firstMaleButton).Click();
            webDriver.FindElement(getCheckedButton).Click();
            WaitUntil.WaitElement(webDriver, maleCheckedMessage);
            webDriver.FindElement(firstFemaleButton).Click();
            webDriver.FindElement(getCheckedButton).Click();
            WaitUntil.WaitElement(webDriver, femaleCheckedMessage);
            for (int i = 0; i < sexes.Length; i++)
            {
                webDriver.FindElement(By.XPath($"//input[@value='{sexes[i]}' and @name='gender']")).Click();
                for (int j = 0; j < ages.Length; j++)
                {
                    webDriver.FindElement(By.XPath($"//input[@value='{ages[j]}']")).Click();
                    webDriver.FindElement(getValuesButton).Click();
                    WaitUntil.WaitElement(webDriver, (By.XPath($"//p[text()[contains(.,'Sex : {sexes[i]}')]] [text()[contains(.,' Age group: {ages[j]}')]]")));
                }
            }
            return new MainMenuPageObject(webDriver);
        }
    }
}
