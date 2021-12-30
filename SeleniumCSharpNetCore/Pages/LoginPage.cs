using OpenQA.Selenium;

namespace SeleniumCSharpNetCore.Pages
{
    public class LoginPage 
    {
        private IWebDriver Driver;
        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }
        IWebElement txtUserName => Driver.FindElement(By.Id("UserName"));
        IWebElement txtPassword => Driver.FindElement(By.Id("Password"));
        IWebElement btnLogin => Driver.FindElement(By.XPath("//input[@value='Log in']"));

        public void EnterLoginDetails(string username, string password)
        {
            txtUserName.SendKeys(username);
            txtPassword.SendKeys(password);
        }

        public void SubmitLogin() => btnLogin.Submit();
    }
}
