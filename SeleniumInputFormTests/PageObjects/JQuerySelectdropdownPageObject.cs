using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumInputFormTests.PageObjects
{
    class JQuerySelectdropdownPageObject
    {
        private IWebDriver webDriver;
        private readonly By jquerySelectDropdownButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'JQuery Select dropdown')]]");
        private readonly By dropDownTitle = By.XPath("//h3[text()[contains(.,'Drop Down with Search box')]]");
        private readonly By selectCountrySelector = By.XPath("//label[@for='usr' and text()[contains(.,'Select Country :')]]/following-sibling::select/following-sibling::span");
        private readonly string[] chooseCountrySelector = new string[] { "Australia", "Bangladesh", "Denmark", "Hong Kong", "India", "Japan", "Netherlands", "New Zealand", "South Africa", "United States of America" };
        private readonly By selectCountryEnterField = By.XPath("//span[@class='select2-search select2-search--dropdown']/child::input");
        private readonly By selectStateSelector = By.XPath("//li[@class='select2-search select2-search--inline']/child::input");
        private readonly string[] chooseStateSelector = new string[] { "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NV", "ND", "OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY" };
        private readonly By selectStateEnterField = By.XPath("");

        public JQuerySelectdropdownPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject JQuerySelect()
        {
            webDriver.FindElement(jquerySelectDropdownButton).Click();
            WaitUntil.WaitElement(webDriver, dropDownTitle);              
            for (int i = 0; i < chooseCountrySelector.Length; i ++)
            {
                webDriver.FindElement(selectCountrySelector).Click();
                webDriver.FindElement(By.XPath($"//option[@value='{chooseCountrySelector[i]}']")).Click();
            }
            for (int i = 0; i < chooseCountrySelector.Length; i++)
            {
                webDriver.FindElement(selectCountrySelector).Click();
                webDriver.FindElement(selectCountryEnterField).SendKeys($"{chooseCountrySelector[i]}");
                webDriver.FindElement(selectCountryEnterField).SendKeys(Keys.Enter);
            }
            return new MainMenuPageObject(webDriver);
        }
    }
}
