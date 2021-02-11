using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SpecFlowProject2
{
    public class LoginEmailPage
    {
        private IWebDriver webdriver;
        public LoginEmailPage(IWebDriver driver)
        {
            webdriver = driver;
        }
        public IWebElement login => webdriver.FindElement(By.Id("login"));
        public IWebElement pass => webdriver.FindElement(By.Name("password"));
    }
}
