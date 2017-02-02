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
       
        // Implicit and Explicit Waits
        public long ImplicitTimeOut { get; private set; }

        // URLs
        public string LoginUrl { get; private set; }
        public string LogoutUrl { get; private set; }

        // constructor
        public ApplicationSources(string BrowserName, long ImplicitTimeOut, string LoginUrl, string LogoutUrl)
        {
            this.BrowserName = BrowserName;
            this.ImplicitTimeOut = ImplicitTimeOut;
            this.LoginUrl = LoginUrl;
            this.LogoutUrl = LogoutUrl;
        }
        public ApplicationSources()
        {

        }
    }
}
