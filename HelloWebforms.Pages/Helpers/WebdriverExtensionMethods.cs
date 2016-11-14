using OpenQA.Selenium;

namespace HelloWebforms.Pages.Helpers
{
    public static class WebdriverExtensionMethods
    {
        public static void SendKeys(this IWebElement element, string value, bool clearFirst)
        {
            if (clearFirst) element.Clear();
            element.SendKeys(value);
        }

        public static string GetText(this IWebDriver driver)
        {
            return driver.FindElement(By.TagName("body")).Text;
        }

        public static bool HasElement(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            return true;
        }



    }

}
