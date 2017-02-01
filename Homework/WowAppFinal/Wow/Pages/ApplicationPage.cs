using System.Windows.Forms;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    public class ApplicationPage
    {
        private static volatile ApplicationPage instance;
        private static readonly object Synchronize = new object();
        private readonly Manager manager;
        private readonly string controlLocator;

        private ApplicationPage(Manager manager)
        {
            this.manager = manager;
            this.controlLocator = "//div[@class='text-primary']/h2/small";
        }

        public static ApplicationPage Get()
        {
            if (instance?.manager == null || (!Manager.Current.Disposed))
            {
                lock (Synchronize)
                {
                    if (instance?.manager == null || (!Manager.Current.Disposed))
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