using System;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Win32.Dialogs;
using Wow.Appl;
using NLog;

namespace Wow.Pages
{
    public class Application
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        private static volatile Application instance;
        private static readonly object Synchronize = new object();

        private Application(ApplicationSources applicationSources)
        {
            this.ApplicationSourcesData = applicationSources;
            Init();
        }

        public Manager CurrentManager { get; private set; }
        public ApplicationSources ApplicationSourcesData { get; private set; }

        // Static factory
        public static Application Get()
        {
            return Get(null);
        }

        public static Application Get(ApplicationSources applicationSources)
        {
            if (instance == null)
            {
                lock (Synchronize)
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

        public void Init()
        {
            InitManager();
        }

        public LoginPage Login()
        {
            StartBrowser();
            ApplicationPage.Get().NavigateTo(ApplicationSourcesData.GetLoginUrl());
            return new LoginPage(CurrentManager);
        }

        public LoginPage Logout()
        {
            StartBrowser();
            // CurrentManager.ActiveBrowser.NavigateTo(applicationSources.LogoutUrl);
            // TODO now do not working properly
            ApplicationPage.Get().NavigateTo(ApplicationSourcesData.GetLogoutUrl());
            return new LoginPage(CurrentManager);
        }

        public void StartBrowser()
        {
            InitManager();
            if (Manager.Current.ActiveBrowser == null)
            {
                CurrentManager.LaunchNewBrowser();
            }
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
            CloseBrowser();
            if ((CurrentManager != null) && (Manager.Current != null))
            {
                CurrentManager.Dispose();
            }
        }

        public string InvokeScript(string javaScript)
        {
            InitManager();
            return Manager.Current.ActiveBrowser.Actions.InvokeScript(javaScript);
        }

        public void AddAlertDialog()
        {
            StopAlertDialog();
            Manager.Current.DialogMonitor.AddDialog(AlertDialog.CreateAlertDialog(Manager.Current.ActiveBrowser, DialogButton.OK));
            Manager.Current.DialogMonitor.Start();
        }

        public void StopAlertDialog()
        {
            if (Manager.Current.DialogMonitor.IsMonitoring)
            {
                Manager.Current.DialogMonitor.Stop();
            }
        }

        private void InitManager()
        {
            if ((CurrentManager == null) || (!Manager.Current.Disposed))
            {
                Settings currentSettings = new Settings();

                currentSettings.Web.DefaultBrowser = GetBrowser();
                currentSettings.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;
                CurrentManager = new Manager(currentSettings);

                CurrentManager.Start();
            }
        }

        private BrowserType GetBrowser()
        {
            BrowserType currentBrowser = BrowserType.InternetExplorer;

            foreach (BrowserType browserType in Enum.GetValues(typeof(BrowserType)))
            {
                if (browserType.ToString().ToLower().Contains(ApplicationSourcesData.GetBrowserName().ToLower()))
                {
                    currentBrowser = browserType;
                    break;
                }
            }

            return currentBrowser;
        }
    }
}