using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebDriverTest.Elements;

namespace WebDriverTest
{
    public abstract class PageObject
    {
        protected IWebDriver WebDriver;

        protected PageObject(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }

    public class MainPage : PageObject
    {
        private readonly ButtonElement _issueButtonElement;

        public MainPage(IWebDriver webDriver) : base(webDriver)
        {
            _issueButtonElement = new ButtonElement(WebDriver, By.ClassName("yt-header__create-btn"));
        }

        public void OpenIssuePage()
        {
            _issueButtonElement.Click();
        }
    }

    public class LoginPage : PageObject
    {
        private static string UserName { get; } = "root";
        private static string Password { get; } = "123";

        private readonly TextElement _login;
        private readonly TextElement _password;
        private readonly ButtonElement _loginButton;

        public LoginPage(IWebDriver webDriver) : base(webDriver)
        {
            _login = new TextElement(WebDriver, By.Id("id_l.L.login"));
            _password = new TextElement(WebDriver, By.Id("id_l.L.password"));
            _loginButton = new ButtonElement(WebDriver, By.Id("id_l.L.loginButton"));
        }

        public void Login()
        {
            _login.Text = UserName;
            _password.Text = Password;
            _loginButton.Click();
        }
    }

    public class IssuePage : PageObject
    {
        private readonly TextElement _description;
        private readonly TextElement _summary;
        private readonly ButtonElement _submit;
        public IssuePage(IWebDriver webDriver) : base(webDriver)
        {
            _description = new TextElement(WebDriver, By.ClassName("username-suggest"));
            _summary = new TextElement(WebDriver, By.ClassName("edit-summary"));
            _submit = new ButtonElement(WebDriver, By.ClassName("submit-btn"));
        }

        public void CreateIssue(string description, string summary)
        {
            _description.Text = description;
            _summary.Text = summary;
        }

        public void SubmitIssue()
        {
            _submit.Click();
        }
    }
}