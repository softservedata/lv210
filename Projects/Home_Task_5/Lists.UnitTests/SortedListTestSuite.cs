using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Lists.UnitTests
{
    [TestFixture]
    public class SortedListTestSuite
    {
        static SortedList collection = new SortedList()
            {
                { 0, 5 },
                { 1, 27 },
                { 2, -13 },
                { 3, 3 },
                { 4, 21 },
                { 5, 3 },
                { 6, 20 },
                { 7, 9 },
                { 8, 5 },
                { 9, 7 },
            };

        // FindPositions() Test Data

        private static readonly object[] TestData_FindPositions_Positive_Test =
        {
            new object[] { collection, 3, new List<int>() { 3, 5 } },
            new object[] { collection, 27, new List<int>() { 1} },
            new object[] { collection, 5, new List<int>() { 0, 8 } },
        };

        private static readonly object[] TestData_FindPositions_Negative_Test =
        {
            new object[] {collection, 6, new List<int>()},
            new object[] {collection, 2, new List<int>()},
            new object[] {collection, -12, new List<int>()},
        };

        // FindPositions() Tests

        [Test]
        [TestCaseSource(nameof(TestData_FindPositions_Positive_Test))]
        public void FindPositions_Positive_Test_Should_Return_Correct_Positions(SortedList collection, int numbToFind, List<int> expected)
        {
            List<int> actual = ListUtilityClass.FindPositions(collection, numbToFind);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(nameof(TestData_FindPositions_Negative_Test))]
        public void FindPositions_Negative_Test_Should_Return_Empty_List(SortedList collection, int numbToFind, List<int> expected)
        {
            List<int> actual = ListUtilityClass.FindPositions(collection, numbToFind);

            CollectionAssert.AreEqual(expected, actual);
        }

        // Remove() Test Data

        private static readonly object[] TestData_Remove_Positive_Test =
        {
            new object[] { collection, 20, new SortedList { { 0, 5 }, { 2, -13 }, { 3, 3 }, { 5, 3 }, { 6, 20 }, { 7, 9 }, { 8, 5 }, { 9, 7 } } },
            new object[] { collection, 10, new SortedList { { 0, 5 }, { 2, -13 }, { 3, 3 }, { 5, 3 }, { 7, 9 }, { 8, 5 }, { 9, 7 } } },
            new object[] { collection, 0, new SortedList { { 2, -13 } } }
        };

        private static readonly object[] TestData_Remove_Negative_Test =
        {
            new object[] { collection, 27, new SortedList { { 0, 5 }, { 1, 27 }, { 2, -13 }, { 3, 3 }, { 4, 21 }, { 5, 3 }, { 6, 20 }, { 7, 9 }, { 8, 5 }, { 9, 7 } } },
            new object[] { collection, 27, new SortedList { { 0, 5 }, { 1, 27 }, { 2, -13 }, { 3, 3 }, { 4, 21 }, { 5, 3 }, { 6, 20 }, { 7, 9 }, { 8, 5 }, { 9, 7 } } },
            new object[] { collection, 27, new SortedList { { 0, 5 }, { 1, 27 }, { 2, -13 }, { 3, 3 }, { 4, 21 }, { 5, 3 }, { 6, 20 }, { 7, 9 }, { 8, 5 }, { 9, 7 } } },
        };

        // Remove() Tests

        [Test]
        [TestCaseSource(nameof(TestData_Remove_Positive_Test))]
        public void Remove_Positive_Test_Should_Remove_From_SortedList_Elements(SortedList collection, int upperLimit, SortedList expected)
        {
            SortedList actual = collection;
            ListUtilityClass.Remove(actual, upperLimit);

            CollectionAssert.AreEqual(expected.Values, actual.Values);
        }

        [Test]
        [TestCaseSource(nameof(TestData_Remove_Negative_Test))]
        public void Remove_Negative_Test_SortedList_Should_Be_Same(SortedList collection, int upperLimit, SortedList expected)
        {
            SortedList actual = collection;
            ListUtilityClass.Remove(actual, upperLimit);

            CollectionAssert.AreEqual(expected.Values, actual.Values);
        }
    }
}
