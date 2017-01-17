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
                            applicationSources = ApplicationSourcesRepository.ChromeByIP();
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
            Console.WriteLine("+++DisposeManager()");
            CloseBrowser();
            if ((CurrentManager != null) && (Manager.Current.Disposed))
            {
                Console.WriteLine("+++CurrentManager.Dispose();");
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
