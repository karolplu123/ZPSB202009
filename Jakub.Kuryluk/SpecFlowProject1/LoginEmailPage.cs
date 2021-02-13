using OpenQA.Selenium;
//using SeleniumExtras.PageObjects;
//using System;
//using System.Collections.Generic;
//using System.Text;

namespace SpecFlowProject1
{
    public class LoginEmailPage
    {
        public IWebDriver webdriver;
        public LoginEmailPage(IWebDriver driver)
        {
            //PageFactory.InitElements(driver, this);
            webdriver = driver;
        }
        //[FindsBy(How = How.Id, Using = "login")]
        //public IWebElement login { get; set; }
        //[FindsBy(How = How.Name, Using = "password")]
        //public IWebElement pass { get; set; }
        public IWebElement acceptButton => webdriver.FindElement(By.XPath("//*[text()='AKCEPTUJĘ I PRZECHODZĘ DO SERWISU']"));
        public IWebElement login => webdriver.FindElement(By.Id("login"));
        public IWebElement pass => webdriver.FindElement(By.Name("password"));
        public IWebElement postHref => webdriver.FindElement(By.XPath("//*[text()='Poczta']"));
        public IWebElement submitButton => webdriver.FindElement(By.XPath("//*[text()='zaloguj się']"));
        public IWebElement failureLoginInfo => webdriver.FindElement(By.CssSelector("#formError > span:nth-child(1)"));
    }
}
