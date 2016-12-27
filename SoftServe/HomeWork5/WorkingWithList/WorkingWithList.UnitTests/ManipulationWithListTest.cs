using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WorkingWithList.UnitTests
{
    [TestFixture]
    public class ManipulationWithListTest
    {
        ManipulationWithList manipulation = new ManipulationWithList();

        private static readonly object[] TestDataForRemoveElement =
        {
            new object[] { new List<int> { 1, 2, 3}, new List<int> { 1, 2}, 3},
            new object[] { new List<int> { 1, 1, 1}, new List<int> { }, 1},
            new object[] { new List<int> { -50, -100, 1, 5, -123}, new List<int> { -50, -100, -123 }, 1}
        };

        private static readonly object[] TestDataForGetElementPosition =
        {
            new object[] { new List<int> { 1, 2, 3}, new List<int> { 2 }, 3},
            new object[] { new List<int> { 1, 1, 1}, new List<int> { 0, 1, 2 }, 1}
        };

        private static readonly object[] TestDataForInsertElement =
        {
            new object[] { new List<int> { 1, 2, 3}, new List<int> { 4, 5, 6}, new List<int> { 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5, 6} }
        };

        private static readonly object[] TestDataForListSort =
        {
            new object[] { new List<int> { 6, 5, 4, 3, 2, 1}, new List<int> { 1, 2, 3, 4, 5, 6} }
        };

        [TestCaseSource(nameof(TestDataForRemoveElement))]
        public void ShouldRemoveElementsBiggerThanGivenNumber(List<int> list, List<int> listAfterRemove, int elementForRemove)
        {
            var expected = listAfterRemove;
            var actual = manipulation.RemoveElement(list, elementForRemove);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(TestDataForGetElementPosition))]
        public void ShouldReturnElementPositionByGivenNumber(List<int> list, List<int> elementsPositionList, int elementPosition)
        {
            var expected = elementsPositionList;
            var actual = manipulation.GetElementPosition(list, elementPosition);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(TestDataForInsertElement))]
        public void ShouldInsertElementsIntoList(List<int> currentList, List<int> listOfInsertedElements, List<int> listOfElementsPositions, List<int> resultedList)
        {
            var expected = resultedList;
            var actual = manipulation.InsertElements(currentList, listOfInsertedElements, listOfElementsPositions);

            CollectionAssert.AreEqual(expected, actual);
        }
        [TestCaseSource(nameof(TestDataForListSort))]
        public void ShouldSortList(List<int> currentList, List<int> sortedList)
        {
            var expected = sortedList;
            var actual = manipulation.Sort(currentList);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
