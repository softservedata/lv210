using System;
using NUnit.Framework;
using ArtOfTest.WebAii.Core;

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
            mySettings.Web.DefaultBrowser = BrowserType.FireFox;
            manager = new Manager(mySettings);
            manager.Start();
            manager.LaunchNewBrowser();
        }
    }
}
