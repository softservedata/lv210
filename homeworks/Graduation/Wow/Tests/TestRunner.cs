
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
            Application.Get(ApplicationSourcesRepository.ChromeByIP());
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Application.Get().DisposeManager();
        }
    }
}
