using NUnit.Framework;
using Wow.Pages;

namespace Wow.Tests
{
    [TestFixture]
    public class TestRunner
    {
        [OneTimeSetUp]
        public void Init()
        {
            Application.Get();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Application.Get().DisposeManager();
        }

        [TearDown]
        public void TearDown() { }
    }
}