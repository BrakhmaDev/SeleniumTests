using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

namespace SeleniumInputFormTests.PageObjects
{
    class InputFormSubmitPageObject
    {
        private IWebDriver webDriver;        
        private readonly By inputformButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Input Form Submit')]]");        
        private readonly By inputFormWithValidationsTitle = By.XPath("//h2[text()[contains(.,'Input form with validations')]]");
        private readonly By sendButton = By.XPath("//button[text()[contains(.,'Send')]]");
        public readonly By errorMessage = By.XPath("//div[@class='form-group has-feedback has-error']");
        private readonly By firstNameField = By.XPath("//input[@name='first_name']");
        private readonly By lastNameField = By.XPath("//input[@name='last_name']");
        private readonly By emailField = By.XPath("//input[@name='email']");
        private readonly By phoneField = By.XPath("//input[@name='phone']");
        private readonly By addressField = By.XPath("//input[@name='address']");
        private readonly By cityField = By.XPath("//input[@name='city']");
        private readonly By stateSelect = By.XPath("//select[@name='state']");
        private readonly By texasSelect = By.XPath("//option[text()[contains(.,'Texas')]]");
        private readonly By zipCodeField = By.XPath("//input[@name='zip']");
        private readonly By webSiteOrDomainNameField = By.XPath("//input[@name='website']");
        private readonly By hostingYesButton = By.XPath("//input[@type='radio' and @value='yes']");
        private readonly By hostingNoButton = By.XPath("//input[@type='radio' and @value='no']");
        private readonly By projectDescriptionField = By.XPath("//textarea[@class='form-control']");
       
        public InputFormSubmitPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject SubmitForm()
        {
            webDriver.FindElement(inputformButton).Click();
            WaitUntil.WaitElement(webDriver, inputFormWithValidationsTitle);
            webDriver.FindElement(sendButton).Click();
            WaitUntil.WaitSomeInterval();
            webDriver.FindElement(firstNameField).SendKeys(ValuesForFields.FirstName);
            webDriver.FindElement(lastNameField).SendKeys(ValuesForFields.LastName);
            webDriver.FindElement(emailField).SendKeys(ValuesForFields.Email);
            webDriver.FindElement(phoneField).SendKeys(ValuesForFields.Phone);
            webDriver.FindElement(addressField).SendKeys(ValuesForFields.Address);
            webDriver.FindElement(cityField).SendKeys(ValuesForFields.City);
            webDriver.FindElement(stateSelect).Click();
            webDriver.FindElement(texasSelect).Click();
            webDriver.FindElement(zipCodeField).SendKeys(ValuesForFields.ZipCode);
            webDriver.FindElement(webSiteOrDomainNameField).SendKeys(ValuesForFields.Website);
            webDriver.FindElement(hostingYesButton).Click();
            webDriver.FindElement(hostingNoButton).Click();
            webDriver.FindElement(projectDescriptionField).SendKeys(ValuesForFields.ProjectDescription);
            webDriver.FindElement(sendButton).Click();
            return new MainMenuPageObject(webDriver);
        }
    }
}
