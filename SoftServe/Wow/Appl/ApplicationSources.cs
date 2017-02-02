namespace Wow.Appl
{
    public class ApplicationSources
    {
        public string BrowserName { get; private set; }
       
        public long ImplicitTimeOut { get; private set; }
        
        public string LoginUrl { get; private set; }
        public string LogoutUrl { get; private set; }
        
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
