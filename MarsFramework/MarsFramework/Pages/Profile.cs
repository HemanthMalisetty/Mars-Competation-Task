using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;
using static MarsFramework.Global.GlobalDefinitions;

namespace MarsFramework.Pages
{
    internal class Profile
    {

        public Profile()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        #region  Initialize Web Elements 
        //Click on Edit button
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/i[1]")]
        private IWebElement ProfileEdit { get; set; }

        //User Details FirstName
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/input[1]")]
        private IWebElement FirstName { get; set; }

        //User Details LastName
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[1]/input[2]")]
        private IWebElement LastName { get; set; }

        //Save User Details
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[2]/div[1]/div[2]/button[1]")]
        private IWebElement SaveUserDetails { get; set; }

       // Click on availability dropdown
       [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.four.wide.column > div > div > div > div > div > div.extra.content > div > div:nth-child(2) > div > span > i")]
        private IWebElement AvailabilityTime { get; set; }

        //Click on Availability Time option
        [FindsBy(How = How.Name, Using = "availabiltyType")]
        private IWebElement AvailabilityTimeOpt { get; set; }

        //Click on  Availability Hour 
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.four.wide.column > div > div > div > div > div > div.extra.content > div > div:nth-child(3) > div > span > i")]
        private IWebElement AvailabilityHours { get; set; }

        //select Availability Hour from drop down
        [FindsBy(How = How.Name, Using = "availabiltyHour")]
        private IWebElement Availability { get; set; }

        //Click on earn target
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.four.wide.column > div > div > div > div > div > div.extra.content > div > div:nth-child(4) > div > span > i")]
        private IWebElement EarnTarget { get; set; }

        //select earn target from drop down
        [FindsBy(How = How.Name, Using = "availabiltyTarget")]
        private IWebElement selectTarget { get; set; }


        //-----------------------------ADD Description-------------------
        //Click  Desctiption icon
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > div > div > div > h3 > span > i")]
        private IWebElement DescrIco { get; set; }

        //Enter  Desctiption 
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > div > div > form > div > div > div.ui.twelve.wide.column > div.field > textarea")]
        private IWebElement Description { get; set; }

        //Click on Save Button
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > div > div > form > div > div > div.ui.twelve.wide.column > button")]
        private IWebElement Save { get; set; }

        //-----------------ADD Language-----------------------
        //Click on Add new button
        [FindsBy(How =How.CssSelector,Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > table > thead > tr > th.right.aligned > div")]
        private IWebElement AddNewBtn { get; set; }

        //Enter the Language on text box
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement AddLangText { get; set; }

        //Enter the Language level on text box
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > div > div:nth-child(2) > select")]
        private IWebElement ChooseLangLevel { get; set; }

        //Enter the Language on text box
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[3]/div/div[2]/div/div/div[2]/select/option[3]")]
        //private IWebElement ChooseLangOpt { get; set; }

        //Add Language
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.active.tooltip-target > div > div.twelve.wide.column.scrollTable > div > div > div.six.wide.field > input.ui.teal.button")]
        private IWebElement AddLang { get; set; }

        //--------------------------ADD Skills--------------------------------
        //Add//Click on skill tab
        [FindsBy(How = How.CssSelector,Using ="#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.top.attached.tabular.menu > a:nth-child(2)")]
        private IWebElement SkillTab { get; set; }

        //Click on Add new to add new skill
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div > div.twelve.wide.column.scrollTable > div > table > thead > tr > th.right.aligned > div")]
        private IWebElement AddNewSkillBtn { get; set; }

        //Enter the Skill on text box
        [FindsBy(How = How.Name, Using = "name")]
        private IWebElement AddSkillText { get; set; }

        //Click on skill level dropdown
        [FindsBy(How = How.Name, Using = "level")]
        private IWebElement ChooseSkilllevel { get; set; }

        //Add Skill
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div > div.twelve.wide.column.scrollTable > div > div > span > input.ui.teal.button")]
        private IWebElement AddSkill { get; set; }

        //----------------------------ADD Education --------------------------------------------

        //Click on Educaiton Tab
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.top.attached.tabular.menu > a:nth-child(3)")]
        private IWebElement EducationTab { get; set; }

        //Click on Add new to Educaiton
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div > div.twelve.wide.column.scrollTable > div > table > thead > tr > th.right.aligned > div")]
        private IWebElement AddNewEducation { get; set; }

        //Enter university in the text box
        [FindsBy(How = How.Name, Using = "instituteName")]
        private IWebElement EnterUniversity { get; set; }

        //Choose the country
        [FindsBy(How = How.Name, Using = "country")]
        private IWebElement ChooseCountry { get; set; }

        ////Choose the skill level option
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[1]/div[2]/select/option[6]")]
        //private IWebElement ChooseCountryOpt { get; set; }

        //Click on Title dropdown
        [FindsBy(How = How.Name, Using = "title")]
        private IWebElement ChooseTitle { get; set; }

        ////Choose title
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[1]/select/option[5]")]
        //private IWebElement ChooseTitleOpt { get; set; }

        //Degree
        [FindsBy(How = How.Name, Using = "degree")]
        private IWebElement Degree { get; set; }

        //Year of graduation
        [FindsBy(How = How.Name, Using = "yearOfGraduation")]
        private IWebElement DegreeYear { get; set; }

        ////Choose Year
        //[FindsBy(How = How.XPath, Using = "//*[@id='account-profileEdit-section']/div/section[2]/div/div/div/form/div[5]/div/div[2]/div/div/div[2]/div[3]/select/option[4]")]
        //private IWebElement DegreeYearOpt { get; set; }

        //Click on Add
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div > div.twelve.wide.column.scrollTable > div > div > div:nth-child(3) > div > input.ui.teal.button")]
        private IWebElement AddEdu { get; set; }

        //-------------------------------------ADD Certification----------------------------------

        //Click on Certificate Tab
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.top.attached.tabular.menu > a:nth-child(4)")]
        private IWebElement CertiTab { get; set; }

        //Add new Certificate
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div.row > div.twelve.wide.column.scrollTable > div > table > thead > tr > th.right.aligned > div")]
        private IWebElement AddNewCertibtn { get; set; }

        //Enter Certification Name
        [FindsBy(How = How.Name, Using = "certificationName")]
        private IWebElement CertiName { get; set; }

        //Certified from
        [FindsBy(How = How.Name, Using = "certificationFrom")]
        private IWebElement CertiFrom { get; set; }

        //Year
        [FindsBy(How = How.Name, Using = "certificationYear")]
        private IWebElement CertiYear { get; set; }

        //Add Ceritification
        [FindsBy(How = How.CssSelector, Using = "#account-profile-section > div > section:nth-child(3) > div > div > div > div.eight.wide.column > form > div.ui.bottom.attached.tab.segment.tooltip-target.active > div.row > div.twelve.wide.column.scrollTable > div > div > div.five.wide.field > input.ui.teal.button")]
        private IWebElement AddCerti { get; set; }

        

        #endregion

        internal void EditProfile()
        {

            //Populate the Excel Sheet
            GlobalDefinitions.ExcelLib.PopulateInCollection(Base.ExcelPath, "Profile");
            Thread.Sleep(1000);

            //Click on Edit button
            ProfileEdit.Click();

            //User's First Name
            FirstName.Clear();
            FirstName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "FirstName"));

            //User's Last Name
            LastName.Clear();
            LastName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "LastName"));

            //Save User's Details
            SaveUserDetails.Click();

            //Availability Time option
            Thread.Sleep(1500);
            AvailabilityTime.Click();
            AvailabilityTimeOpt.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "AvailableTime"));
            

            //Availability Hours
            Thread.Sleep(2000);
            AvailabilityHours.Click();
            //Availability Hours option
            Availability.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Hours"));

            //Earn Target
            Thread.Sleep(2000);
            EarnTarget.Click();
            selectTarget.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "EarnTarget"));

            //-----------------------------------------------------

            //IJavaScriptExecutor js = GlobalDefinitions.driver as IJavaScriptExecutor;
            //Thread.Sleep(1000);
            //js.ExecuteScript("window.scrollBy(0,100);");
            //Thread.Sleep(1000);

            
            //---------------------------------------------------------
            //Click on Add New Language button
            AddNewBtn.Click();
            Thread.Sleep(1000);
            //Enter the Language
            AddLangText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Language"));

            //Choose Language
            ChooseLangLevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Level"));
            Thread.Sleep(1000);
            AddLang.Click();
            Base.test.Log(LogStatus.Info, "Added Language successfully");

            //-----------------------------------------------------------
            //Click on Add New Skill Button
            SkillTab.Click();
            AddNewSkillBtn.Click();
            //Enter the skill 
            AddSkillText.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Skill"));

            //Click the skill dropdown
            ChooseSkilllevel.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SkillsLevel"));
            Thread.Sleep(500);
            //ChooseSkilllevel.Click();
            AddSkill.Click();
            Thread.Sleep(500);
            Base.test.Log(LogStatus.Info, "Added Skills successfully");

            //---------------------------------------------------------
            //Add Education
            EducationTab.Click();
            AddNewEducation.Click();
            //Enter the University
            EnterUniversity.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"University"));

            //Choose Country
            ChooseCountry.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Country"));
            Thread.Sleep(500);
           

            //Choose Title
            ChooseTitle.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
            Thread.Sleep(500);
          

            //Enter Degree
            Degree.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Degree"));

            //Year of Graduation
            DegreeYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "GraduateYear"));
            Thread.Sleep(500);
            
            AddEdu.Click();
            Thread.Sleep(500);
            Base.test.Log(LogStatus.Info, "Added Education successfully");

            //-------------------------------------------------
            //Click on Certificate tab
            CertiTab.Click();

            //Click on add new
            AddNewCertibtn.Click();

            //Enter Certificate Name
            CertiName.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"Certificate"));

            //Enter Certified from
            CertiFrom.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2,"CertifiedFrom"));

            //Enter the Year
            CertiYear.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "CerYear")); ;
            Thread.Sleep(500);
            
            //Click Add new
            AddCerti.Click();
            Thread.Sleep(500);
            Base.test.Log(LogStatus.Info, "Added Certificate successfully");

            //-------------------------------------------------------------------------------
            //Add Description ICON
            DescrIco.Click();

            //Enter description
            Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));
            Thread.Sleep(500);

            //Click on Save
            Save.Click();
            Base.test.Log(LogStatus.Info, "Added Description successfully");


        }
    }
}