using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Lists.UnitTests
{
    [TestFixture]
    public class ListTestSuite
    {
        static List<int> collection = new List<int>() { 5, 27, 13, 3, 21, 3, 20, 9, 5, 7 };

        // FindPositin() Test Data

        private static readonly object[] TestData_FindPositions_Positive_Test =
        {
            new object[] { collection, 3, new List<int>() { 3, 5 } },
            new object[] { collection, 27, new List<int>() { 1 } },
            new object[] { collection, 5, new List<int>() { 0, 8 } },
        };

        private static readonly object[] TestData_FindPositions_Negative_Test =
        {
            new object[] { collection, 6, new List<int>() },
            new object[] { collection, 2, new List<int>() },
            new object[] { collection, -12, new List<int>() },
        };

        // FindPosition()Tests

        [Test]
        [TestCaseSource(nameof(TestData_FindPositions_Positive_Test))]
        public void FindPositions_Positive_Test_Should_Return_Correct_Positions(List<int> collection, int numbToFind, List<int> expected)
        {
            List<int> actual = ListUtilityClass.FindPositions(collection, numbToFind);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(nameof(TestData_FindPositions_Negative_Test))]
        public void FindPositions_Negative_Test_Should_Return_Empty_List(List<int> collection, int numbToFind, List<int> expected)
        {
            List<int> actual = ListUtilityClass.FindPositions(collection, numbToFind);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
