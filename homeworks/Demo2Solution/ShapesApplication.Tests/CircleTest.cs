using System;
using NUnit.Framework;


namespace ShapesApplication.Tests
{
    [TestFixture]
    public class CircleTest
    {
        [TestCase(-1)]
        [TestCase(0)]
        public void CanDrawWithInvalidRadiusTest(double radius)
        {
            var circle = new Circle(new Point2D(0, 0), radius);
            Assert.Throws<ArgumentException>(() => circle.CanDraw());
        }

        [Test]
        public void CanDrawWithInvalidCenterTest()
        {
            var circle = new Circle(null, 1.0);
            Assert.Throws<ArgumentException>(() => circle.CanDraw());
        }

        [TestCase(0.1, 1.0, 0.1)]
        [TestCase(0.2, 1.5, 10.0)]
        public void CanDrawWithValidDataTest(double x, double y, double radius)
        {
            var circle = new Circle(new Point2D(x, y), radius);
            bool actual = circle.CanDraw();
            Assert.IsTrue(actual);
        }

        [TestCase(0.0)]
        [TestCase(10.0)]
s void CalculatePerimeterTest(double radius)
        {
            var circle = new Circle(new Point2D(1.0, 2.0), radius);
            double expected = Math.PI*circle.Radius*2;
            double actual = circle.CalculatePerimeter();
            double precision = 0.0000001;
            Assert.AreEqual(expected, actual, precision);
        }

        [TestCase(0.0)]
        [TestCase(10.0)]
        public void CalculateAreaTest(double radius)
        {
            var circle = new Circle(new Point2D(1.0, 2.0), radius);
            double expected = Math.PI*(Math.Pow(circle.Radius, 2.0));
            double actual = circle.CalculateArea();
            double precision = 0.0000001;
            Assert.AreEqual(expected, actual, precision);
        }

        /// <summary>
        /// Check if circle has right color.
        /// </summary>
        /// <param name="color"></param>
        [TestCase(Color.Black)]
        [TestCase(Color.White)]
        [TestCase(Color.Blue)]
        public void ColorTest(Color color)
        {
            var circle = new Circle(new Point2D(0, 0), 1, color);
            Color actual = circle.Color;
            Color expected = color;
            Assert.AreEqual(expected, actual);
        }
    }
}




