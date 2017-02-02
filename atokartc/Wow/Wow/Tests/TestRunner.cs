using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Console.WriteLine("[OneTimeSetUp] done");
            Application.Get(ApplicationSourcesRepository.ChromeByIP());
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            Console.WriteLine("[OneTimeTearDown] done");
            Application.Get().DisposeManager();
        }

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] done");
        }
    }
}
