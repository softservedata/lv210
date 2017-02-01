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

        //[SetUp]
        //public void SetUp()
        //{
        //Application.Get().StartBrowser();
        //}

        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("[TearDown] done");
            // TODO
            //Application.Get().Logout();
            //Application.Get().CloseBrowser();
        }

    }
}
