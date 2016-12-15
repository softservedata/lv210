using System;
using NUnit.Framework;

namespace Shape.UnitTests
{
    [TestFixture]
    public class TriangleUnitTests
    {
        // Test Data

        private static readonly object[] TestData_ConditionsMeet_True =
        {
            new object[] {new Point(3, 5), new Point(7, 3), new Point(4, 0), true },
            new object[] {new Point(3, 5), new Point(7, 3), new Point(4, 0), true },
        };

        private static readonly object[] TestData_ConditionsMeet_False =
        {
            new object[] {new Point(), new Point(), new Point() },
            new object[] {new Point(0, 0), new Point(0, 0), new Point(0, 0) },
            new object[] {new Point(0, 0), new Point(0, 0), new Point(5, 4) },
            new object[] {new Point(33, 44), new Point(20, 44), new Point(55, 44) },
        };

        private static readonly object[] TestData_ConditionsMeet_True_Line =
        {
            new object[] {9, 6, 5, true },
            new object[] {4, 2, 3, true },
        };

        private static readonly object[] TestData_ConditionsMeet_False_Line =
        {
            new object[] {6, 9, 3 },
            new object[] {6, 0, 0 },
            new object[] {33, 20, 11},
        };

        private static readonly object[] TestData_Area_Valid =
        {
            new object[] {6, 9, 5, 14.14 },
            new object[] {4, 3, 6, 5.33 },
            new object[] {14, 22, 17, 119 }
        };

        private static readonly object[] TestData_Area_InValid =
        {
            new object[] {30, 14, 15},
            new object[] {1, 3, 8},
            new object[] {0, 9, 5 },
            new object[] {7, -3, 8 },
            new object[] {12, -7, -11 },
        };

        // Tests

        // Conditions Test

        [Test, TestCaseSource(nameof(TestData_ConditionsMeet_True))]
        public void AreExistingConditionsMeet_Should_Return_True_Test(Point legA, Point legB, Point legC, bool expected)
        {
            Triangle testTriangle = new Triangle(legA, legB, legC);
            bool expectedResult = expected;
            bool actual = testTriangle.CheckConditions();
            Assert.AreEqual(expectedResult, actual);
        }

        [Test, TestCaseSource(nameof(TestData_ConditionsMeet_False))]
        public void AreExistingConditionsMeet_Should_Return_False_Test(Point legA, Point legB, Point legC)
        {
            Assert.Throws<Exception>(() => new Triangle(legA, legB, legC).AreExistingConditionsMeet());
        }

        [Test, TestCaseSource(nameof(TestData_ConditionsMeet_True_Line))]
        public void CheckConditions_Should_Return_True_Test(double legA, double legB, double legC, bool result)
        {
            Triangle testTriangle = new Triangle(legA, legB, legC);
            bool expectedResult = result;
            bool actual = testTriangle.CheckConditions();
            Assert.AreEqual(expectedResult, actual);
        }

        [Test, TestCaseSource(nameof(TestData_ConditionsMeet_False_Line))]
        public void CheckConditions_Sould_Return_False_Test(double legA, double legB, double legC)
        {
            Assert.Throws<Exception>(() => new Triangle(legA, legB, legC).CheckConditions());
        }

        // Perimetr Test

        [Test]
        [TestCase(6, 9, 5, ExpectedResult = 20)]
        [TestCase(4, 3, 6, ExpectedResult = 13)]
        public double PerimetrFunction_Positive_Test(double legA, double legB, double legC)
        {
            Triangle testTriangle = new Triangle(legA, legB, legC);
            double actual = testTriangle.GetPerimetr();
            return actual;
        }

        [Test]
        [TestCase(0, 0, 0)]
        [TestCase(0, 9, 5)]
        [TestCase(5, 9, 4)]
        [TestCase(-3, 2, 2)]
        [TestCase(-5, -4, -7)]
        public void PerimetrFunction_Negative_Test(double legA, double legB, double legC)
        {
            Assert.Throws<Exception>(() => new Triangle(legA, legB, legC).GetPerimetr());
        }

        //Area Test Versatile

        [Test, TestCaseSource(nameof(TestData_Area_Valid))]
        public void AreaFunction_For_Versatile_Triangle_Positive_Test(double legA, double legB, double legC, double expected)
        {
            Triangle testTriangle = new Triangle(legA, legB, legC);
            Assert.AreEqual(expected, testTriangle.GetArea());
        }

        [Test, TestCaseSource(nameof(TestData_Area_InValid))]
        public void AreaFunction_For_Versatile_Triangle_Negative_Test(double legA, double legB, double legC)
        {
            Assert.Throws<Exception>(() => new Triangle(legA, legB, legC).GetArea());
        }

        //Area Test RightAngled

        [Test]
        [TestCase(6, 9, ExpectedResult = 27)]
        [TestCase(4, 3, ExpectedResult = 6)]
        public double AreaFunction_For_RightAngled_Triangle_Positive_Test(double legA, double legB)
        {
            RightAngled testRightAngled = new RightAngled(legA,legB);
            return testRightAngled.GetArea();
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 9)]
        [TestCase(7, -3)]
        public void AreaFunction_For_RightAngled_Triangle_Negative_Test(double legA, double legB)
        {
            Assert.Throws<Exception>(() => new RightAngled(legA, legB).GetArea());
        }

        //Area Test Isosceles

        [Test]
        [TestCase(6, 9, ExpectedResult = 17.86)]
        [TestCase(4, 3, ExpectedResult = 5.56)]
        public double AreaFunction_For_Isosceles_Triangle_Positive_Test(double legA, double legB)
        {
            Isosceles testIsosceles = new Isosceles(legA, legB);
            return testIsosceles.GetArea();
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(0, 9)]
        [TestCase(7, -3)]
        public void AreaFunction_For_Isosceles_Triangle_Negative_Test(double legA, double legB)
        {
            Assert.Throws<Exception>(() => new Isosceles(legA, legB).GetArea());
        }

        //Area Test IsoscelesRightAngle

        [Test]
        [TestCase(1, ExpectedResult = 0.5)]
        [TestCase(9, ExpectedResult = 40.5)]
        [TestCase(13, ExpectedResult = 84.5)]
        public double AreaFunction_For_IsoscelesRightAngle_Triangle_Positive_Test(double legA)
        {
            IsoscelesRightAngle testIsoscelesR = new IsoscelesRightAngle(legA);
            return testIsoscelesR.GetArea();
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void AreaFunction_For_IsoscelesRightAngle_Triangle_Negative_Test(double legA)
        {
            Assert.Throws<Exception>(() => new IsoscelesRightAngle(legA).GetArea());
        }
    }
}
