using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtOfTest.WebAii.Core;
using ArtOfTest.WebAii.ObjectModel;
using ArtOfTest.WebAii.Controls.HtmlControls;
using ArtOfTest.WebAii.Win32.Dialogs;
using Wow.Appl;
using NLog;

namespace Wow.Pages
{
    public class Application
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        //
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
            logger.Debug("Start init()");
            InitManager();
            // TODO
            // Init Strategy from applicationSources
            // Init DB access, etc.
            logger.Debug("Done init()");
        }

        public LoginPage Login()
        {
            StartBrowser();
            //CurrentManager.ActiveBrowser.NavigateTo(applicationSources.LoginUrl);
            ApplicationPage.Get().NavigateTo(applicationSources.LoginUrl);
            return new LoginPage(CurrentManager);
        }

        public LoginPage Logout()
        {
            StartBrowser();
            //CurrentManager.ActiveBrowser.NavigateTo(applicationSources.LogoutUrl);
            // TODO now do not working properly
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
                //Manager.Current.ActiveBrowser.WaitForElement(1, null);
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
            //if ((CurrentManager != null) && (Manager.Current.Disposed))
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
            //if ((CurrentManager == null) || (!Manager.Current.Disposed))
            {
                Settings currentSettings = new Settings();
                //currentSettings.Web.DefaultBrowser = BrowserType.FireFox;
                //currentSettings.Web.DefaultBrowser = BrowserType.InternetExplorer;
                //currentSettings.Web.DefaultBrowser = BrowserType.Chrome;
                currentSettings.Web.DefaultBrowser = GetBrowser();
                //
                //currentSettings.UnexpectedDialogAction = UnexpectedDialogAction.DoNotHandle;
                currentSettings.UnexpectedDialogAction = UnexpectedDialogAction.HandleAndContinue;
                CurrentManager = new Manager(currentSettings);
                CurrentManager.Start();
                //CurrentManager.LaunchNewBrowser();
            }
            //Console.WriteLine("+++Manager.Current.Disposed = " + Manager.Current.Disposed);
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
