using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;


namespace MarsCompTask2022.Pages
{
    class HomePage
    {
        private IWebDriver driver;

        private IWebElement MouseHover => driver.FindElement(By.XPath("html/body/div/div/div/div[1]/div[2]/div/span"));

        private IWebElement GoToProfile => driver.FindElement(By.XPath("//*[@id='service-search-section']/div[1]/div[2]/div/span/div/a[1]"));

        private IWebElement ShareSkills => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/div[2]/a"));

        private IWebElement manageListing => driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[3]"));


        public void NavToHomePage()
        {
           
            Actions Hover = new Actions(driver);

            //Select Seller from the seller dropdown
            Hover.MoveToElement(MouseHover).Perform();

            //Select "Go to profile" from seller dropdown
            GoToProfile.Click();
        }

        public void ShareSkillBtn()
        {
            //Navigate to share skill button
            
            ShareSkills.Click();
        }

        public void NavManageListings()
        {
            //Navigate to manage Listing Tab
           
            manageListing.Click();
        }

    }
}
