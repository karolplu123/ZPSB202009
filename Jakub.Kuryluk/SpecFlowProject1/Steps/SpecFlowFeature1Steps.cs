using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Features
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverWait;
        private LoginEmailPage loginPage;

        public SpecFlowFeature1Steps(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webdriver = driver;
            webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            loginPage = new LoginEmailPage(webdriver);
        }
        [Given(@"I enter wp\.pl")]
        public void GivenIEnterWp_Pl()
        {
            webdriver.Navigate().GoToUrl("http://www.wp.pl");
            //Thread.Sleep(5000);
            ////var popup = "//*[text()='AKCEPTUJĘ I PRZECHODZĘ DO SERWISU']";
            ////var element = webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(popup)));
            ////// bad practice
            Thread.Sleep(5000);
            ////element.Click();
            //webdriverWait.Until(loginPage.acceptButton);
            //webdriverWait.Until(ExpectedConditions.ElementExists((By)loginPage.acceptButton));
            loginPage.acceptButton.Click();
        }
        [Given(@"I click on (.*)")]
        public void GivenIClickOn(string p0)
        {
            // bad practice
            Thread.Sleep(5000);
            loginPage.postHref.Click();
        }
        [When(@"I fill wrong email login")]
        public void WhenIFillWrongEmailLogin()
        {
            loginPage.login.SendKeys("Test");
        }
        [When(@"I fill wrong password")]
        public void WhenIFillWrongPassword()
        {
            loginPage.pass.SendKeys("pomidor");
        }
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            Thread.Sleep(5000);
            loginPage.submitButton.Click();
            Thread.Sleep(5000);
        }
        [Then(@"I expect to see message as „Niestety podany login lub hasło jest błędne\.”")]
        public void ThenIExpectToSeeMessageAsNiestetyPodanyLoginLubHasloJestBledne_()
        {
            string expected = "Podany login i/lub hasło są nieprawidłowe.";
            Assert.AreEqual(loginPage.failureLoginInfo.Text, expected);
        }
    }
}
