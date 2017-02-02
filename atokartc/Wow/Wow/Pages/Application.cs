using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.Win32.Dialogs;
using NLog;
using System;
using Wow.Appl;

namespace Wow.Pages
{
    public class Application
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private static volatile Application instance;
        private static readonly Object synchronize = new Object();

        public Manager CurrentManager { get; private set; }
        public ApplicationSources applicationSources { get; private set; }

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
                            applicationSources = ApplicationSourcesRepository.DefaultBrowser();
                        }
                        instance = new Application(applicationSources);
                    }
                }
            }
            return instance;
        }

        public void init()
        {
            logger.Debug("Start init()");
            InitManager();
            logger.Debug("Done init()");
        }

        public LoginPage Login()
        {
            StartBrowser();
            ApplicationPage.Get().NavigateTo(applicationSources.LoginUrl);
            return new LoginPage(CurrentManager);
        }

        public LoginPage Logout()
        {
            StartBrowser();
            ApplicationPage.Get().NavigateTo(applicationSources.LogoutUrl);
            return new LoginPage(CurrentManager);
        }

        public void StartBrowser()
        {
            logger.Debug("Start StartBrowser()");

            InitManager();
            if (Manager.Current.ActiveBrowser == null)
            {
                logger.Trace("Run CurrentManager.LaunchNewBrowser();");
                CurrentManager.LaunchNewBrowser();
            }

            logger.Debug("Done StartBrowser()");
        }

        public void CloseBrowser()
        {
            logger.Debug("Start CloseBrowser()");

            if (Manager.Current.ActiveBrowser != null)
            {
                Manager.Current.ActiveBrowser.Close();
            }

            logger.Debug("Done CloseBrowser()");
        }

        public void DisposeManager()
        {
            logger.Debug("Start DisposeManager()");

            Console.WriteLine("+++DisposeManager()");
            CloseBrowser();

            if ((CurrentManager != null) && (Manager.Current != null))
            {
                logger.Trace("Run CurrentManager.Dispose();");
                Console.WriteLine("+++CurrentManager.Dispose();");
                CurrentManager.Dispose();
            }

            logger.Debug("Done DisposeManager()");
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
            if ((CurrentManager == null) || (Manager.Current == null))
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
