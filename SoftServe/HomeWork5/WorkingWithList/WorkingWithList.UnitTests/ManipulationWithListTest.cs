using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace WorkingWithList.UnitTests
{
    [TestFixture]
    public class ManipulationWithListTest
    {
        ManipulationWithList manipulation = new ManipulationWithList();

        /// <summary>
        /// First object parametr - current list.
        /// Second - list after remove some element(s).
        /// Third - element(s) which should be removed.
        /// </summary>
        private static readonly object[] TestDataForRemoveElement =
        {
            new object[] { new List<int> { 1, 2, 3}, new List<int> { 1, 2}, 3},
            new object[] { new List<int> { 1, 1, 1}, new List<int> { }, 1},
            new object[] { new List<int> { -50, -100, 1, 5, -123}, new List<int> { -50, -100, -123 }, 1}
        };

        /// <summary>
        /// First object parametr - current list.
        /// Second - list of element positions.
        /// Third - element which position(s) should find.
        /// </summary>
        private static readonly object[] TestDataForGetElementPosition =
        {
            new object[] { new List<int> { 1, 2, 3}, new List<int> { 2 }, 3},
            new object[] { new List<int> { 1, 1, 1}, new List<int> { 0, 1, 2 }, 1}
        };

        /// <summary>
        /// First object parametr - current list.
        /// Second - list of elements for insert.
        /// Third - list of elements positions for insert.
        /// Fourth - resulted list.
        /// </summary>
        private static readonly object[] TestDataForInsertElement =
        {
            new object[] { new List<int> { 1, 2, 3}, new List<int> { 4, 5, 6}, new List<int> { 3, 4, 5 }, new List<int> { 1, 2, 3, 4, 5, 6} }
        };

        [TestCaseSource(nameof(TestDataForRemoveElement))]
        public void ShouldRemoveElementsBiggerThanGivenNumber(List<int> list, List<int> listAfterRemove, int elementForRemove)
        {
            var expected = listAfterRemove;
            var actual = manipulation.RemovetElementsGraterThan(list, elementForRemove);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(TestDataForGetElementPosition))]
        public void ShouldReturnElementPositionByGivenNumber(List<int> list, List<int> elementsPositionList, int elementPosition)
        {
            var expected = elementsPositionList;
            var actual = manipulation.GetElementPositions(list, elementPosition);

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestCaseSource(nameof(TestDataForInsertElement))]
        public void ShouldInsertElementsIntoList(List<int> currentList, List<int> listOfInsertedElements, List<int> listOfElementsPositions, List<int> resultedList)
        {
            var expected = resultedList;
            var actual = manipulation.InsertElements(currentList, listOfInsertedElements, listOfElementsPositions);

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
