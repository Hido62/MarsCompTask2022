using MarsCompTask2022.Config;
using MarsCompTask2022.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsCompTask2022.Pages
{
    class ManageListings
    {
        private IWebDriver driver;

        //Initialising driver
        public ManageListings()
        {
           
            ExcelLibHelpers.PopulateInDataCollection((MarsResource.ExcelPath), "ManageListings");
        }

        // Defining all the Web Element                                  
        public IWebElement category => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[2]"));
        public IWebElement title => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[3]"));
        public IWebElement description => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[4]"));
        public IWebElement serviceType => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[5]"));
        public IWebElement skillTrade => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[6]/i"));
        public IWebElement credit => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[6]/i"));
        public IList<IWebElement> active => driver.FindElements(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input"));
        public IWebElement searchText => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[1]/div[1]/input"));
        public IWebElement manageListingNavigation => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));
        public IWebElement editManageListBtn => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i"));
        public IWebElement deleteManageListBtn => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr/td[8]/div/button[3]/i"));
        public IWebElement deleteManageListBtn1 => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        public IWebElement deleteManageListBtn2 => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[1]"));
        public IWebElement viewBtn => driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[1]"));
        public IWebElement bodyContent => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]"));
        public IWebElement category1 => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[1]/div/div/div/div[2]"));
        public IWebElement subCategory1 => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]"));
        public IWebElement serviceType1 => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[3]/div/div[2]"));
        public IWebElement startDate1 => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[1]/div/div[2]"));
        public IWebElement endDate1 => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[2]/div/div[2]"));
        public IWebElement locationType1 => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[3]/div/div[3]/div/div[2]"));
        public IWebElement skillTrade1 => driver.FindElement(By.XPath("//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[4]/div[2]/div/div/div[2]/span"));

        public void EditManageListings()
        {
            editManageListBtn.Click();
            WaitHelper.WaitForElementPresent(driver, "Name", "title", 5);
        }

        public void NavigateManageListings()
        {
            manageListingNavigation.Click();
            WaitHelper.WaitForElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]/i", 5);
        }

        public void AddManageListingsActive()
        {
            
            // By calling Excel library to retrive the records
            var expectedCategory = ExcelLibHelpers.ReadData(2, "Category");
            var expectedTitle = ExcelLibHelpers.ReadData(2, "Title");
            var expectedDescription = ExcelLibHelpers.ReadData(2, "Description");
            var expectedService = ExcelLibHelpers.ReadData(2, "ServiceType");

            // Wait implementation for the table to get displayed
            WaitHelper.WaitForElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input", 4);

            // By creating variables for all the records on Manage listing page
            var actualCategory = category.Text;
            var actualTitle = title.Text;
            var actualServiceType = serviceType.Text;
            var actualDescription = description.Text;

            Assert.Multiple(() =>
            {
                // Assertion to validate all the records
                Assert.AreEqual(actualCategory, expectedCategory, "Actual Category and expected category don't match");
                Assert.AreEqual(actualTitle, expectedTitle, "Actual Title and expected title don't match");
                Assert.AreEqual(actualDescription, expectedDescription, "Actual Description and expected description don't match");
                Assert.AreEqual(actualServiceType, expectedService, "Actual Service Type and expected service type don't match");
                Assert.True(active.ElementAt(0).Selected);
            });
        }

        public void EditManageListingsHidden()
        {
            
            // By calling Excel library to retrive the records
            var expectedCategory = ExcelLibHelpers.ReadData(3, "Category2");
            var expectedTitle = ExcelLibHelpers.ReadData(3, "Title2");
            var expectedDescription = ExcelLibHelpers.ReadData(3, "Description2");
            var expectedService = ExcelLibHelpers.ReadData(3, "ServiceType");

            // Wait implementation for the table to get displayed
            WaitHelper.WaitForElementPresent(driver, "XPath", "//*[@id='listing-management-section']/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[7]/div/input", 2);

            // By creating variables for all the records on Manage listing page
            var actualCategory = category.Text;
            var actualTitle = title.Text;
            var actualServiceType = serviceType.Text;
            var actualDescription = description.Text;

            Assert.Multiple(() =>
            {
                // Assertion to validate all the records
                Assert.AreEqual(actualCategory, expectedCategory, "Actual Category and expected category don't match");
                Assert.AreEqual(actualTitle, expectedTitle, "Actual Title and expected title don't match");
                Assert.AreEqual(actualDescription, expectedDescription, "Actual Description and expected description don't match");
                Assert.AreEqual(actualServiceType, expectedService, "Actual Service Type and expected service type don't match");
                Assert.False(active.ElementAt(0).Selected);
            });
        }

        public void ViewManageListingsActive()
        {
           
            viewBtn.Click();
            bodyContent.Click();
            WaitHelper.WaitForElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]", 2);
          
            // By calling Excel library to retrive the records
            var expectedCategory = "Programming & Tech";
            var expectedSubCategory = "QA";
            var expectedService = "Hourly";
            var expectedStartDate = "15122021";
            var expectedEndDate = "15122022";
            var expectedLocationType = "Online";
            var expectedSkillTrade = "Selenium";

            WaitHelper.WaitForElementPresent(driver, "XPath", "//*[@id='service-detail-section']/div[2]/div/div[2]/div[1]/div[1]/div[2]/div[2]/div/div/div[2]/div/div[2]/div/div[2]", 2);

            // By creating variables for all the records on Manage listing page
            var actualCategory = category1.Text;
            var actualSubCategory = subCategory1.Text;
            var actualServiceType = serviceType1.Text;
            var SDate = startDate1.Text;
            String ActualStartDate = String.Join("", SDate.Split('-').Reverse());
            var EDate = endDate1.Text;
            String ActualEndDate = String.Join("", EDate.Split('-').Reverse());
            var ActualLocationType = locationType1.Text;
            var ActualSkillTrade = skillTrade1.Text;

            Assert.Multiple(() =>
            {
                // Assertion to validate all the records
                Assert.AreNotEqual(actualCategory, expectedCategory, "Actual Category and expected category match");
                Assert.AreEqual(actualSubCategory, expectedSubCategory, "Actual SubCategory and expected subcategory don't match");
                Assert.AreEqual(actualServiceType, expectedService, "Actual Service Type and expected service type don't match");
                Assert.AreEqual(ActualStartDate, expectedStartDate, "Actual Start Date and expected start date don't match");
                Assert.AreEqual(ActualEndDate, expectedEndDate, "Actual End Date and expected end Date don't match");
                Assert.AreEqual(ActualLocationType, expectedLocationType, "Actual Location Type and expected location type don't match");
                Assert.AreEqual(ActualSkillTrade, expectedSkillTrade, "Actual Skill Trade and expected skill trade type don't match");               
            });

            // Back to the Manage listing Page
            driver.Navigate().Back();
        }

        public void DeleteManageListingBtn()
        {
            deleteManageListBtn.Click();

            // Wait Implementation for delete the service textbox to be visible
            WaitHelper.WaitForElementPresent(driver, "XPath", "/html/body/div[2]/div/div[3]/button[2]", 2);
            deleteManageListBtn1.Click();

            // Wait Implementation for delete the service textbox to be visible
            WaitHelper.WaitForElementVisible(driver, "XPath", "//div[@class='ns-box-inner']", 3);

            // Retrive the text from the pop up message
            String message = driver.FindElement(By.XPath("//div[@class='ns-box-inner']")).Text;
            String deletePopUpMsg = $"{title.Text} has been deleted";

            // To Check with the Pop up message for delete
            Assert.That(message, Is.EqualTo(deletePopUpMsg));
        }

        public void WithoutDelManageListBtn()
        {
            deleteManageListBtn.Click();
            // Wait Implementation for delete the service textbox to be visible
            WaitHelper.WaitForElementPresent(driver, "XPath", "/html/body/div[2]/div/div[3]/button[1]", 2);
            deleteManageListBtn2.Click();
        }
    }
}
//}

