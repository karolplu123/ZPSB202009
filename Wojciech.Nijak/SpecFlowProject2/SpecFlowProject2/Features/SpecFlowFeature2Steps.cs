using OpenQA.Selenium;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace SpecFlowProject2.Features
{
    [Binding]
    public class SpecFlowFeature2Steps
    {
        private IWebDriver webdriver;
        private WebDriverWait webdriverWait;
        public SpecFlowFeature2Steps(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            webdriver = driver;
            webdriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        [Given(@"I enter wp\.pl")]
        public void GivenIEnterWp_Pl()
        {
            webdriver.Navigate().GoToUrl("http://www.wp.pl");
            //wait for load
            Thread.Sleep(5000);
            var popup = "/html/body/div[3]/div[2]/div[1]/div[3]/button[2]";
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
            var firstXPath = "//*[@id=\"root\"]/div/div[4]/div[2]/div[2]/a[1]";
            var elementPoczta = webdriver.FindElement(By.XPath(firstXPath));
            elementPoczta.Click();
        }
        [When(@"I fill wrong email login")]
        public void WhenIFillWrongEmailLogin()
        {
            var login = webdriver.FindElement(By.Id("login"));
            login.SendKeys("Test");
        }
        [When(@"I fill wrong password")]
        public void WhenIFillWrongPassword()
        {
            var pass = webdriver.FindElement(By.Name("password"));
            pass.SendKeys("pomidor");
        }
        [When(@"I press submit")]
        public void WhenIPressSubmit()
        {
            var submitBtnCssSelector = "#btnSubmit";
            var submitBtn = webdriver.FindElement(By.CssSelector(submitBtnCssSelector));
            Thread.Sleep(5000);
            submitBtn.Click();
            Thread.Sleep(5000);
        }
        [Then(@"I expect to see message as „Niestety podany login lub hasło jest błędne\.”")]
        public void ThenIExpectToSeeMessageAsNiestetyPodanyLoginLubHasloJestBledne_()
        {
            //Zaimplementowac
        }

    }
}
