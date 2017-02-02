using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Core;
using System;
using System.Windows.Forms;

namespace Wow.Pages
{
    class ApplicationPage
    {
        private static volatile ApplicationPage instance;
        private static readonly Object synchronize = new Object();
        private Manager manager;
        private string controlLocator;

        private ApplicationPage(Manager manager)
        {
            this.manager = manager;
            this.controlLocator = "//div[@class='text-primary']/h2/small";
        }

        // static factory
        public static ApplicationPage Get()
        {
            if ((instance == null) || (instance.manager == null) || (!Manager.Current.Disposed))
            {
                lock (synchronize)
                {
                    if ((instance == null) || (instance.manager == null) || (!Manager.Current.Disposed))
                    {
                        instance = new ApplicationPage(Application.Get().CurrentManager);
                    }
                }
            }
            return instance;
        }

        // Functional
        private void AcceptHttpsKeyChrome()
        {
            for (int i = 0; i < 5; i++)
            {
                manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Tab);
            }

            manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Space);
            manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Tab);
            manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Tab);
            manager.ActiveBrowser.Desktop.KeyBoard.KeyPress(Keys.Enter);
        }

        private void AcceptHttpsKey()
        {
            switch (manager.ActiveBrowser.BrowserType)
            {
                case BrowserType.Chrome:
                    {
                        AcceptHttpsKeyChrome();
                        break;
                    }
                case BrowserType.FireFox:
                    {
                        // TODO
                        break;
                    }
                case BrowserType.InternetExplorer:
                    {
                        // TODO
                        break;
                    }
                default:
                    {
                        // TODO throw Exception
                        break;
                    }
            }
        }

        private bool IsHttpsKeyActive()
        {
            return manager.ActiveBrowser.Find.AllByXPath<HtmlControl>(controlLocator).Count > 0;
        }

        public void NavigateTo(string url)
        {
            manager.ActiveBrowser.NavigateTo(url);
            if (!IsHttpsKeyActive())
            {
                AcceptHttpsKey();
            }
        }

        public void DisposeInstance()
        {
            instance = null;
        }
    }
}
