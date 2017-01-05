using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using Wow.Appl;

namespace Wow.Pages
{
    public class Application
    {
        private static volatile Application instance;
        private static readonly Object synchronize = new Object();
        //
        public Manager CurrentManager { get; private set; }
        public ApplicationSources applicationSources { get; private set; }

        // constructor
        private Application(ApplicationSources applicationSources)
        {
            this.applicationSources = applicationSources;
            init();
        }

        // static factory
        public static Application Get()
        {
            return Get(null);
        }

        public static Application Get(ApplicationSources applicationSources)
        {
            if (instance == null)
            {
                lock (synchronize)
                {
                    if (instance == null)
                    {
                        if (applicationSources == null)
                        {
                            applicationSources = ApplicationSourcesRepository.Default();
                        }
                        instance = new Application(applicationSources);
                    }
                }
            }
            return instance;
        }


        public void init()
        {
            InitManager();
            // TODO
            // Init Strategy from applicationSources
            // Init DB access, etc.
        }

        public LoginPage Login()
        {
            if (Manager.Current.ActiveBrowser == null)
            {
                StartBrowser();
            }
            CurrentManager.ActiveBrowser.NavigateTo(applicationSources.LoginUrl);
            return new LoginPage(CurrentManager);
        }

        public LoginPage Logout()
        {
            CurrentManager.ActiveBrowser.NavigateTo(applicationSources.LogoutUrl);
            return new LoginPage(CurrentManager);
        }

        public void StartBrowser()
        {
            CurrentManager.LaunchNewBrowser();
        }

        public void CloseBrowser()
        {
            if (Manager.Current.ActiveBrowser != null)
            {
                Manager.Current.ActiveBrowser.Close();
            }
        }

        public void DisposeManager()
        {
            if ((CurrentManager != null) && (Manager.Current.Disposed))
            {
                CurrentManager.Dispose();
            }
        }

        public string InvokeScript(string javaScript)
        {
            return Manager.Current.ActiveBrowser.Actions.InvokeScript(javaScript);
        }

        private void InitManager()
        {
            Settings currentSettings = new Settings();
            //currentSettings.Web.DefaultBrowser = BrowserType.FireFox;
            //currentSettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
            //currentSettings.Web.DefaultBrowser = BrowserType.Chrome;
            currentSettings.Web.DefaultBrowser = GetBrowser();
            CurrentManager = new Manager(currentSettings);
            CurrentManager.Start();
            //CurrentManager.LaunchNewBrowser();
        }

        private BrowserType GetBrowser()
        {
            BrowserType currentBrowser = BrowserType.InternetExplorer;
            foreach (BrowserType browserType in Enum.GetValues(typeof(BrowserType)))
            {
                if (browserType.ToString().ToLower().Contains(applicationSources.BrowserName.ToLower()))
                {
                    currentBrowser = browserType;
                    break;
                }
            }
            return currentBrowser;
        }

    }
}
