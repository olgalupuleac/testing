using OpenQA.Selenium;

namespace WebDriverTest.Elements
{
    public abstract class PageElement
    {
        protected IWebDriver WebDriver;
        protected IWebElement WebElement;

        protected PageElement(IWebDriver webDriver, By by)
        {
            WebDriver = webDriver;
            WebElement = webDriver.FindElement(by);
        }
    }

    public class ButtonElement : PageElement
    {
        public ButtonElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public void Click()
        {
            WebElement.Click();
        }
    }

    public class TextElement : PageElement
    {
        public TextElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public string Text
        {
            get => WebElement.Text;
            set => WebElement.SendKeys(value);
        }
    }
}