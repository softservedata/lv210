using NUnit.Framework;

namespace RadiusOperation.Test
{
    [TestFixture]
    public class RadiusOperationTest
    {
        [Test]
        [TestCase(3, 18.8495)]
        public void Circle_Length_Test(double radius, double result)
        {
            double Precision = 0.0001;
            double ExpectedResult = result;
            Circle TestCircle = new Circle(radius);
            double ActualResult = TestCircle.CircleLength();
            Assert.AreEqual(ExpectedResult, ActualResult, Precision);
        }
        [TestCase(3, 28.2743)]
        public void Circle_Area_Test(double radius, double result)
        {
            double Precision = 0.0001;
            double ExpectedResult = result;
            Circle TestCircle = new Circle(radius);
            double ActualResult = TestCircle.CircleArea();
            Assert.AreEqual(ExpectedResult, ActualResult, Precision);
        }
        [TestCase(3, 84.823)]
        public void Sphere_Volume_Test(double radius, double result)
        {
            double Precision = 0.0001;
            double ExpectedResult = result;
            Sphere TestSphere = new Sphere(radius);
            double ActualResult = TestSphere.SphereVolume();
            Assert.AreEqual(ExpectedResult, ActualResult, Precision);
        }
    }
}
