using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace Calc.UnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class ParallelTest
    {
        public static IEnumerable<TestCaseData> GetTestData()
        {
            yield return new TestCaseData(10);
            yield return new TestCaseData(13);
        }

        //[Test]
        [Test, TestCaseSource("GetTestData")]
        public void FirstTest(int arg0)
        {
            Console.WriteLine("ParallelTest.FirstTest(): Thread = " + Thread.CurrentThread.ManagedThreadId 
                + " arg0 = " + arg0);
        }

        //[Test]
        public void SecondTest()
        {
            Console.WriteLine("ParallelTest.SecondTest(): Thread = " + Thread.CurrentThread.ManagedThreadId);
        }
    }

    //[TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    class ParallelTest2
    {
        //[Test]
        public void FirstTest2()
        {
            Console.WriteLine("ParallelTest2.FirstTest2(): Thread = " + Thread.CurrentThread.ManagedThreadId);
        }

        //[Test]
        public void SecondTest2()
        {
            Console.WriteLine("ParallelTest2.SecondTest2(): Thread = " + Thread.CurrentThread.ManagedThreadId);
        }
    }

}
