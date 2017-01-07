using NUnit.Framework;
using ArtOfTest.WebAii.Core;
using System.Collections.Generic;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace DeleteLanguage.Test
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestMethod1()
        {
            Manager manager;
            Settings mySettings = new Settings();
            //Preconditions
            //go to WOW application
            mySettings.Web.DefaultBrowser = BrowserType.Chrome;
            manager = new Manager(mySettings);
            manager.Start();
            manager.LaunchNewBrowser();
            manager.ActiveBrowser.NavigateTo("https://192.168.195.249");
            //
            IList<HtmlControl> description = manager.ActiveBrowser.Find.AllByXPath<HtmlControl>("//div[@class='text-primary']/h2/small");
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
            //login as admin
            HtmlButton loginButton = manager.ActiveBrowser.Find.ByAttributes<HtmlButton>("class=btn btn-success");
            loginButton.Click();
            HtmlInputEmail loginInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputEmail>("ng-model=email");
            loginInput.Text = "admin.wow@ukr.net";
            HtmlInputPassword passwordInput = manager.ActiveBrowser.Find.ByAttributes<HtmlInputPassword>("ng-model=password");
            passwordInput.Text = "qwerty";
            HtmlInputSubmit submitInput = manager.ActiveBrowser.Find.ByName<HtmlInputSubmit>("loginButton");
            submitInput.Click();
            //click on language
            HtmlSpan languages = manager.ActiveBrowser.Find.ByContent<HtmlSpan>("Languages");
            languages.Click();

            //Add new language
            
            HtmlSelect selectLanguage = manager.ActiveBrowser.Find.ByAttributes<HtmlSelect>("ng-options=language.Name for language in languageList");
            selectLanguage.SelectByText("Afrikaans", true);

            HtmlSpan addLanguage = manager.ActiveBrowser.Find.ByAttributes<HtmlSpan>("class=input-group-btn");
            addLanguage.MouseClick();

            //html languageRow = manager.ActiveBrowser.Find.ByContent<HtmlTableRow>("Afrikaans");

            //manager.Dispose();


    }
    }
}
