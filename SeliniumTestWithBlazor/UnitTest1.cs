using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;

namespace SeliniumTestWithBlazor
{
    public class Tests
    {
        IWebDriver driver;
        BlazorPage page;
        [SetUp]
        public void Setup()
        {
            EdgeOptions options = new EdgeOptions();
            
            driver = new EdgeDriver("C:\\Users\\[username]\\Downloads\\edgedriver_win64", options);
            driver.Navigate().GoToUrl("http://localhost:5140/");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1500);
            page = new BlazorPage(driver);
            page.CounterButton.Click();
        }



        /*[Test]
        public void Test1()
        {
            Assert.Pass();
        }*/
        private void CounterButtonClicker(int n)
        {
            page.FindElement();
            for (int i = 0; i < n; i++)
                page.ClickMeButton.Click();
        }
        [Test]
        public void CounterTest()
        {
            var timesToClick = 5;
            CounterButtonClicker(timesToClick);
            Assert.IsTrue(page.ResultText.Text.Contains(timesToClick.ToString()));

        }
       
       /* [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
        }*/
    }
}