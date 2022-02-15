using MarsCompTask2022.Config;
using MarsCompTask2022.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace MarsCompTask2022.Pages
{
    class LoginPage
    {
        private IWebDriver driver;

        //Initialising driver through constructor
        public LoginPage()
        {
           
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "Login");
        }

        private IWebElement logIn => driver.FindElement(By.XPath("//a[normalize-space()='Sign In']"));
        private IWebElement emailAddress => driver.FindElement(By.Name("email"));
        private IWebElement password => driver.FindElement(By.Name("password"));
        private IWebElement logInBtn => driver.FindElement(By.XPath("//button[normalize-space()='Login']"));
        private IWebElement profileName => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span"));

        private IWebElement ProfileName2 => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/div[1]/div[2]/div/span/text()[2]"));

        private string Name = ExcelLibHelpers.ReadData(2, "name");

        public void LoginSteps()
        {
            //this.driver = driver;
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "LogIn");

            //var Name = ExcelLibHelpers.ReadData(rownum, "name");
            WaitHelper.WaitForElementToBeClickable(driver, "XPath", "//a[normalize-space()='Sign In']", 2);
            logIn.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.SwitchTo().ActiveElement();
            emailAddress.Click();
            emailAddress.SendKeys(ExcelLibHelpers.ReadData(2, "username"));
            password.SendKeys(ExcelLibHelpers.ReadData(2, "password"));
            logInBtn.Click();
            TestContext.WriteLine(Name);

            Assert.AreEqual(profileName.Text, "Hi" + Name, "Actual username and expected username don't match");

            WaitHelper.WaitForElementPresent(driver, "XPath", "//*[@id='account-profile-section']/div/div[1]/div[2]/div/span", 2);
        }
    }
}
