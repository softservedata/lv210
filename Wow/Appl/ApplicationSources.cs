using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Appl
{
    public class ApplicationSources
    {
        // Browser Data
        public string BrowserName { get; private set; }
        //private string driverPath;
        // private string browserPath;
        // private string defaulProfile;
        //
        // Implicit and Explicit Waits
        public long ImplicitTimeOut { get; private set; }
        // private long explicitTimeOut;
        //
        // Localization Strategy
        // private string language;
        //
        // Search Strategy
        // private string searchStrategy;
        //
        // Logger Strategy
        // private string loggerStrategy;
        //
        // URLs
        public string LoginUrl { get; private set; }
        public string LogoutUrl { get; private set; }
        // private String logoutJS;
        // private String serverUrl;
        //
        // Connect to DB

        // constructor
        public ApplicationSources(string BrowserName, long ImplicitTimeOut, string LoginUrl, string LogoutUrl)
        {
            this.BrowserName = BrowserName;
            this.ImplicitTimeOut = ImplicitTimeOut;
            this.LoginUrl = LoginUrl;
            this.LogoutUrl = LogoutUrl;
        }

    }
}
