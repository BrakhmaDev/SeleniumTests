using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Threading;

namespace SeleniumInputFormTests.PageObjects
{
    class AjaxFormSubmitPageObject
    {
        private IWebDriver webDriver;
        private readonly By ajaxFormSubmitButton = By.XPath("//li[@style='display: list-item;']/child::a[text()[contains(.,'Ajax Form Submit')]]");        
        private readonly By ajaxFormTitle = By.XPath("//h1[text()[contains(.,'Ajax Form Submit with Loading icon ')]]");
        private readonly By emptyNameField = By.XPath("//input[@style='border: 1px solid rgb(255, 0, 0);']");
        private readonly By ajaxFormNameField = By.XPath("//input[@type='text']");
        private readonly By ajaxFormCommentField = By.XPath("//textarea[@name='description']");        
        private readonly By submitButton = By.XPath("//input[@onclick='ajaxSubmit();']");        
        private readonly By ajaxProcessingIcon = By.XPath("//img[@src='LoaderIcon.gif']");        
        public AjaxFormSubmitPageObject(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        public MainMenuPageObject AjaxForm()
        {
            webDriver.FindElement(ajaxFormSubmitButton).Click();
            WaitUntil.WaitElement(webDriver, ajaxFormTitle);
            webDriver.FindElement(submitButton).Click();            
            WaitUntil.WaitElement(webDriver, emptyNameField);           
            webDriver.FindElement(ajaxFormNameField).SendKeys(ValuesForFields.ajaxFormName);
            webDriver.FindElement(ajaxFormCommentField).SendKeys(ValuesForFields.ajaxFormComment);
            webDriver.FindElement(submitButton).Click();
            WaitUntil.WaitElement(webDriver, ajaxProcessingIcon);
            return new MainMenuPageObject(webDriver);
        }
    }
}
