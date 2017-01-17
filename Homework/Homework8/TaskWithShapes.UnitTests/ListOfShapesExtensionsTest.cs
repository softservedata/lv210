using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace TaskWithShapes.UnitTests
{
    [TestFixture]
    public class ListOfShapesExtensionsTest
    {
        #region TestData

        private static readonly object[] CorrectTestDataForAreaInRangeFunction =
        {
            new object[]
            {
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}, 25, 30,
                new List<Shape> {{new Circle(3)}}
            },
            new object[]
            {
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}, 15, 20,
                new List<Shape>()
            }
        };

        private static readonly object[] CorrectTestDataForSearchingSymbolInNameFunction =
        {
            new object[]
            {
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}, 'e',
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}
            },
            new object[]
            {
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}, 'k',
                new List<Shape>()
            }
        };

        private static readonly object[] CorrectTestDataForRemovingItemsFunction =
        {
            new object[]
            {
                new List<Shape> {{new Circle(0.25)}, {new Square(1)}, new Circle(10)}, 10,
                new List<Shape> {{new Circle(10)}}
            },
            new object[]
            {
                new List<Shape> {{new Circle(0.5)}, {new Square(0.25)}, new Circle(1)}, 10,
                new List<Shape>()
            }
        };

        private static readonly object[] TestDataWithNullListForAreaInRangeFunction =
        {
            new object[]
            {
                null, 25, 30
            }
        };

        private static readonly object[] TestDataWithIncorrectBoundariesForAreaInRangeFunction =
        {
            new object[]
            {
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}, 45, 20
            },
            new object[]
            {
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}, 20, 20
            }
        };

        private static readonly object[] TestDataWithIncorrectPerimeter =
        {
            new object[]
            {
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}, -1
            },
            new object[]
            {
                new List<Shape> {{new Circle(4)}, {new Square(7)}, new Circle(3)}, 0
            }
        };

        #endregion

        [Test, TestCaseSource(nameof(CorrectTestDataForAreaInRangeFunction))]
        public void Should_Return_ListOfShapes_With_Area_In_Appropriate_Range(IList<Shape> listOfShapes,
            double leftBoundary, double rightBoundary, IList<Shape> expectedList)
        {
            // Test steps
            var actualList = listOfShapes.FindAllWithAreaInRange(leftBoundary, rightBoundary);
            // Check
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test, TestCaseSource(nameof(CorrectTestDataForSearchingSymbolInNameFunction))]
        public void Should_Return_ListOfShapes_With_Name_That_Contains_Appropriate_Symbol(IList<Shape> listOfShapes,
            char symbol, IList<Shape> expectedList)
        {
            // Test steps
            var actualList = listOfShapes.FindAllWithAppropriateSymbolInName(symbol);
            // Check
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        /// <summary>
        /// Test method verifies FindAndRemoveAllWithPerimeterLessThanValue() function.
        /// </summary>
        /// <param name="listOfShapes"></param>
        /// <param name="perimeterBoundary"></param>
        /// <param name="expectedList"></param>
        [Test, TestCaseSource(nameof(CorrectTestDataForRemovingItemsFunction))]
        public void Should_Remove_Shapes_With_Perimeter_Less_Than_Value(IList<Shape> listOfShapes, double perimeterBoundary,
            IList<Shape> expectedList)
        {
            // Test steps
            listOfShapes.RemoveAllWithPerimeterLessThanValue(perimeterBoundary);
            var actualList = listOfShapes;
            // Check
            CollectionAssert.AreEqual(expectedList, actualList);
        }

        [Test, TestCaseSource(nameof(TestDataWithNullListForAreaInRangeFunction))]
        public void Should_Throw_Exeption_When_List_For_ForAreaInRange_Function_IsNull(IList<Shape> listOfShapes,
            double leftBoundary, double rightBoundary)
        {
            Assert.Throws<ArgumentNullException>(() => listOfShapes.FindAllWithAreaInRange(leftBoundary, rightBoundary));
        }

        [TestCase(null,7)]
        public void Should_Throw_Exeption_When_List_For_RemoveAllWithPerimeterLessThanValue_Function_IsNull(
            IList<Shape> listOfShapes, double perimeter)
        {
            Assert.Throws<ArgumentNullException>(
                () => listOfShapes.RemoveAllWithPerimeterLessThanValue(perimeter));
        }

        [TestCase(null, 'a')]
        public void Should_Throw_Exeption_When_List_For_FindAllWithAppropriateSymbolInName_Function_IsNull(
            IList<Shape> listOfShapes, char symbol)
        {
            Assert.Throws<ArgumentNullException>(
                () => listOfShapes.FindAllWithAppropriateSymbolInName(symbol));
        }

        [Test, TestCaseSource(nameof(TestDataWithIncorrectBoundariesForAreaInRangeFunction))]
        public void Should_Throw_Exeption_When_Boundaries_ForAreaInRange_Function_AreIncorrect(
            IList<Shape> listOfShapes, double leftBoundary, double rightBoundary)
        {
            Assert.Throws<ArgumentException>(() => listOfShapes.FindAllWithAreaInRange(leftBoundary, rightBoundary));
        }

        /// <summary>
        /// Test method throws exeption when "perimeterBoundary" param for FindAndRemoveAllWithPerimeterLessThanValue()
        /// function is less or equal zero
        /// </summary>
        /// <param name="listOfShapes"></param>
        /// <param name="perimeterBoundary"></param>
        [Test, TestCaseSource(nameof(TestDataWithIncorrectPerimeter))]
        public void Should_Throw_Exeption_When_Perimeter_IsIncorrect(IList<Shape> listOfShapes, double perimeterBoundary)
        {
            Assert.Throws<ArgumentException>(() => listOfShapes.RemoveAllWithPerimeterLessThanValue(perimeterBoundary));
        }
    }
}
