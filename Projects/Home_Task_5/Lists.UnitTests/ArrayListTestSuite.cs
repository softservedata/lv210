using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Lists.UnitTests
{
    [TestFixture]
    public class ArrayListTestSuite
    {
        static ArrayList collection = new ArrayList { 5, 27, -13, 3, 21, 3, 20, 9, 5, 7 };

        // FindPositions() Test Data

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

        // FindPositions() Tests

        [Test]
        [TestCaseSource(nameof(TestData_FindPositions_Positive_Test))]
        public void FindPositions_Positive_Test_Should_Return_Correct_Positions(ArrayList collection, int numbToFind, List<int> expected)
        {
            List<int> actual = ListUtilityClass.FindPositions(collection, numbToFind);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(nameof(TestData_FindPositions_Negative_Test))]
        public void FindPositions_Negative_Test_Should_Return_Empty_List(ArrayList collection, int numbToFind, List<int> expected)
        {
            List<int> actual = ListUtilityClass.FindPositions(collection, numbToFind);

            CollectionAssert.AreEqual(expected, actual);
        }

        // Remove() Test Data

        private static readonly object[] TestData_Remove_Positive_Test =
        {
            new object[] { collection, 20, new ArrayList { 5, -13, 3, 3, 20, 9, 5, 7 } },
            new object[] { collection, 10, new ArrayList { 5, -13, 3, 3, 9, 5, 7 } },
            new object[] { collection, 0, new ArrayList { -13 } },
        };

        private static readonly object[] TestData_Remove_Negative_Test =
        {
            new object[] { collection, 27, new ArrayList { 5, 27, -13, 3, 21, 3, 20, 9, 5, 7 } },
            new object[] { collection, 28, new ArrayList { 5, 27, -13, 3, 21, 3, 20, 9, 5, 7 } },
            new object[] { collection, 30, new ArrayList { 5, 27, -13, 3, 21, 3, 20, 9, 5, 7 } },
        };

        // Remove() Tests

        [Test]
        [TestCaseSource(nameof(TestData_Remove_Positive_Test))]
        public void Remove_Positive_Test_Should_Remove_From_List_Elements(ArrayList collection, int upperLimit, ArrayList expected)
        {
            ArrayList actual = collection;
            ListUtilityClass.Remove(actual, upperLimit);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(nameof(TestData_Remove_Negative_Test))]
        public void Remove_Negative_Test_List_Should_Be_Same(ArrayList collection, int upperLimit, ArrayList expected)
        {
            ArrayList actual = collection;
            ListUtilityClass.Remove(actual, upperLimit);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
