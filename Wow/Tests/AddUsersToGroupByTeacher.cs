using System;
using System.Threading;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Collections.Generic;
using Wow.Data;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class AddUsersToGroupByTeacher : TestRunner
    {
        private static readonly object[] TestSigninData =
        {
            new object[] { UserRepository.Get().Admin() },
        };

        [Test, TestCaseSource(nameof(TestSigninData))]
        public void TestSignin(User admin)
        {
            // Precondition
            // Test Steps
            LoginPage loginPage = Pages.Application.Get().Login();
            UsersPage usersPage = loginPage.SuccessAdminLogin(admin);
            //UsersPage usersPage = Application.Get().Login().SuccessAdminLogin(admin);
            //
            // Check
            Assert.AreEqual("LV-204 ISTQB", usersPage.GetUsernameText());
            //
            // Return to previous state
            loginPage = usersPage.GotoLogOut();
            //
            // Check
            Assert.AreEqual("SoftServe Language School", loginPage.GetLoginDescriptionText());

 


            //--------------------------------------------------------------

            //[Test]
            Manager manager;
            Settings mySettings = new Settings();
            //
            // Precondition
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            manager = new Manager(mySettings);
            manager.Start();
            manager.LaunchNewBrowser();
            manager.ActiveBrowser.NavigateTo("https://wow.training.local/Index#/Home");
            //
            IList<HtmlControl> description = manager.ActiveBrowser.Find.AllByXPath<HtmlControl>("//div[@class='text-primary']/h2/small");
            Console.WriteLine("description = " + description.Count);
            if ((description.Count == 0) && (manager.ActiveBrowser.BrowserType == BrowserType.Chrome))
            {
                for (int i = 0; i < 5; i++)
                {
                    manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Tab);
                }
                manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Space);
                manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Tab);
                manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Tab);
                manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(System.Windows.Forms.Keys.Enter);
            }
            Thread.Sleep(1000);
            HtmlButton loginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            loginButton.Click();
            HtmlInputEmail loginInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=email");
            loginInput.Text = "mar_yanap@yahoo.de";
            Thread.Sleep(1000);
            HtmlInputPassword passwordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=password");
            passwordInput.Text = "q2w3e4r5";
            Thread.Sleep(1000);
            HtmlInputSubmit submitInput = manager.ActiveBrowser.Find.ByName<HtmlInputSubmit>("loginButton");
            submitInput.Click();
            Thread.Sleep(2000);
            // Check
            HtmlSpan userAccount = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("ng-bind=userName");
            Assert.AreEqual("Mariana Medynska", userAccount.TextContent);

            //Steps---------------------------------------------------------------------------------------------

            HtmlSpan managerButton = manager.ActiveBrowser.Find.ByContent<HtmlSpan>("p:Manager");
            managerButton.Click();
            //# cursorStyle > span:nth-child(2)
            // //*[@id="cursorStyle"]/span[1]

            HtmlSpan groupsButton = manager.ActiveBrowser.Find.ByContent<HtmlSpan>("l:Groups");
            managerButton.Click();
            //  //*[@id="teaching-tools"]/li/ul/li[4]/a/span
            //#teaching-tools > li > ul > li:nth-child(4) > a > span

            var myGroupsText = manager.ActiveBrowser.Find.ByXPath("//h2['My Groups']");
            Assert.AreEqual("My Groups", myGroupsText.TextContent);
            // #myJum > div > div.container.ng-scope > div:nth-child(1) > div > h2
            // //*[@id="myJum"]/div/div[3]/div[1]/div/h2 
            // //h2["My Groups"]

            HtmlButton editPencilButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("//*[@id='myJum']/div/div[3]/div[4]/table/tbody/tr[2]/td[3]/a");
            editPencilButton.Click();
            //#myJum > div > div.container.ng-scope > div.panel.panel-default > table > tbody > tr:nth-child(2) > td:nth-child(3) > a
            // //*[@id="myJum"]/div/div[3]/div[4]/table/tbody/tr[2]/td[3]/a

            //Check if Test_M
            //var testMGroup = manager.ActiveBrowser.Find.ByAttributes<HtmlDiv>("class=col-md-4 text-left blod-text ng-binding");
            //testMGroup.Get
            //class = col-md-4 text-left blod-text ng-binding
            //# myJum > div > div.container.ng-scope > div:nth-child(2) > h3.col-md-4.text-left.blod-text.ng-binding
            // //*[@id="myJum"]/div/div[3]/div[2]/h3[1]

            HtmlButton selectDropdown = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=dropdown-toggle ng-binding btn btn-default");
            selectDropdown.Click();

            HtmlControl selectDropDownDialog = manager.ActiveBrowser.Find.ByAttributes<HtmlControl>("class=dropdown-menu dropdown-menu-form");
            //selectDropDownDialog.           - check names in the lists at least five

            HtmlAnchor checkAll = manager.ActiveBrowser.Find.ByContent<HtmlAnchor>("p:Check All");
            checkAll.Click();                 // how to check if names are checked/unchecked

            HtmlAnchor UnCheckAll = manager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("class=glyphicon glyphicon-remove");
            UnCheckAll.Click();

            HtmlInputSearch studentSearchByName = manager.ActiveBrowser.Find.ByAttributes<HtmlInputSearch>("class=form-control ng-pristine ng-valid ng-touched");

            HtmlButton submitChangesButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-default center- block");
            

            manager.Dispose();
            Console.WriteLine("done");
        }
    }       
}
