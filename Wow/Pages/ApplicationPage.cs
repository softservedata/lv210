using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;

namespace Wow.Pages
{
    class ApplicationPage
    {
        private static volatile ApplicationPage instance;
        private static readonly Object synchronize = new Object();
        //
        // Fields
        private Manager manager;

        // get Data
        //private IList<HtmlControl> description;
        private string controlLocator;

        // constructor
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

        // Page Object
        // get Data

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
            //IList<HtmlControl> description = manager.ActiveBrowser.Find.AllByXPath<HtmlControl>(controlLocator);
            //return description.Count > 0;
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

        // set Data
        // Business Logic
    }
}
