using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCSharpNetCore
{
    public class Tests : DriverHelper
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp");
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--headless");
            new DriverManager().SetUpDriver(new ChromeConfig());
            Driver = new ChromeDriver(options);
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com/");
            Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");
            Driver.FindElement(By.XPath("//input[@name='ctl00$ContentPlaceHolder1$ChildMeal1']/following-sibling::div[text()='Broccoli']")).Submit();

            //CustomControl.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Apple");

            //var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString();
            //var screenshot = (Driver as ITakesScreenshot).GetScreenshot();
            //screenshot.SaveAsFile($"{dir}\\screenshot.png");
            //Assert.Pass();
        }

        //[Test]
        //public void LoginTest()
        //{
        //    Driver.Navigate().GoToUrl("http://eaapp.somee.com");
        //    HomePage homePage = new HomePage();
        //    LoginPage loginPage = new LoginPage();

        //    homePage.ClickLoginLink();
        //    loginPage.EnterLoginDetails("admin", "password");
        //    loginPage.SubmitLogin();
        //    Assert.That(homePage.IsLogOffButtonDisplayed, Is.True, "Log off doesn't exisit");
        //}

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Console.WriteLine("TearDown");
        }
    }
}