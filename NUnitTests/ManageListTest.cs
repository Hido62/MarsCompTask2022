using AventStack.ExtentReports;
using MarsCompTask2022.Utils;
using MarsCompTask2022.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace MarsCompTask2022.NUnitTests
{
    [TestFixture]
    class ManageListTest : CommonDriver
    {
        [Test, Order(1), Description("View the Share Skill record")]
        public void ViewManageListingsTest()
        {
            test = extent.CreateTest("Deleted Share Skill and Manage listing is Deleted");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();

            loginPageObj.LoginSteps();

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings();
            manageListsObj.NavigateManageListings();
            manageListsObj.ViewManageListingsActive();
            test.Log(Status.Info, "Manage Listings of Share Skill is Deleted");
        }

        [Test, Order(2), Description("Without delete the Share Skill record")]
        public void DeleteManageListingsTest1()
        {
            test = extent.CreateTest("Without delete the Share Skill and Manage listing is Deleted");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();

            loginPageObj.LoginSteps();

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings();
            manageListsObj.NavigateManageListings();
            manageListsObj.WithoutDelManageListBtn();
            test.Log(Status.Info, "Manage Listings of Share Skill is not Deleted");
        }

        [Test, Order(3), Description("Delete the Share Skill record")]
        public void DeleteManageListingsTest()
        {
            test = extent.CreateTest("Deleted Share Skill and Manage listing is Deleted");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();

            loginPageObj.LoginSteps();

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings();
            manageListsObj.NavigateManageListings();
            manageListsObj.DeleteManageListingBtn();
            test.Log(Status.Info, "Manage Listings of Share Skill is Deleted");
        }
    }
}
