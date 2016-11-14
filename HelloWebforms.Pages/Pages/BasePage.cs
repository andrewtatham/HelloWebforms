using System;
using HelloWebforms.Pages.Helpers;
using OpenQA.Selenium;

namespace HelloWebforms.Pages
{
    public class BasePage
    {
        internal readonly IWebDriver Driver;
        public string LocalPath { get; private set; }
        public string NavigationLinkText { get; private set; }
        public string ExpectedPageTitle { get; private set; }

        public BasePage(IWebDriver driver, string localPath, string navigationLinkText, string expectedPageTitle)
        {
            Driver = driver;
            LocalPath = localPath;
            ExpectedPageTitle = expectedPageTitle;
            NavigationLinkText = navigationLinkText;
        }

        public BasePage Navigate(string pageName)
        {
            return PageFactory.Navigate(pageName);
        }

        public BasePage Navigate(Type pageType)
        {
            return PageFactory.Navigate(pageType);
        }

        public bool Validate()
        {
            return Driver.Title.Contains(ExpectedPageTitle)
                   && Driver.Url.Contains(LocalPath);
        }

        public bool IsLoggedIn(string email = "andrewtatham@gmail.com")
        {
            return Driver.GetText().Contains($"Hello, {email} !");
        }

        public void LogOut()
        {
            Driver.FindElement(By.LinkText("Log off")).Click();
        }


    }
}