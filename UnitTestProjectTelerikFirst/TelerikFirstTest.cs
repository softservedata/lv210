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

        [Test]
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
    }
}
