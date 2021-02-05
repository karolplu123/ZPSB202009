using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Pages
{
    [Binding]
    public class LoginEmailPage
    {
        public IWebDriver webdriver;
        public LoginEmailPage(IWebDriver driver)
        {
            webdriver = driver;
        }
        public IWebElement login => webdriver.FindElement(By.Id("login"));
        public IWebElement pass => webdriver.FindElement(By.Name("password"));
    }
}
