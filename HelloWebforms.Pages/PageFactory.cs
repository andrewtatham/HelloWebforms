using System;
using HelloWebforms.Pages.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace HelloWebforms.Pages
{
    public static class PageFactory
    {
        private static IWebDriver _driver;

        public static void CreateWebdriver()
        {
            _driver = GetWebDriver("Chrome");

        }
        private static IWebDriver GetWebDriver(string browserName)
        {
            IWebDriver driver;
            switch (browserName.ToLowerInvariant())
            {
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException($"{browserName} not defined");
            }
            return driver;
        }

        public static Type GetExpectedPageType(string pageName)
        {
            switch (pageName.ToLowerInvariant())
            {
                case "home":
                    return typeof(HomePage);
                case "about":
                    return typeof(AboutPage);
                case "contact":
                    return typeof(ContactPage);
                case "log in":
                    return typeof(LoginPage);
                case "register":
                    return typeof(RegisterPage);
                default:
                    throw new ArgumentException($"{pageName} not defined");
            }
        }

        public static BasePage Navigate(string pageName)
        {
            var pageType = GetExpectedPageType(pageName);
            return Navigate(pageType);
        }
        internal static BasePage Navigate(Type pageType)
        {
            BasePage page = (BasePage)Activator.CreateInstance(pageType, _driver);
            _driver.FindElement(By.LinkText(page.NavigationLinkText)).Click();
            if (!page.Validate())
                throw new NavigationException();
            return page;
        }

        public static BasePage GetPage(string pageName)
        {
            var pageType = GetExpectedPageType(pageName);
            BasePage page = (BasePage)Activator.CreateInstance(pageType, _driver);
            _driver.Navigate().GoToUrl("http://localhost/HelloWebforms/" + page.LocalPath);
            if (!page.Validate())
                throw new NavigationException();
            return page;
        }


        public static void CloseWebdriver()
        {
            _driver?.Quit();
        }
    }
}