using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Appl
{
    // builder interfaces
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

    // dependency inversion interface
    public interface IApplicationSources
    {
        string GetBrowserName();
        long GetImplicitTimeOut();
        string GetLoginUrl();
        string GetLogoutUrl();
    }

    public class ApplicationSources : IBrowserName, IImplicitTimeOut, ILoginUrl, ILogoutUrl, IBuilder, IApplicationSources
    {
        // Browser Data
        private string browserName;
        private long implicitTimeOut;
        // URLs
        private string loginUrl;
        private string logoutUrl;

        // constructor
        private ApplicationSources()
        {
            //default
        }

        // static factory
        // public static User Get() // old
        public static IBrowserName Get()
        {
            return new ApplicationSources();
        }

        //setters
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

        //getters

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
