using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;
using System.Collections;

namespace Calc.UnitTests
{
    public class MyFixtureData
    {
        public static IEnumerable FixtureParms
        {
            get
            {
                yield return new TestFixtureData("hello");
                yield return new TestFixtureData("zip");
            }
        }
    }

    [TestFixtureSource(typeof(MyFixtureData), "FixtureParms")]
    [Parallelizable(ParallelScope.Fixtures)]
    class ParameterizedTestFixture
    {
        private string arg0;

        public ParameterizedTestFixture(string arg0)
        {
            this.arg0 = arg0;
        }

        [Test]
        public void TestEquality()
        {
            Console.WriteLine("ParameterizedTestFixture.TestEquality(): Thread = " + Thread.CurrentThread.ManagedThreadId
               + " arg0 = " + arg0);
        }
    }
}
