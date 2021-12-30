
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
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
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless");
            Driver = new ChromeDriver(options);
        }

        [Test]
        public void Test1()
        {
            Driver.Navigate().GoToUrl("https://demowf.aspnetawesome.com/");
            Driver.FindElement(By.Id("ContentPlaceHolder1_Meal")).SendKeys("Tomato");
            Driver.FindElement(By.XPath("//input[@name='ctl00$ContentPlaceHolder1$ChildMeal1']/following-sibling::div[text()='Broccoli']")).Submit();

            CustomControl.ComboBox("ContentPlaceHolder1_AllMealsCombo", "Apple");

            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString();
            var screenshot = (Driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile($"{dir}\\screenshot.png");
            Assert.Pass();
        }

        [Test]
        public void LoginTest()
        {
            Driver.Navigate().GoToUrl("http://eaapp.somee.com");
            Driver.FindElement(By.Id("loginLink")).Click();
            Driver.FindElement(By.Id("UserName")).SendKeys("admin");
            Driver.FindElement(By.Id("Password")).SendKeys("password");
            Driver.FindElement(By.XPath("//input[@value='Log in']")).Submit();

            bool isEmployeeListVisible = Driver.FindElement(By.LinkText("Employee List")).Displayed;
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).ToString();
            var screenshot = (Driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile($"{dir}\\screenshot.png");
            Assert.That(isEmployeeListVisible, Is.True);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Console.WriteLine("TearDown");
        }
    }
}