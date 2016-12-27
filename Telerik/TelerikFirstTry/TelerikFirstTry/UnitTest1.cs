using System;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace TelerikFirstTry
{
    [TestFixture]
    public class UnitTest1
    {
        private Manager manager;
        [Test]
        public void TestMethod()
        {
            Settings mySettings = new Settings();
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            manager = new Manager(mySettings);
            manager.Start();
            manager.LaunchNewBrowser();
            manager.ActiveBrowser.NavigateTo("https://www.google.com.ua/");
            HtmlAnchor signin = manager.ActiveBrowser.Find.ById<HtmlAnchor>("gb_70");
            //signin.MouseHover();
            //signin.Focus();
            signin.Click();
        }
    }
}
