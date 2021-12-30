using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class HomePage 
    {
        private IWebDriver Driver;
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        IWebElement lnkLogin => Driver.FindElement(By.LinkText("Login"));
        IWebElement lnkLogoff => Driver.FindElement(By.LinkText("Log off"));

        public void ClickLoginLink() => lnkLogin.Click();

        public bool IsLogOffButtonDisplayed() => lnkLogoff.Displayed;
    }
}
