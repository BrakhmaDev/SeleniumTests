using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumInputFormTests.PageObjects
{
    class SelectDropdownListPageObject
    {
        private IWebDriver webDriver;
        private readonly By selectDropdownListButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Select Dropdown List')]]");
        private readonly By selectADayText = By.XPath("//label[text()[contains(.,'Select a day (select one):')]]");
        private readonly By selectADayButton = By.XPath("//select[@class='form-control']");
        private readonly string[] day = new string[] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        private readonly string[] state = new string[] { "California", "Florida", "New Jersey", "New York", "Ohio", "Texas", "Pennsylvania", "Washington" };
        private readonly By firstSelectedButton = By.XPath("//button[@value='Print First']");
        private readonly By getAllSelectedButton = By.XPath("//button[@value='Print All']"); 
        public SelectDropdownListPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject DropdownList()
        {
            webDriver.FindElement(selectDropdownListButton).Click();
            WaitUntil.WaitElement(webDriver, selectADayText);            
            for (int i = 0; i < day.Length; i++)
            {
                webDriver.FindElement(selectADayButton).Click();
                webDriver.FindElement(By.XPath($"//option[text()[contains(.,'{day[i]}')]]")).Click();
                WaitUntil.WaitElement(webDriver, By.XPath($"//p[@class='selected-value' and text()[contains(.,'Day selected :- {day[i]}')]]"));
            }
            for (int i = 0; i < state.Length; i++)
            {
                webDriver.FindElement(By.XPath($"//option[text()[contains(.,'{state[i]}')]]")).Click();
                webDriver.FindElement(firstSelectedButton).Click();
                WaitUntil.WaitElement(webDriver, By.XPath($"//p[@class='getall-selected' and text()[contains(.,'First selected option is : {state[i]}')]]"));
                webDriver.FindElement(getAllSelectedButton).Click();
                WaitUntil.WaitElement(webDriver, By.XPath($"//p[@class='getall-selected' and text()[contains(.,'Options selected are : {state[i]}')]]"));            }
            return new MainMenuPageObject(webDriver);
        }
    }
}
