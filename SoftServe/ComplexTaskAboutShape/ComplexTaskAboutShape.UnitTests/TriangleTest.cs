using System;
using NUnit.Framework;
using NSubstitute;

namespace ComplexTaskAboutShape.UnitTests
{
    [TestFixture]
    public class TriangleTest
    {
        [Test]
        public void Perimetr_GetPerimetr_Calculate()
        {
            Triangle triangle = new Triangle(new Point(-1, -1), new Point(-1, -4), new Point(-5, -1));

            var actual = triangle.GetPerimetr();
            var expected = 12;

            Assert.AreEqual(expected, actual, "Test fails");
        }

        [Test]
        public void Area_GetArea_Calculate()
        {
            Triangle triangle = new Triangle(new Point(-1, -1), new Point(-1, -4), new Point(-5, -1));

            var actual = triangle.GetArea();
            var expected = 6;

            Assert.AreEqual(expected, actual, "Test fails");
        }

        [Test]
        public void Triangle_CannotInitializeObject_ThrowException()
        {
            Assert.Throws<ArgumentException>(delegate { new Triangle(new Point(-1, -1), new Point(-1, -1), new Point(-5, -1)); });
        }
    }
}
