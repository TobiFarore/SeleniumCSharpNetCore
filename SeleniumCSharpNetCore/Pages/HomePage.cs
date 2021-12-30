using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumCSharpNetCore.Pages
{
    public class HomePage : DriverHelper
    {
        IWebElement lnkLogin => Driver.FindElement(By.LinkText("Login"));
        IWebElement lnkLogoff => Driver.FindElement(By.LinkText("Log off"));

        public void ClickLoginLink() => lnkLogin.Click();

        public bool IsLogOffButtonDisplayed() => lnkLogoff.Displayed;
    }
}
