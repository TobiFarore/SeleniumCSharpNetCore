using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumCSharpNetCore
{
    public class Tests : DriverHelper
    {
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("SetUp");
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
            
            Console.WriteLine("Test1");
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}