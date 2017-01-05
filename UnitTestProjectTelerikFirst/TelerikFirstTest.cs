using System;
using System.Threading;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;
using System.Collections.Generic;

namespace UnitTestProjectTelerikFirst
{
    [TestFixture]
    public class TelerikFirstTest
    {
        //[Test]
        public void TestMethod1()
        {
            Manager manager;
            Settings mySettings = new Settings();
            //
            //mySettings.Web.DefaultBrowser = BrowserType.FireFox;
            //mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            manager = new Manager(mySettings);
            //manager.Settings.Web.BaseUrl = "https://www.google.com.ua";
            manager.Start();
            manager.LaunchNewBrowser();
            //manager.Settings.Web.RecycleBrowser = true;
            //manager.Settings.Web.KillBrowserProcessOnClose = true;
            manager.ActiveBrowser.NavigateTo("http://java.training.local:8080/registrator/login");
            //
            HtmlInputText login = manager.ActiveBrowser.Find.ById<HtmlInputText>("login");
            login.Text = "admin11111";
            Thread.Sleep(2000);
            //
            //manager.ActiveBrowser.Refresh();
            //Thread.Sleep(2000);
            //login.Refresh();
            //
            login.Text = "admin";
            //HtmlInputPassword password = manager.ActiveBrowser.Find.ById<HtmlInputPassword>("password");
            //password.Text = "admin";
            //
            //IList<HtmlInputPassword> passwords = manager.ActiveBrowser.Find.AllByAttributes<HtmlInputPassword>("name=password");
            //Console.WriteLine("passwords size = " + passwords.Count);
            //
            // Do not use local variables
            manager.ActiveBrowser.Find.ById<HtmlInputPassword>("password").Text = "admin";
            //
            HtmlButton signin = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-primary");
            signin.Click();
            //
            HtmlButton account = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-primary btn-sm");
            Assert.AreEqual("admin", account.TextContent, "Error found");
            Thread.Sleep(2000);
            //
            manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-primary btn-sm dropdown-toggle").Click();
            manager.ActiveBrowser.Find.ByXPath<HtmlAnchor>("//a[contains(@href,'/logout')]").Click();
            //
            HtmlImage image = manager.ActiveBrowser.Find.ByTagIndex<HtmlImage>("img",0);
            Assert.IsTrue(image.Src.ToLower().Contains("ukraine_logo2.gif"));
            Thread.Sleep(2000);
            //
            manager.Dispose();
            Console.WriteLine("done");
        }

        //[Test]
        public void TestMethod2()
        {
            Manager manager;
            Settings mySettings = new Settings();
            //
            //mySettings.Web.DefaultBrowser = BrowserType.FireFox;
            //mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            manager = new Manager(mySettings);
            //manager.Settings.Web.BaseUrl = "https://www.google.com.ua";
            manager.Start();
            manager.LaunchNewBrowser();
            //manager.Settings.Web.RecycleBrowser = true;
            //manager.Settings.Web.KillBrowserProcessOnClose = true;
            manager.ActiveBrowser.NavigateTo("http://java.training.local:8080/registrator/login");
            //
            HtmlSelect language = manager.ActiveBrowser.Find.ById<HtmlSelect>("changeLanguage");
            //
            //language.SelectByIndex(2);
            language.SelectByText("english",true);
            //language.Click();
            //manager.ActiveBrowser.Refresh();
            //manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//option[contains(@value,'en')]").Click();
            Assert.AreEqual("Login", manager.ActiveBrowser.Find.ByAttributes("for=inputEmail").TextContent);
            Thread.Sleep(2000);
            //
            //language.SelectByIndex(1);
            language.SelectByText("русский", true);
            //language.Click();
            //manager.ActiveBrowser.Refresh();
            //manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//option[contains(@value,'ru')]").Click();
            Assert.AreEqual("Логин", manager.ActiveBrowser.Find.ByAttributes("for=inputEmail").TextContent);
            Thread.Sleep(2000);
            //
            //language.SelectByIndex(0);
            language.SelectByText("українська", true);
            //language.Click();
            //manager.ActiveBrowser.Refresh();
            //manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//option[contains(@value,'uk')]").Click();
            Assert.AreEqual("Логін", manager.ActiveBrowser.Find.ByAttributes("for=inputEmail").TextContent);
            Thread.Sleep(2000);
            //
            manager.Dispose();
            Console.WriteLine("done");
        }

        //[Test]
        public void TestMethod3()
        {
            Manager manager;
            Settings mySettings = new Settings();
            //
            // Precondition
            //mySettings.Web.DefaultBrowser = BrowserType.FireFox;
            //mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            manager = new Manager(mySettings);
            manager.Start();
            manager.LaunchNewBrowser();
            manager.ActiveBrowser.NavigateTo("https://wow.training.local/Index#/Home");
            //
            IList<HtmlControl> description = manager.ActiveBrowser.Find.AllByXPath<HtmlControl>("//div[@class='text-primary']/h2/small");
            Console.WriteLine("description = " + description.Count);
            if ((description.Count == 0)  && (manager.ActiveBrowser.BrowserType == BrowserType.Chrome))
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
            // 
            // Check JS injection
            //Manager.Current.ActiveBrowser.Actions.InvokeScript("alert('Ha-Ha-Ha')");
            //Thread.Sleep(2000);
            //string strBool = Actions.InvokeScript("Alert('Ha-Ha-Ha')");
            //
            // Test Steps
            HtmlButton loginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            loginButton.Click();
            //HtmlInputEmail loginInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("class=form-control ng-pristine ng-valid ng-valid-email ng-touched");
            HtmlInputEmail loginInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=email");
            loginInput.Text = "wowira@ukr.net";
            Thread.Sleep(1000);
            HtmlInputPassword passwordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=password");
            passwordInput.Text = "irawow123";
            Thread.Sleep(1000);
            HtmlInputSubmit submitInput = manager.ActiveBrowser.Find.ByName<HtmlInputSubmit>("loginButton");
            submitInput.Click();
            Thread.Sleep(2000);
            //
            // Check
            HtmlSpan userAccount = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("ng-bind=userName");
            //Console.WriteLine("HtmlSpan userAccount done");
            Assert.AreEqual("LV-204 ISTQB", userAccount.TextContent);
            //Console.WriteLine("Assert.AreEqual LV - 204 ISTQB done");
            //
            // Return to previous state
            manager.ActiveBrowser.Find.ById<HtmlDiv>("dropdownBtn").Click();
            //Console.WriteLine("dropdownBtn done");
            Thread.Sleep(2000);
            // logout
            manager.ActiveBrowser.Find.ByAttributes<HtmlAnchor>("ng-click=logOut()").Click();
            //Manager.Current.ActiveBrowser.Actions.InvokeScript("logOut();");
            Console.WriteLine("ng-click=logOut() done");
            Thread.Sleep(2000);
            //HtmlControl loginDescription = manager.ActiveBrowser.Find.ByXPath<HtmlControl>("//div[@class='text-primary']/h2/small");
            var loginDescription = manager.ActiveBrowser.Find.ByXPath("//div[@class='text-primary']/h2/small");
            Console.WriteLine("loginDescription done loginDescription.TextContent = " + loginDescription.TextContent);
            Assert.AreEqual("SoftServe Language School", loginDescription.TextContent);
            //
            manager.Dispose();
            Console.WriteLine("done");
        }

        [Test]
        public void TestMethod4()
        {
            Manager manager;
            Settings mySettings = new Settings();
            //
            // Precondition
            //mySettings.Web.DefaultBrowser = BrowserType.FireFox;
            //mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            manager = new Manager(mySettings);
            //manager.Start();
            //manager.LaunchNewBrowser();
            if (Manager.Current.ActiveBrowser != null)
            {
                Manager.Current.ActiveBrowser.Close();
            }
            //if (manager != null)
            if (Manager.Current.Disposed)
            {
                manager.Dispose();
            }
        }

    }
}
