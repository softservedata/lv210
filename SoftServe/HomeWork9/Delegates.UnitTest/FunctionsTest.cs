using System;
using NUnit.Framework;
using Delegates;

namespace Delegates.UnitTest
{
    [TestFixture]
    public class FunctionsTest
    {
        // First param - point x.
        // Second - func value at that point.
        private static readonly object[] TestDataForSinFunc =
        {
            new object[] { 1, 0.8415},
            new object[] { Math.PI/2, 1},
            new object[] { Math.PI, 0}
        };

        // First param - point x.
        // Second - func value at that point.
        private static readonly object[] TestDataForCosFunc =
        {
            new object[] { 1, 3.6209},
            new object[] { 2.6, 15.8045},
            new object[] { Math.PI, 28.3842}
        };

        [TestCaseSource(nameof(TestDataForSinFunc))]
        public void SholudCalculateSinFunctionAtAppropriatePoint(double pointX, double expected)
        {
            Functions functions = new Functions();
            var actual = functions.SinFunc(pointX);
            var precision = 0.0001;

            Assert.AreEqual(expected, actual, precision);
        }

        [TestCaseSource(nameof(TestDataForCosFunc))]
        public void SholudCalculateCosFunctionAtAppropriatePoint(double pointX, double expected)
        {
            Functions functions = new Functions();
            var actual = functions.CosFunc(pointX);
            var precision = 0.0001;

            Assert.AreEqual(expected, actual, precision);
        }
    }
}
