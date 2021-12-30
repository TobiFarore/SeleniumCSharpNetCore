using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumCSharpNetCore.Hooks
{
    [Binding]
    public sealed class Hooks 
    {
        private DriverHelper _driverHelper;
        public Hooks(DriverHelper driverHelper) => _driverHelper = driverHelper;

        [BeforeScenario]
        public void BeforeScenario()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--headless");
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driverHelper.Driver = new ChromeDriver(options);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driverHelper.Driver.Quit();
        }
    }
}
