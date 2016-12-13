using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using DaysInMonthApp;

namespace DayInMonth.Test
{
    [TestFixture]
    public class DaysInMonthTest
    {
        [Test]
        [TestCase(0,ExpectedResult =false)]
        [TestCase(13, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = true)]
        [TestCase(12, ExpectedResult = true)]
        public bool IsMonthTest(int monthNumber)
        {
            return DaysOfMonth.IsMonth(monthNumber);
        }

        [Test]
        [TestCase(1)]
        public void CountDaysInMonth(int monthNumber)
        {
            int expected = DateTime.DaysInMonth(DateTime.Now.Year, monthNumber);
            int actual = DaysOfMonth.CountDaysInMonth(monthNumber);
        }
        
    }
}
