// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverTest;
using WebDriverTest.Elements;

namespace WebDriver.Tests
{
    [TestFixture]
    public class TestClass
    {
        public static int Port { get; } = 8080;

        private IWebDriver _webDriver;

        [OneTimeSetUp]
        public void SetUpOnes()
        {
            _webDriver = new ChromeDriver();
            _webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _webDriver.Navigate().GoToUrl($"localhost:{Port}");
        }

        [OneTimeTearDown]
        public void TearDownOnes()
        {
            _webDriver.Quit();
        }

        [SetUp]
        public void SetUp()
        {
            new LoginPage(_webDriver).Login();
            new MainPage(_webDriver).OpenIssuePage();
        }

        [TearDown]
        public void TearDown()
        {
            _webDriver.Navigate().GoToUrl($"localhost:{Port}/login");
        }

        [Test]
        [TestCase("description", "summary", Description = "Basic")]
        [TestCase("", "summary", Description = "Empty description")]
        [TestCase("descriptапра", "апрrtt", Description = "Unicode")]
        [TestCase("^7%6", "&*^", Description = "Not letters")]
        public void CheckIssue(string description, string summary)
        {
            var issue = new IssuePage(_webDriver);
            issue.CreateIssue(description, summary);
            issue.SubmitIssue();
            var wait =
                new WebDriverWait(_webDriver, TimeSpan.FromSeconds(5));
            wait.IgnoreExceptionTypes(
                typeof(StaleElementReferenceException));
            wait.Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(
                    By.ClassName("fsi-content")));
            var descriptionElement = new TextElement(_webDriver, By.ClassName("text"));
            var summaryElement = new TextElement(_webDriver, By.ClassName("issue-summary_fsi"));
            Assert.Multiple(() =>
                {
                    Assert.AreEqual(description, descriptionElement.Text);
                    Assert.AreEqual(summary, summaryElement.Text);
                }
            );
        }
    }
}