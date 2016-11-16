using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HelloWebforms.Pages.Exceptions;
using HelloWebforms.Pages.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace HelloWebforms.Pages.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver, "Account/Login", "Log in", "Log in")
        {

        }

        public BasePage Login(Credentials credentials, bool rememberMe = false)
        {
            Driver.FindElement(By.Id("MainContent_Email")).SendKeys(credentials.Email);
            Driver.FindElement(By.Id("MainContent_Password")).SendKeys(credentials.Password);
            var rememberMeCheckbox = Driver.FindElement(By.Id("MainContent_RememberMe"));
            if (rememberMeCheckbox.Selected != rememberMe)
                rememberMeCheckbox.Click();

            var LogInButton = Driver.FindElement(ByExtensionMethods.Attribute("input", "type", "submit"));
            LogInButton.Click();

            if (Driver.GetText().Contains("Invalid login attempt"))
            {
                throw new LoginException();
            }
            else
            {
                return new HomePage(Driver);
            }

        }

    }

    public class RegisterPage : BasePage
    {
        public RegisterPage(IWebDriver driver) : base(driver, "Account/Register", "Register", "Register")
        {

        }


        public BasePage Register(Credentials credentials)
        {
            Driver.FindElement(By.Id("MainContent_Email")).SendKeys(credentials.Email);
            Driver.FindElement(By.Id("MainContent_Password")).SendKeys(credentials.Password);
            Driver.FindElement(By.Id("MainContent_ConfirmPassword")).SendKeys(credentials.Password);

            var registerButton = Driver.FindElement(ByExtensionMethods.Attribute("input", "type", "submit"));
            registerButton.Click();

            if (Driver.GetText().Contains("Passwords must have at least one non letter or digit character. Passwords must have at least one digit ('0'-'9'). Passwords must have at least one uppercase ('A'-'Z')."))
            {
                throw new LoginException();
            }
            else
            {
                return new HomePage(Driver);
            }

        }

    }


}
