using AventStack.ExtentReports;
using MarsCompTask2022.Pages;
using MarsCompTask2022.Utils;
using NUnit.Framework;
using System;

namespace MarsCompTask2022.NUnitTests
{
    [TestFixture]
    class ShareSkillTest : CommonDriver
    {
        [Test, Order(1), Description("Create the empty Share Skill record")]
        public void AddwithoutShareSkillTest()
        {
            test = extent.CreateTest("Create no Share Skill with Service Enabled");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();

            loginPageObj.LoginSteps();
            TestContext.WriteLine(loginPageObj);

            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.ShareSkillBtn();

            //SaveScreenShotClass.SaveScreenshot1(testDriver, "TestShareSkill");
            test.Log(Status.Info, "Share Skill Page is Opened");

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill();

            shareSkillObj.AddwithoutData();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is not Saved");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
        }

        [Test, Order(2), Description("Create the invalid Share Skill record")]
        public void AddInvaildShareSkillTest()
        {
            test = extent.CreateTest("Create invalid Share Skill with Service Enabled");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();

            loginPageObj.LoginSteps();
            TestContext.WriteLine(loginPageObj);

            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.ShareSkillBtn();

            //SaveScreenShotClass.SaveScreenshot1(testDriver, "TestShareSkill");
            test.Log(Status.Info, "Share Skill Page is Opened");

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill();

            shareSkillObj.AddInvaildTitle();
            shareSkillObj.AddInvaildDescription();
            shareSkillObj.AddInvalidEnterTags();
            shareSkillObj.ServiceTypeHourly();
            shareSkillObj.LocationTypeOnline();
            shareSkillObj.AddInvalidAvailDays();
            shareSkillObj.AddInvalidSkillExchange();
            shareSkillObj.ActiveShareSkill();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is not Saved");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);
        }

        [Test, Order(3), Description("Create the valid Share Skill record")]
        public void CreateShareSkillTest()
        {
            test = extent.CreateTest("Create Share Skill with Service Enabled");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();

            loginPageObj.LoginSteps();
            TestContext.WriteLine(loginPageObj);

            // Home Page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.ShareSkillBtn();

            //SaveScreenShotClass.SaveScreenshot1(testDriver, "TestShareSkill");
            test.Log(Status.Info, "Share Skill Page is Opened");

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill();

            shareSkillObj.AddTitle();
            shareSkillObj.AddDescription();
            shareSkillObj.SelectAddCategory();
            shareSkillObj.SelectAddSubCategory();
            shareSkillObj.AddEnterTags();
            shareSkillObj.ServiceTypeHourly();
            shareSkillObj.LocationTypeOnline();
            shareSkillObj.AddAvailableDays();
            shareSkillObj.SkillExchange();
            shareSkillObj.ActiveShareSkill();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is Saved");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(35);

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings();
            manageListsObj.AddManageListingsActive();
            test.Log(Status.Pass, "Assert Pass as condition is True & Manage listing is active");
        }

        [Test, Order(4), Description("Edit the valid Share Skill record")]
        public void EditShareSkillTest()
        {
            test = extent.CreateTest("Edit Share Skill with Skill Trade as Skill Exchange and change it to Credit");
            test.Log(Status.Info, "Browser Initialisation");

            // Login Page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps();

            // Manage Listings Page object initialization and definition
            ManageListings manageListsObj = new ManageListings();
            manageListsObj.NavigateManageListings();
            manageListsObj.EditManageListings();

            // Share Skill Page object initialization and definition
            ShareSkill shareSkillObj = new ShareSkill();

            test.Log(Status.Info, "Share Skill Page is Opened");

            shareSkillObj.EditTitle();
            shareSkillObj.EditDescription();
            shareSkillObj.SelectEditCategory();
            shareSkillObj.SelectEditSubCategory();
            shareSkillObj.EditTags();
            shareSkillObj.ServiceTypeOne_off();
            shareSkillObj.LocationTypeOnsite();
            shareSkillObj.EditAvailableDays();
            shareSkillObj.EditCreditExchange();
            shareSkillObj.HiddenShareSkill();
            shareSkillObj.SaveShareSkill();
            test.Log(Status.Info, "ShareSkill is Saved");

            manageListsObj.EditManageListingsHidden();
            test.Log(Status.Pass, "Assert Pass as condition is True and Manage listing is Hidden");
        }
    }
}
