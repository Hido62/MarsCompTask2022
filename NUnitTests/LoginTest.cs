using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using MarsCompTask2022.Pages;
using MarsCompTask2022.Utils;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace MarsCompTask2022.NUnitTests
{
    [TestFixture]
    class LoginTest : CommonDriver
    {
        [Test]
        public void LoginPageTest()
        {
            test = extent.CreateTest("Login");
            test.Log(Status.Info, "User Login");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();
            TestContext.WriteLine(loginPageObj);
        }
    }
}
