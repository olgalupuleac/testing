// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriver.Tests
{
    [TestFixture]
    public class TestClass
    {
        public static int Port { get; } = 8080;

        [OneTimeSetUp]
        public void SetUpOnes()
        {

        }

        public void TearDownOnes()
        {

        }

        [Test]
        public void TestMethod()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://www.yandex.ru");
            Console.WriteLine(webDriver.Title);
            webDriver.Quit();
        }


    }
}
