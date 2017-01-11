using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Appl
{
    public sealed class ApplicationSourcesRepository
    {
        private static volatile ApplicationSourcesRepository _instance;
        private static readonly object Synchronize = new object();

        private ApplicationSourcesRepository() { }

        // static factory
        public static ApplicationSourcesRepository Get()
        {
            if (_instance == null)
            {
                lock (Synchronize)
                {
                    if (_instance == null)
                    {
                        _instance = new ApplicationSourcesRepository();
                    }
                }
            }
            return _instance;
        }

        public static ApplicationSources Default()
        {
            return ChromeByTrainingLocal();
        }

        public static ApplicationSources ChromeByTrainingLocal()
        {
            return ApplicationSources.Get()
                .SetBrowserName("Chrome")
                .SetImplicitTimeOut(5L)
                .SetLoginUrl("https://wow.training.local/Index#/Home")
                .SetLogoutUrl("https://wow.training.local/Index#/Home")
                .Build();
        }

        public static ApplicationSources ChromeByIP()
        {
            return ApplicationSources.Get()
                .SetBrowserName("Chrome")
                .SetImplicitTimeOut(5L)
                .SetLoginUrl("https://192.168.195.249/Index#/Home")
                .SetLogoutUrl("https://192.168.195.249/Index#/Home")
                .Build();
        }
    }
}
