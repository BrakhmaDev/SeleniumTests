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
        private readonly string[] chooseStateSelector = new string[] { "Alabama", "Alaska", "Arizona", "Arkansas", "California", "Colorado", "Connecticut", "Delaware", "District Of Columbia", "Florida", "Georgia", "Hawaii", "Idaho", "Illinois", "Indiana", "Iowa", "Kansas", "Kentucky", "Louisiana", "Maine", "Maryland", "Massachusetts", "Michigan", "Minnesota", "Mississippi", "Missouri", "Montana", "Nebraska", "Nevada", "New Hampshire", "New Jersey", "New Mexico", "New York", "North Carolina", "North Dakota", "Ohio", "Oklahoma", "Oregon", "Pennsylvania", "Rhode Island", "South Carolina", "South Dakota", "Tennessee", "Texas", "Utah", "Vermont", "Virginia", "Washington", "West Virginia", "Wisconsin", "Wyoming" };
        private readonly By selectUSOutlyingTerritories = By.XPath("//label[text()[contains(.,'Select US Outlying Territories :')]]/following-sibling::span");
        private readonly string[] selectTerritroriesSelector = new string[] { "American Samoa", "Northern Mariana Islands", "Puerto Rico", "Virgin Islands" };
        private readonly string[] selectTerritroriesByValueSelector = new string[] { "AS", "MP", "PR", "VI"};
        private readonly By selectUSOutlyingTerritoriesField = By.XPath("//span[@class='select2-results']/preceding-sibling::span[@class='select2-search select2-search--dropdown']/child::input");
        private readonly By selectAFileButton = By.XPath("//select[@name='files']");
        private readonly string[] selectAFileSelector = new string[] { "Python", "PHP", "Ruby", "C", "Java", ".Net", "Unknown Script", "Other file" };

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

            for (int i = 0; i < chooseStateSelector.Length; i++)
            {
                webDriver.FindElement(selectStateSelector).Click();
                webDriver.FindElement(selectStateSelector).SendKeys($"{chooseStateSelector[i]}");
                webDriver.FindElement(selectStateSelector).SendKeys(Keys.Enter);
            }

            for (int i = 0; i < selectTerritroriesByValueSelector.Length; i++)
            {
                webDriver.FindElement(selectUSOutlyingTerritories).Click();
                webDriver.FindElement(By.XPath($"//option[@value='{selectTerritroriesByValueSelector[i]}']")).Click();
            }
            for (int i = 0; i < selectTerritroriesSelector.Length; i++)
            {
                webDriver.FindElement(selectUSOutlyingTerritories).Click();
                webDriver.FindElement(selectUSOutlyingTerritoriesField).SendKeys($"{selectTerritroriesSelector[i]}");
                webDriver.FindElement(selectUSOutlyingTerritoriesField).SendKeys(Keys.Enter);
            }

            for (int i = 0; i < selectAFileSelector.Length; i++)
            {
                webDriver.FindElement(selectAFileButton).Click();
                webDriver.FindElement(By.XPath($"//option[text()[contains(.,'{selectAFileSelector[i]}')]]")).Click();
            }
            for (int i = 0; i < selectAFileSelector.Length; i++)
            {
                webDriver.FindElement(selectAFileButton).Click();
                webDriver.FindElement(selectAFileButton).SendKeys($"{selectAFileSelector[i]}");
                webDriver.FindElement(selectAFileButton).SendKeys(Keys.Enter);
            }
            return new MainMenuPageObject(webDriver);
        }
    }
}
