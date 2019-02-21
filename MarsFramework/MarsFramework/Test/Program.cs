using MarsFramework.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {

            [Test]
            public void UserAccount()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Profile details edited successfully");

                // Create an class and object to call the method
                Profile obj = new Profile();
                obj.EditProfile();
            }
            [Test]
            public void ShareSkillPage()
            {
                // Creates a toggle for the given test, adds all log events under it
                test = extent.StartTest("New skill added successfully");

                //Create class object to call the methods
                SkillsSharePage share = new SkillsSharePage();
                share.SkillBtn();
            }

            [Test]
            public void ManageListings()
            {
                //initial log
                test = extent.StartTest("Edit,view and delete skills from Manage Listings successfully");

                // Create an class and object to call the method
                ManageListingPage obj1 = new ManageListingPage();
                obj1.EditListing();
                obj1.ViewListing();
                obj1.DeleteListingSkills();
            }


        }
        }
    }
