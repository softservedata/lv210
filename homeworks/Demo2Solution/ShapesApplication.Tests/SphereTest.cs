using System;
using NUnit.Framework;

namespace ShapesApplication.Tests

{
    [TestFixture]
    public class SphereTest
    {
        /// <summary>
        /// Check if exception is thrown, when calling draw method with invalid radius.
        /// </summary>
        /// <param name="radius"></param>
        [TestCase(-1)]
        [TestCase(0)]
        public void DrawWithInvalidRadiusTest(double radius)
        {
            var sphere = new Sphere(new Point3D(0, 0, 0), radius);
            Assert.Throws<ArgumentException>(() => sphere.Draw());
        }

        /// <summary>
        /// Check if exceptin is thrown, when calling draw method with null value.
        /// </summary>
        [Test]
        public void DrawWithInvalidCenterTest()
        {
            var sphere = new Sphere(null, 1.0);
            Assert.Throws<ArgumentException>(() => sphere.Draw());
        }

        [TestCase(0.1, 1.0, 0.8, 0.1)]
        [TestCase(0.1, 1.0, 0.8, 10.0)]
        public void DrawWithValidDataTest(double x, double y, double z, double radius)
        {
            var expected = new Sphere(new Point3D(x, y, z), radius);
            IShape actual = expected.Draw();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check sphere volume calculated by method. 
        /// </summary>
        /// <param name="radius"></param>
        [TestCase(0.1)]
        [TestCase(10.0)]
        public void CalculateVolumeTest(double radius)
        {
            var sphere = new Sphere(new Point3D(0, 0, 0), radius);
            double actual = sphere.CalculateVolume();
            double expected = 4*Math.PI*Math.Pow(sphere.Radius, 3.0);
            double precision = 0.0000001;
            Assert.AreEqual(expected, actual, precision);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Check sphere area calculated by method.
        /// </summary>
        /// <param name="radius"></param>
        [TestCase(0.0)]
        [TestCase(0.1)]
        [TestCase(10.0)]
        public void CalculateAreaTest(double radius)
        {
            var sphere = new Sphere(new Point3D(0, 0, 0), radius);
            double actual = sphere.CalculateArea();
            double expected = 4*Math.PI*Math.Pow(sphere.Radius, 2.0);
            Assert.AreEqual(expected, actual);
            double precision = 0.0000001;
            Assert.AreEqual(expected, actual, precision);
        }

        /// <summary>
        /// Check if sphere has right color.
        /// </summary>
        /// <param name="color"></param>
        [TestCase(Color.Black)]
        [TestCase(Color.White)]
        [TestCase(Color.Blue)]
        public void ColorTest(Color color)
        {
            var sphere = new Sphere(new Point3D(0, 0, 0), 1, color);
            Color actual = sphere.Color;
            Color expected = color;
            Assert.AreEqual(expected, actual);
        }
    }
}



