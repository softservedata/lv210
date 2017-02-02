namespace Wow.Appl
{
    public sealed class ApplicationSourcesRepository
    {
        private ApplicationSourcesRepository()
        {
        }

        public static ApplicationSources DefaultBrowser()
        {
            return new ApplicationSources("Chrome", 30L, "https://192.168.195.249/Index#/Home", "https://192.168.195.249/Index#/Home");
        }

        public static ApplicationSources ChromeByTrainingLocal()
        {
            return new ApplicationSources("Chrome", 30L, "https://wow.training.local/Index#/Home", "https://wow.training.local/Index#/Home");
        }

        public static ApplicationSources ChromeByIP()
        {
            return new ApplicationSources("Chrome", 30L, "https://192.168.195.249/Index#/Home", "https://192.168.195.249/Index#/Home");
        }

    }
}
