using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumInputFormTests.PageObjects;

namespace SeleniumInputFormTests
{
    public class Tests : BaseTest
    {
        [Test]
        public void Test1()
        {
            var mainMenu = new MainMenuPageObject(webDriver);
            mainMenu
                .ChoosingSimpleForm()
                .SimpleFormDemo()
                .ChoosingCheckbox()
                .CheckboxDemo();


            Assert.Pass();
        }
    }
}