using OpenQA.Selenium;

namespace HelloWebforms.Pages.Helpers
{
    public static class ByExtensionMethods
    {

        public static By Attribute(string tag, string attribute, string attributeValue)
        {
            return By.XPath($"//{tag}[@{attribute}='{attributeValue}']");
        }


    }
}