using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;

namespace UnitTestProjectTelerikFirst
{
    [TestFixture]
    public class TelerikFirstTest
    {
        [Test]
        public void TestMethod1()
        {
            Manager manager;
            Settings mySettings = new Settings();
            //mySettings.Web.DefaultBrowser = BrowserType.FireFox;
            //mySettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            manager = new Manager(mySettings);
            manager.Start();
            manager.LaunchNewBrowser();
            manager.ActiveBrowser.NavigateTo("https://www.google.com.ua");
            Thread.Sleep(2000);
            //
            manager.Dispose();
            Console.WriteLine("done");
        }
    }
}
