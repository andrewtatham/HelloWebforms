using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWebforms.Pages;
using HelloWebforms.Pages.Helpers;
using HelloWebforms.Pages.Pages;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace HelloWebforms.BehaviourTests.Bindings
{
    [Binding]
    public static class StepDefinition
    {

        private static BasePage _currentPage;


        [Given("I am on the (.*) page")]
        public static void GivenIAmOnThePage(string pageName)
        {
            _currentPage = PageFactory.GetPage(pageName);
        }



        [Given("I am logged out")]
        public static void GivenIAmLoggedOut()
        {
            if (_currentPage.IsLoggedIn())
            {
                _currentPage.LogOut();
            }
        }
        [Given("I am logged in with")]
        public static void GivenIAmLoggedIn(Table table)
        {
            if (!_currentPage.IsLoggedIn())
            {
                _currentPage = _currentPage.Navigate(typeof(LoginPage));
                _currentPage = ((LoginPage)_currentPage).Login(table.CreateInstance<Credentials>());
            }
        }


        [When("I navigate to the (.*) page")]
        public static void WhenINavigate(string pageName)
        {
            _currentPage = _currentPage.Navigate(pageName);
        }

        [When("I enter my account details")]
        public static void WhenIEnterMyAccountDetails(Table table)
        {
            if (_currentPage is LoginPage)
            {
                var credentials = table.CreateInstance<Credentials>();
                _currentPage = ((LoginPage)_currentPage).Login(table.CreateInstance<Credentials>());
            }
            else if (_currentPage is RegisterPage)
            {
                var credentials = table.CreateInstance<Credentials>();
                _currentPage = ((RegisterPage)_currentPage).Register(table.CreateInstance<Credentials>());
            }
            else
            {
                throw new NavigationException();
            }
        }


        [When("I log out")]
        public static void WhenILogOut()
        {
            _currentPage.LogOut();
        }


        [Then(@"I am on the (.*) page")]
        public static void ThenIAmOnThePage(string pageName)
        {
            var expectedPageType = PageFactory.GetExpectedPageType(pageName);
            Assert.IsInstanceOf(expectedPageType, _currentPage);
            Assert.IsTrue(_currentPage.Validate());
        }




        [Then("I am logged (in|out)")]
        public static void ThenIAmLoggedInOrOut(string inOrOut)
        {
            Assert.AreEqual(_currentPage.IsLoggedIn(), inOrOut.ToLowerInvariant() == "in");
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            PageFactory.CreateWebdriver();

            _currentPage = PageFactory.GetPage("Home");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            PageFactory.CloseWebdriver();
        }


    }
}
