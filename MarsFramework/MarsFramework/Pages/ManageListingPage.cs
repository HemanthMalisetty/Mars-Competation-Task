using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    class ManageListingPage
    {
        public ManageListingPage()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }


        #region IWebElements

        //Defining Manage Listings tab
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Listings')]")]
        IWebElement MgmtListTab { get; set; }

        //Defining "Edit" icon
        [FindsBy(How = How.XPath, Using = "(.//*[normalize-space(text()) and normalize-space(.)='Off'])[1]/following::i[2]")]
        IWebElement EditIcon { get; set; }

        //Defining "Delete" icon
        [FindsBy(How = How.CssSelector, Using = "#listing-management-section > div:nth-child(3) > div:nth-child(2) > table > tbody > tr:nth-child(1) > td:nth-child(8) > i.remove.icon")]
        IWebElement DeleteIcon { get; set; }

        //Defining "popup" 
        [FindsBy(How = How.CssSelector, Using = "/html/body/div[2]/div")]
        IWebElement PopUp { get; set; }


        //Defining Yes btn
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[2]")]
        IWebElement YesBtn { get; set; }

        //Defining No btn
        [FindsBy(How = How.XPath, Using = "/html/body/div[2]/div/div[3]/button[1]")]
        IWebElement NoBtn { get; set; }

        //Defining Share Skill button
        [FindsBy(How = How.CssSelector, Using = "#listing-management-section > section.nav-secondary > div > div.right.item > a")]
        IWebElement ShareSkillBtn { get; set; }

        //Defining "Title" textbox
        [FindsBy(How = How.Name, Using = "title")]
        IWebElement Title { get; set; }

        //Defining "Description" textbox
        [FindsBy(How = How.Name, Using = "description")]
        IWebElement Description { get; set; }

        //Defining "Category" dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        IWebElement category { get; set; }

        //Defining "Subcategory" dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        IWebElement Subcategory { get; set; }

        //Defining "Tags" textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        IWebElement Tags { get; set; }

        //Defining "Service Section" 
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']")] // "//" means descendant  * means anything for example, input or div or option
        IWebElement ServiceListingSection { get; set; }

        //Defining "Service Type" checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']//input[@type='radio'][@name='serviceType']")]
        IWebElement ServiceType { get; set; }

        //Defining "Location Type" checkbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']//input[@type='radio'][@name='locationType']")]
        IWebElement LocationType { get; set; }

        //Defining "Start Date" - Available Days
        [FindsBy(How = How.Name, Using = "startDate")]
        IWebElement StartDate { get; set; }

        //Defining "End Date" 
        [FindsBy(How = How.Name, Using = "endDate")]
        IWebElement EndDate { get; set; }

        //Defining "Day" 
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[7]/div[2]/div[1]/div[5]/div[1]/div[1]/input[1]")]
        IWebElement Day { get; set; }

        //Defining "Start Hours" - Available Hours
        [FindsBy(How = How.XPath, Using = "(//input[@name='StartTime'])[4]")]
        IWebElement StartHours { get; set; }

        //Defiding "End Hours" - Available Hours 
        [FindsBy(How = How.XPath, Using = "(//input[@name='EndTime'])[4]")]
        IWebElement EndHours { get; set; }

        //Deifing "Loading an Image"
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[9]/div/div[2]/section/div/label/div/span/i")]
        IWebElement ImageLoad { get; set; }

        //Defining "Skill Trade" radio button
        [FindsBy(How = How.Name, Using = "skillTrades")]
        IWebElement SkillTrade { get; set; }

        //Defining "Credit" textbox
        [FindsBy(How = How.Name, Using = "charge")]
        IWebElement Credit { get; set; }

        //Defining "Skill Exchange " textbox
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/input")]
        IWebElement SkillExchange { get; set; }

        //Defining "Active" checkbox
        [FindsBy(How = How.Name, Using = "isActive")]
        IWebElement Hidden { get; set; }

        //Defining "Save" button 
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        IWebElement SaveButton { get; set; }


        #endregion


        #region EditListing 

        internal void EditListing()
        {
            //Clicking on the "Manage Listing" tab
            MgmtListTab.Click();

            //Clicking on the "Edit Icon"

            Thread.Sleep(2000);
            EditIcon.Click();
            Thread.Sleep(2000);

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "EditListing");

            //Edit the Title 
            Title.Clear();
            Thread.Sleep(500);
            Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Base.test.Log(LogStatus.Pass, "Title has succesfully been edited");

            //Edit the Description
            Description.Clear();
            Thread.Sleep(500);
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Base.test.Log(LogStatus.Pass, "Description has succesfully been edited");

            //Select a category from dropdown
            GlobalDefinitions.wait(2);
            Actions action = new Actions(GlobalDefinitions.driver);
            action.MoveToElement(category).Build().Perform();
            Thread.Sleep(1000);
            IList<IWebElement> Categorylist = category.FindElements(By.TagName("option"));
            int count = Categorylist.Count;
            Thread.Sleep(1500);
            for (int i = 1; i < count; i++)
            {

                if (Categorylist[i].Text == ExcelLib.ReadData(2, "category").Trim())
                {
                    Thread.Sleep(500);
                    Categorylist[i].Click();
                    Thread.Sleep(500);
                    Base.test.Log(LogStatus.Info, "Category has succesfully been edited");

                }
            }

            //Edit the Subcategory 
            Thread.Sleep(2000);
            action.MoveToElement(Subcategory).Build().Perform();
            Thread.Sleep(1000);
            IList<IWebElement> SubCat = Subcategory.FindElements(By.TagName("option"));
            int SubCatCount = SubCat.Count;
            for (int i = 0; i < SubCatCount; i++)
            {
                if (SubCat[i].Text == GlobalDefinitions.ExcelLib.ReadData(2, "Subcategory"))
                {
                    SubCat[i].Click();
                    Base.test.Log(LogStatus.Pass, "Subcategory has succesfully been edited");
                }
            }

            //Edit the Tags
            Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            Thread.Sleep(1000);
            Tags.SendKeys(Keys.Enter);
            Base.test.Log(LogStatus.Pass, "Tag has succesfully been edited");


            //Edit the Service Type----------------------- 
            // Storing all the elements under category of 'Service Type' in the list of WebLements
            IList<IWebElement> AllRadioButtons = ServiceListingSection.FindElements(By.XPath("//input[@type='radio'][@name='serviceType']"));
            //Indicating the number of buttons present
            int Size = AllRadioButtons.Count;
            //Starting the loop from the first radio button to the last radio button of Service Type
            for (int i = 0; i < Size; i++)
            {
                //Storing the radio button to the string variable "Value", using the "value" attribute
                string Value = AllRadioButtons.ElementAt(i).GetAttribute("value");
                int j = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[" + j + "]/div/label")).Text;

                //Checking if Name equals the "name" attribute - "locationType"
                if (Name.Equals(ExcelLib.ReadData(2, "ServiceType")) && Value.Equals("" + i))
                {
                    AllRadioButtons.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Service Type has succesfully been edited");
                }

            }
            //Editing the Location Type 
            IList<IWebElement> AllTypes = ServiceListingSection.FindElements(By.XPath("//input[@type='radio'][@name='locationType']"));
            int Types = AllTypes.Count;
            for (int i = 0; i < Types; i++)
            {
                string Type = AllTypes.ElementAt(i).GetAttribute("value");
                int k = i + 1;
                var Name = GlobalDefinitions.driver.FindElement(By.XPath("//*[@id='service-listing-section']//div[2]/div/form/div[6]/div[2]/div/div[" + k + "]/div/label")).Text;

                //Checking if Name equals the "name" attribute - "locationType"
                if (Name.Equals(ExcelLib.ReadData(2, "LocationType")) && Type.Equals("" + i))
                {
                    AllTypes.ElementAt(i).Click();
                    Base.test.Log(LogStatus.Pass, "Location Type has succesfully been edited");
                }
            }

            // Editing Available Days -Start Date  
            Thread.Sleep(1000);
            StartDate.SendKeys(Keys.Delete);
            Thread.Sleep(500);
            StartDate.SendKeys("25/04/2019");
            Thread.Sleep(500);
            StartDate.SendKeys(Keys.Tab);
            Base.test.Log(LogStatus.Pass, "Start Date has succesfully been edited");

            //Editing Available Days - End Date 
            Thread.Sleep(1000);
            EndDate.SendKeys(Keys.Delete);
            Thread.Sleep(500);
            EndDate.SendKeys("24/12/2020");
            //EndDate.SendKeys(ExcelLib.ReadData(2, "EndDate"));
            Thread.Sleep(500);
            EndDate.SendKeys(Keys.Tab);
            Base.test.Log(LogStatus.Pass, "End Date has succesfully been edited");


            //Editing Day 
            Day.Click();

            //Editing Start Hour 
            StartHours.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "StartHour"));

            //Editing End Hour
            GlobalDefinitions.wait(5);
            EndHours.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EndHour"));

            //Editing Skill Trade radio button
            IList<IWebElement> OneSelection = ServiceListingSection.FindElements(By.XPath("//input[@type='radio'][@name='skillTrades']"));
            bool aValue = false;
            aValue = OneSelection.ElementAtOrDefault(0).Selected;
            if (aValue == true)
            {
                OneSelection.ElementAt(1).Click();
                Thread.Sleep(1500);
                Credit.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
                Base.test.Log(LogStatus.Pass, "Skill Trade has succesfully been edited");
              
            }
            else
            {
                OneSelection.ElementAt(0).Click();
                Thread.Sleep(1500);
                SkillExchange.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
                Base.test.Log(LogStatus.Pass, "Skill Trade has not been edited");
            }

            //Editing "Active" button - whether enable or disable service 
            IList<IWebElement> OneRadioButton = ServiceListingSection.FindElements(By.XPath("//input[@type='radio'][@name='isActive']"));
            bool bValue = false;
            bValue = OneRadioButton.ElementAtOrDefault(0).Selected;
            if (bValue == true)
            {
                OneRadioButton.ElementAt(1).Click();
            }
            else
            {
                OneRadioButton.ElementAt(0).Click();
            }

            Thread.Sleep(3000);
            string ActualValue = GlobalDefinitions.ExcelLib.ReadData(2, "Active  Service");
            Thread.Sleep(3000);
            string ExpectedValue = "Hidden";
            
            if (ExpectedValue.Trim().Equals(ActualValue.Trim()))
            //if (ExpectedValue == ActualValue)
            {
                Base.test.Log(LogStatus.Pass, "Service is disabled");
            }
            else
            {
                Base.test.Log(LogStatus.Fail, "Service is enabled");
            }
            //Clicking on Save Button
            SaveButton.Click();
            Base.test.Log(LogStatus.Pass, "Listing has successfully been edited");

            //Check if the edited skill is present in the Manage Listings
            try
            {
                GlobalDefinitions.wait(2);
                string ExpectedTitle = ExcelLib.ReadData(2, "Title");

                string BeforeXPath = "//div[@id='listing-management-section']/div[2]/div/table/tbody/tr[";
                Thread.Sleep(2000);
                string AfterXpath = "]/td[3]";
                for (int i = 1; i <= 5; i++)
                {
                    GlobalDefinitions.wait(2);
                    string ColElements = driver.FindElement(By.XPath(BeforeXPath + i + AfterXpath)).Text;

                    if (ColElements.Contains(ExpectedTitle))
                    {
                        
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Edited Listing is displayed on the Listing Service page ");
                        string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Edited Listing is displayed on the Listing Service page");
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));

                        break;
                    }
                    else

                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Edited Listing is not displayed on the Listing Service page ");
                        string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Edited Listing is not displayed on the Listing Service page");
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                        
                    }
                }
            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Error while displaying the edited listing" + e.Message);
                string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Error, the listing has not been edited");
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
               
            }
        }
        #endregion

        #region Delete existing Skills from Manage listing page.

        internal void DeleteListingSkills()
        {

            //Click on Manage LIsting tab 
            MgmtListTab.Click();

            Thread.Sleep(1000);

            // Delete skills form managelisting page
            DeleteIcon.Click();

            try
            {
              //Check the popup  "Delete your service" is present or not
                if (PopUp != null)
                {
                    //If yes button found,then click on it and Navigate to Managelisting page
                    YesBtn.Click();
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Yes button found on popup ");
                    string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Yes button found on popup");
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath)); 

                }

                else
                {
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Yes button is not found on popup ");
                    string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Yes button found on popup");
                    Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                }

            }
            catch (Exception e)
            {
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Yes button is not present in Delete service popup "+ e.Message);
                string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Yes button is not present in Delete service popup");
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
               
            }

        }

        #endregion

        #region ViewListing on Manage listing page

        internal void ViewListing()
        {
            try
            {
                //Clicking on Management Listing Tab
                MgmtListTab.Click();

                //Populating the test data from Excelsheet
                ExcelLib.PopulateInCollection(Base.ExcelPath, "EditListing");
                string SkillSelected = ExcelLib.ReadData(2, "Title");

                //Assigning the XPath of the whole table
                string TableRow = "//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr";

                //Gathering all elements of the table 
                var listrows = Global.GlobalDefinitions.driver.FindElements(By.XPath(TableRow));
                foreach (var Row in listrows)

                {
                    // "td[3]" is the third column, Title, in the table. It should match the value in Excelsheet 
                    if (Row.FindElement(By.XPath("td[3]")).Text.Equals(SkillSelected))
                    {
                        Thread.Sleep(2000);
                        //When the title matches the value in the Excelsheet then click on the "View Icon" for that particular title.
                        Row.FindElement(By.XPath("td[8]/i[1]")).Click();

                        Base.test.Log(LogStatus.Pass, "A listing is viewable");
                    }
                    else
                    {
                       ShareSkillBtn.Click();
                        //Thread.Sleep(1000);
                       Base.test.Log(LogStatus.Fail, "A listing is  not viewable");
                       SkillsSharePage skillsSharePage = new SkillsSharePage();
                       skillsSharePage.AddNewSkill();
                    }


                    //Verification               
                    Thread.Sleep(2000);
                    string ActualValue = Global.GlobalDefinitions.driver.FindElement(By.XPath("//span[@class='skill-title']")).Text;

                    if (SkillSelected.Trim().Equals(ActualValue.Trim()))
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "A listing cannot be viewed ");
                        string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "A listing is not viewable");
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Pass, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                    }
                    else
                    {
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "A listing cannot be viewed ");
                        string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "A listing is not viewable");
                        Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
                        
                    }
                }
            }

            catch (Exception e)
            {
                
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "A listing cannot be viewed " + e.Message);
                string screenshotpath = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "A listing is not viewable");
                Base.test.Log(RelevantCodes.ExtentReports.LogStatus.Fail, "Snapshot below:" + Base.test.AddBase64ScreenCapture(screenshotpath));
            }

        }
        #endregion


    }
}





