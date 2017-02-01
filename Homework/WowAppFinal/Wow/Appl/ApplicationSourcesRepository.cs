namespace Wow.Appl
{
    public sealed class ApplicationSourcesRepository
    {
        private static volatile ApplicationSourcesRepository instance;
        private static readonly object Synchronize = new object();

        private ApplicationSourcesRepository() { }

        // Static factory
        public static ApplicationSourcesRepository Get()
        {
            if (instance == null)
            {
                lock (Synchronize)
                {
                    if (instance == null)
                    {
                        instance = new ApplicationSourcesRepository();
                    }
                }
            }
            return instance;
        }

        public static ApplicationSources Default()
        {
            return ChromeByIp();
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

        public static ApplicationSources ChromeByIp()
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
