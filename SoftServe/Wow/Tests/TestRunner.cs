using NUnit.Framework;
using Wow.Appl;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class TestRunner
    {
        [OneTimeSetUp]
        public void Init()
        {
            Application.Get(ApplicationSourcesRepository.ChromeByTrainingLocal());
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Application.Get().DisposeManager();
        }
    }
}
