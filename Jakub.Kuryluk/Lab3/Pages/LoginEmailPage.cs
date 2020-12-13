using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.Pages
{
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
