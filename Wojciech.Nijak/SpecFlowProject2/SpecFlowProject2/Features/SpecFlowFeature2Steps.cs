using OpenQA.Selenium;
using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Features
{
    [Binding]
    public class SpecFlowFeature2Steps
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverWait;
        private LoginEmailPage loginPage;
        public SpecFlowFeature2Steps(IWebDriver driver)
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
            //wait for load
            Thread.Sleep(5000);
            var popup = "/html/body/div[2]/div/div[2]/div[3]/div/button[2]";
            var element =
                webdriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(popup)));
            // bad practice
            Thread.Sleep(5000);
            element.Click();
        }
        [Given(@"I click on (.*)")]
        public void GivenIClickOn(string p0)
        {
            // bad practice
            Thread.Sleep(5000);
            var firstXPath = "/html/body[@class='header-static header-big']/div[@id='root']/div[@id='site-header']/div[@class='sc-1tw0du9-1 hSFyGN']/div[@class='sc-1tw0du9-2 ibrNxJ']/a[@class='sc-1x1888b-2 dGNziy'][1]";
            var elementPoczta = webdriver.FindElement(By.XPath(firstXPath));
            elementPoczta.Click();
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
            var submitBtnCssSelector = "#loginForm > div.notificationWrapper > button";
            var submitBtn = webdriver.FindElement(By.CssSelector(submitBtnCssSelector));
            Thread.Sleep(5000);
            submitBtn.Click();
            Thread.Sleep(5000);
        }
        [Then(@"I expect to see message as „Niestety podany login lub hasło jest błędne\.”")]
        public void ThenIExpectToSeeMessageAsNiestetyPodanyLoginLubHasloJestBledne_()
        {
            var spanElemPath = "//*[@id='formError']/span[1]";
            var spanElem = webdriver.FindElement(By.XPath(spanElemPath));

            Assert.AreEqual("Podany login i/lub hasło są nieprawidłowe.", spanElem.Text);
        }

    }
}
