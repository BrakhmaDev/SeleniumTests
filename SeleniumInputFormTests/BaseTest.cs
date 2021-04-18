using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumInputFormTests
{
    public class BaseTest
    {
        protected IWebDriver webDriver;
        [OneTimeSetUp]
        protected void DoBeforeAllTheTests()
        {
            webDriver = new ChromeDriver();
        }
        [OneTimeTearDown]
        protected void DoAfterAlltheTests()
        {

        }
        [TearDown]
        protected void DoAfterEach()
        {
            
        }
        [SetUp]
        protected void DoBeforeEach()
        {
            webDriver.Manage().Cookies.DeleteAllCookies();
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl(TestSettings.HostPrefix);
            WaitUntil.ShouldLocate(webDriver, TestSettings.ActualLocation);
        }
    }
}
