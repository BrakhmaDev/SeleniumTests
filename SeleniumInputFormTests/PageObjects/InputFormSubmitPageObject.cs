using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumInputFormTests.PageObjects
{
    class InputFormSubmitPageObject
    {
        private IWebDriver webDriver;
        private readonly By inputformButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Input Form Submit')]]");
        private readonly By inputFormWithValidationsTitle = By.XPath("//h2[text()[contains(.,'Input form with validations')]]");
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
        private readonly By hostingButton = By.XPath("//input[@type='radio' and @value='yes']");
        private readonly By hostingNoButton = By.XPath("//input[@type='radio' and @value='no']");
        private readonly By projectDescriptionfield = By.XPath("//textarea[@class='form-control']");
        private readonly By sendButton = By.XPath("//button[@type='submit']");
        public InputFormSubmitPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject SubmitForm()
        {

            return new MainMenuPageObject(webDriver);
        }
    }
}
