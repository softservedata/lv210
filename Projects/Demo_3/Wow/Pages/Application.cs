using System;
using ArtOfTest.WebAii.Core;
using NLog;
using Wow.Appl;

namespace Wow.Pages
{
    public class Application
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static volatile Application instance;
        private static readonly Object synchronize = new Object();

        private Application(ApplicationSources applicationSources)
        {
            this.applicationSources = applicationSources;
            InitManager();
        }

        public Manager CurrentManager { get; private set; }
        public ApplicationSources applicationSources { get; private set; }

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

        public LoginPage Login()
        {
            StartBrowser();
            ApplicationPage.Get().NavigateTo(applicationSources.GetLoginUrl());
            return new LoginPage(CurrentManager);
        }

        public LoginPage Logout()
        {
            StartBrowser();
            ApplicationPage.Get().NavigateTo(applicationSources.GetLogoutUrl());
            return new LoginPage(CurrentManager);
        }

        private void StartBrowser()
        {
            InitManager();
            if (Manager.Current.ActiveBrowser == null)
            {
                CurrentManager.LaunchNewBrowser();
                logger.Debug("Start Browser");
            }
        }

        private void CloseBrowser()
        {
            if (Manager.Current.ActiveBrowser != null)
            {
                Manager.Current.ActiveBrowser.Close();
                logger.Debug("Close Browser");
            }
        }

        public void DisposeManager()
        {
            CloseBrowser();
            if ((CurrentManager != null) && (Manager.Current != null))
            {
                CurrentManager.Dispose();
                logger.Debug("Dispose Manager");
            }
        }

        public void InitManager()
        {
            if ((CurrentManager == null) || (Manager.Current == null))
            {
                Settings currentSettings = new Settings();
                currentSettings.Web.DefaultBrowser = GetBrowser();
                currentSettings.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;
                CurrentManager = new Manager(currentSettings);
                CurrentManager.Start();
                logger.Debug("Init Manager");
            }
        }

        private BrowserType GetBrowser()
        {
            BrowserType currentBrowser = BrowserType.InternetExplorer;
            foreach (BrowserType browserType in Enum.GetValues(typeof(BrowserType)))
            {
                if (browserType.ToString().ToLower().Contains(applicationSources.GetBrowserName().ToLower()))
                {
                    currentBrowser = browserType;
                    break;
                }
            }
            return currentBrowser;
        }
    }
}