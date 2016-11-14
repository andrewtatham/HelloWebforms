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

        private static BasePage currentPage;


        [Given("I am on the (.*) page")]
        public static void GivenIAmOnThePage(string pageName)
        {
            currentPage = PageFactory.GetPage(pageName);
        }



        [Given("I am logged out")]
        public static void GivenIAmLoggedOut()
        {
            if (currentPage.IsLoggedIn())
            {
                currentPage.LogOut();
            }
        }
        [Given("I am logged in with")]
        public static void GivenIAmLoggedIn(Table table)
        {
            if (!currentPage.IsLoggedIn())
            {
                currentPage = currentPage.Navigate(typeof(LoginPage));
                currentPage = ((LoginPage)currentPage).Login(table.CreateInstance<Credentials>());
            }
        }


        [When("I navigate to the (.*) page")]
        public static void WhenINavigate(string pageName)
        {
            currentPage = currentPage.Navigate(pageName);
        }

        [When("I enter my account details")]
        public static void WhenIEnterMyAccountDetails(Table table)
        {
            if (currentPage is LoginPage)
            {
                var credentials = table.CreateInstance<Credentials>();
                currentPage = ((LoginPage)currentPage).Login(table.CreateInstance<Credentials>());
            }
            else if (currentPage is RegisterPage)
            {
                var credentials = table.CreateInstance<Credentials>();
                currentPage = ((RegisterPage)currentPage).Register(table.CreateInstance<Credentials>());
            }
            else
            {
                throw new NavigationException();
            }
        }


        [When("I log out")]
        public static void WhenILogOut()
        {
            currentPage.LogOut();
        }


        [Then(@"I am on the (.*) page")]
        public static void ThenIAmOnThePage(string pageName)
        {
            var expectedPageType = PageFactory.GetExpectedPageType(pageName);
            Assert.IsInstanceOf(expectedPageType, currentPage);
            Assert.IsTrue(currentPage.Validate());
        }




        [Then("I am logged (in|out)")]
        public static void ThenIAmLoggedInOrOut(string inOrOut)
        {
            Assert.AreEqual(currentPage.IsLoggedIn(), inOrOut.ToLowerInvariant() == "in");
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            PageFactory.CreateWebdriver();

            currentPage = PageFactory.GetPage("Home");
        }

        [AfterFeature]
        public static void AfterFeature()
        {
            PageFactory.CloseWebdriver();
        }


    }
}
