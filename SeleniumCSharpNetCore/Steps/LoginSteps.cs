using NUnit.Framework;
using SeleniumCSharpNetCore.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SeleniumCSharpNetCore.Steps
{
    [Binding]
    public class LoginSteps 
    {
        private DriverHelper _driverHelper;
        HomePage homePage;
        LoginPage loginPage;

        public LoginSteps(DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            homePage = new HomePage(_driverHelper.Driver);
            loginPage = new LoginPage(_driverHelper.Driver);
        }

        

        [Given(@"I have navigated to the application")]
        public void GivenIHaveNavigatedToTheApplication()
        {
            _driverHelper.Driver.Navigate().GoToUrl("http://eaapp.somee.com");
        }

        [Given(@"I click the login Link")]
        public void GivenIClickTheLoginLink()
        {
            homePage.ClickLoginLink();
        }

        [Given(@"I enter Username and Password")]
        public void GivenIEnterUsernameAndPassword(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            
            loginPage.EnterLoginDetails(data.Username, data.Password);
        }

        [Then(@"I click login button")]
        public void ThenIClickLoginButton()
        {
            loginPage.SubmitLogin();
        }

        [Then(@"I should see user logged in to the application")]
        public void ThenIShouldSeeUserLoggedInToTheApplication()
        {
            Assert.That(homePage.IsLogOffButtonDisplayed, Is.True, "Log off doesn't exisit");
        }

    }
}
