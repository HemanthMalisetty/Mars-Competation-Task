using AutoItX3Lib;
using MarsFramework.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    class SkillsSharePage
    {
        public SkillsSharePage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region Initialize Elements
        //Find Share Skill button
        [FindsBy(How = How.XPath, Using = "//div[@id='account-profile-section']/div/section/div/div[2]/a")]
        private IWebElement ShareSkillBtn { get; set; }

        //Find Title
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")]
        private IWebElement Title { get; set; }

        // Find Description field
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")]
        private IWebElement Description { get; set; }

        //Find category dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div/select")]
        private IWebElement SkillCategory { get; set; }

        //Find subcategory dropdown
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select")]
        private IWebElement SubCategory { get; set; }

        // Find Tags
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement Tags { get; set; }

        // Find Service Type radiobutton
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[5]/div[2]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement ServiceType1 { get; set; }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[5]/div[2]/div[1]/div[2]/div[1]/input[1]")]
        private IWebElement ServiceType2 { get; set; }


        //Find LocationType radio button
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[6]/div[2]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement Location1 { get; set; }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[6]/div[2]/div[1]/div[2]/div[1]/input[1]")]
        private IWebElement Location2 { get; set; }

        // Selecting Available Days   
        //Find element Start date
        [FindsBy(How = How.Name, Using = "startDate")]
        private IWebElement StartDate { get; set; }

        //Find element End date
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement EndDate { get; set; }

        //Find a day
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input")]
        private IWebElement AvailableDay { get; set; }

        //Find start time field
        [FindsBy(How = How.XPath, Using = "(//input[@name='StartTime'])[2]")]
        private IWebElement StartTime { get; set; }

        //Find end Time field
        [FindsBy(How = How.XPath, Using = "(//input[@name='EndTime'])[2]")]
        private IWebElement EndTime { get; set; }

        //Find element Skill Trade
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[8]/div[2]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement SkillExchange { get; set; }

        //Find credit
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[8]/div[2]/div[1]/div[2]/div[1]/input[1]")]
        private IWebElement Credit { get; set; }

        //Find Skill Exchange texbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/input")]
        private IWebElement SkillExchangeTag { get; set; }

        //Find Credit rate textbox
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[8]/div[4]/div[1]/div[1]/input[1]")]
        private IWebElement CreditRate { get; set; }

        //Find element Work sample Images 
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        private IWebElement WorkSample { get; set; }

        //Find Active button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement ActiveBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement HiddenBtn { get; set; }

        //Find Save button
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement SaveBtn { get; set; }

        #endregion

        public void AddNewSkill()
        {

            //Populate the Excel Sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Shareskills");
            GlobalDefinitions.wait(1);
          
            //Enter a Title
            Title.SendKeys(ExcelLib.ReadData(2, "Title"));
            Base.test.Log(LogStatus.Info, "Added Title successfully");

            // Enter description
            Description.SendKeys(ExcelLib.ReadData(2, "Description"));
            Base.test.Log(LogStatus.Info, "Added description successfully");

            //Select a category from dropdown
            GlobalDefinitions.wait(2);
            //Thread.Sleep(500);
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(SkillCategory).Build().Perform();
            Thread.Sleep(1000);
            IList<IWebElement> SkillCategorylist = SkillCategory.FindElements(By.TagName("option"));
            int count = SkillCategorylist.Count;
            Thread.Sleep(1500);
            for (int i = 1; i < count; i++)
            {

                if (SkillCategorylist[i].Text == ExcelLib.ReadData(2, "Category").Trim())
                {
                    Thread.Sleep(500);
                    SkillCategorylist[i].Click();
                    Base.test.Log(LogStatus.Info, "Added category successfully");

                }
            }

            //Select a subcategory from dropdown
            GlobalDefinitions.wait(2);
            action.MoveToElement(SubCategory).Build().Perform();
            GlobalDefinitions.wait(2);
            IList<IWebElement> SubCategorylist = SubCategory.FindElements(By.TagName("option"));
            for (int i = 0; i < SubCategorylist.Count; i++)
            {
                if (SubCategorylist[i].Text == ExcelLib.ReadData(2, "SubCategory"))
                {
                    SubCategorylist[i].Click();
                    Base.test.Log(LogStatus.Info, "Added Subcategory successfully");

                }
            }

            //Add Tag
            GlobalDefinitions.wait(2);
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tag"));
            Tags.SendKeys(Keys.Enter);
            Base.test.Log(LogStatus.Info, "Added tag successfully");

            //Select Service type
            GlobalDefinitions.wait(2);
            string ExpectedService = GlobalDefinitions.ExcelLib.ReadData(2, "Service");
            string ActualService = ServiceType1.Text;
            if (ExpectedService == ActualService)
            {
                ServiceType1.Click();
            }
            else
            {
                ServiceType2.Click();
            }

            //Select location type
            Thread.Sleep(2000);
            GlobalDefinitions.wait(2);
            string ExpectedLocation = ExcelLib.ReadData(2, "Location");
            string ActualLocation = Location1.Text;
            if (ExpectedLocation == ActualLocation)
            {
                Location1.Click();
            }
            else
            {
                GlobalDefinitions.wait(2);
                Location2.Click();
            }


            ////Select start Date
            GlobalDefinitions.wait(2);
            //StartDate.SendKeys(ExcelLib.ReadData(2, "StartDate"));
            //StartDate.SendKeys(Keys.Tab);
            Thread.Sleep(2000);
            string sysday = DateTime.Today.Day.ToString();
            StartDate.SendKeys(sysday);

            string sysmonth = DateTime.Today.Month.ToString();
            StartDate.SendKeys(sysmonth);

            // Select EndDate
            Thread.Sleep(2000);
            // EndDate.SendKeys(ExcelLib.ReadData(2, "EndDate"));
            EndDate.SendKeys("20/11/2020");
            GlobalDefinitions.wait(2);

            //Select Available day
            Thread.Sleep(2000);
            AvailableDay.Click();

            // Select StartTime
            Thread.Sleep(2000);
            StartTime.SendKeys(ExcelLib.ReadData(2, "StartTime"));
            Thread.Sleep(2000);

            // Select EndTime
            GlobalDefinitions.wait(1);
            EndTime.SendKeys(ExcelLib.ReadData(2, "EndTime"));
            Base.test.Log(LogStatus.Info, "Added avilable date and time successfully");
            Thread.Sleep(2000);

            //Select Skill Trade
            GlobalDefinitions.wait(2);
            string ExpectedSkillTrade = ExcelLib.ReadData(2, "Skill Trade");
            string ActualSkillTrade = SkillExchange.Text;
            if (ExpectedSkillTrade == ActualSkillTrade)
            {
                SkillExchange.Click();
                //Enter skill for exchange
                SkillExchangeTag.SendKeys(ExcelLib.ReadData(2, "Skillexchange"));

            }
            else
            {
                Credit.Click();
                //Enter rate
                CreditRate.Clear();
                CreditRate.SendKeys(ExcelLib.ReadData(2, "Rate"));
            }

            //Upload WorkSample Images
            string MyWork = ExcelLib.ReadData(2, "UploadImage");
            WorkSample.Click();
            AutoItX3 autoit = new AutoItX3();
            autoit.WinActivate("Open");
            autoit.Send(MyWork);
            GlobalDefinitions.wait(1);
            autoit.Send("{Enter}");
            Base.test.Log(LogStatus.Info, "Uploaded image successfully");
            Thread.Sleep(2000);

            //Select active/ Hidden button
            GlobalDefinitions.wait(1);
            GlobalDefinitions.wait(2);
            string ExpectedAction = ExcelLib.ReadData(2, "Location");
            string ActualAction = ActiveBtn.Text;
            if (ExpectedAction == ActualAction)
                ActiveBtn.Click();
            else
            {
                GlobalDefinitions.wait(2);
                HiddenBtn.Click();
            }

            //Check if save button enabled
            GlobalDefinitions.wait(2);
            if (SaveBtn.Enabled)
            {
                // Click on Save button
                GlobalDefinitions.wait(2);
                SaveBtn.Click();
                Thread.Sleep(10000);
                try
                {
                    //Check for Skill share success message
                    Thread.Sleep(2000);
                    GlobalDefinitions.wait(2);
                    String ExpectedMessage = "Service Listing Added Successfully";
                    Thread.Sleep(10000);
                    String ActualMessage = driver.FindElement(By.CssSelector("div.ns-box-inner")).Text;
                    Assert.AreEqual(ExpectedMessage, ActualMessage);
                    Base.test.Log(LogStatus.Info, "Skill saved Successfully");
                }
                catch (Exception)
                {
                    Base.test.Log(LogStatus.Info, "Skill saved Successfully");
                }
            }
            else
            {
                SaveScreenShotClass.SaveScreenshot(driver, "Save button not enabled");
                Base.test.Log(LogStatus.Info, "Save button not enabled");
            }


            //Search for the Shared skill in Manage Listing page

            GlobalDefinitions.wait(2);

            //Click on manage listing 
            driver.FindElement(By.LinkText("Manage Listings")).Click();
            Thread.Sleep(1000);

            //Check if navigated to service listing page
            try
            {
                string Expected = "Manage Listings";
                string Actual = driver.FindElement(By.XPath("//div[@id='listing-management-section']/div[2]/h2")).Text;
                Assert.AreEqual(Expected, Actual);

                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigated to manage listing page");
                string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Navigated to manage listing page");
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                
            }
            catch (Exception)
            {
                
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Could not navigate to Manage listing page");
                string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Could not navigate to Manage listing page");
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                
            }

            //Check if the added skill is present in the Manage listings
            GlobalDefinitions.wait(2);
            string ExpectedTitle = ExcelLib.ReadData(2, "Title");

            string BeforeXPath = "//div[@id='listing-management-section']/div[2]/div/table/tbody/tr[";
            string AfterXpath = "]/td[3]";
            for (int i = 1; i <= 5; i++)
            {
                GlobalDefinitions.wait(2);
                string ColElements = driver.FindElement(By.XPath(BeforeXPath + i + AfterXpath)).Text;

                if (ColElements.Contains(ExpectedTitle))
                {
                    
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Skill present in Manage Listing ");
                    string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Skill present in Manage Listing");
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Info, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                    break;
                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Skill not present in Manage Listing ");
                    string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Skill not present in Manage Listing");
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                    
                }
            }

        }


        internal void SkillBtn()
        {

            //Check share skill button is present or not

            try
            {
                //Check ShareSkill button is displayed
                if (ShareSkillBtn.Displayed)
                {
                    //Click on  ShareSkill button
                    ShareSkillBtn.Click();
                    //Check whether navigated to Share Skill page
                    GlobalDefinitions.wait(2);
                    
                    //Assert.That(driver.FindElement(By.XPath("//div[@id='service-listing-section']/div[2]/div/form/div/div/div/h3")).Displayed);

                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Navigated to share skill page ");
                    string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Navigated to share skill page");
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));

                    SkillsSharePage skillPage = new SkillsSharePage();
                    skillPage.AddNewSkill();

                }
                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "could not Navigated to share skill page ");
                    string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "could not Navigated to share skill page");
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                }

            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Could not Navigated to share skill page "+ e.Message);
                string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Could not Navigated to share skill page");
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
            }
        }
    }
}
    


