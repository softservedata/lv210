using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wow.Appl
{
    public sealed class ApplicationSourcesRepository
    {
        private ApplicationSourcesRepository()
        {
        }

        public static ApplicationSources Default()
        {
            return ChromeByIP();
        }

        public static ApplicationSources ChromeByTrainingLocal()
        {
            return new ApplicationSources("Chrome", 30L, "https://192.168.195.249/Index#/Home", "https://wow.training.local/Index#/Home");
        }

        public static ApplicationSources ChromeByIP()
        {
            return new ApplicationSources("Chrome", 30L, "https://192.168.195.249/Index#/Home", "https://192.168.195.249/Index#/Home");
        }

    }
}

