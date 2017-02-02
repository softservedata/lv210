using System;

namespace Wow.Appl
{
    public interface IBrowserName
    {
        IImplicitTimeOut SetBrowserName(string browserName);
    }

    public interface IImplicitTimeOut
    {
        ILoginUrl SetImplicitTimeOut(long implicitTimeOut);
    }

    public interface ILoginUrl
    {
        ILogoutUrl SetLoginUrl(string loginUrl);
    }

    public interface ILogoutUrl
    {
        IBuilder SetLogoutUrl(string logoutUrl);
    }

    public interface IBuilder
    {
        ApplicationSources Build();
    }

    public interface IApplicationSources
    {
        string GetBrowserName();
        long GetImplicitTimeOut();
        string GetLoginUrl();
        string GetLogoutUrl();
    }

    public class ApplicationSources : IBrowserName, IImplicitTimeOut, ILoginUrl, ILogoutUrl, IBuilder, IApplicationSources
    {
        private string browserName;
        private long implicitTimeOut;

        private string loginUrl;
        private string logoutUrl;

        private ApplicationSources() { }

        public static IBrowserName Get()
        {
            return new ApplicationSources();
        }

        // Setters

        public IImplicitTimeOut SetBrowserName(string browserName)
        {
            this.browserName = browserName;
            return this;
        }

        public ILoginUrl SetImplicitTimeOut(long implicitTimeOut)
        {
            this.implicitTimeOut = implicitTimeOut;
            return this;
        }

        public ILogoutUrl SetLoginUrl(string loginUrl)
        {
            this.loginUrl = loginUrl;
            return this;
        }

        public IBuilder SetLogoutUrl(string logoutUrl)
        {
            this.logoutUrl = logoutUrl;
            return this;
        }

        public ApplicationSources Build()
        {
            return this;
        }

        // Getters

        public string GetBrowserName()
        {
            return this.browserName;
        }

        public long GetImplicitTimeOut()
        {
            return this.implicitTimeOut;
        }

        public string GetLoginUrl()
        {
            return this.loginUrl;
        }

        public string GetLogoutUrl()
        {
            return this.logoutUrl;
        }
    }
}