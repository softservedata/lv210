
using NUnit.Framework;

[TestFixture]
class FloatNumbersTest
{
    [Test]
    [TestCase(new float[] { 1.0f, 2.4f, 3.5f, 4.0f }, 0.0f, 5.4f)]
    public void IsInRangeTest(float[] array, float leftBound, float rightBound)
    {

        bool actual = FloatNumbers.IsInRange(array, leftBound, rightBound);
        Assert.IsTrue(actual);
    }

    [TestCase(new float[] { 1.0f, 2.4f, 3.5f, 4.0f }, 5.0f, 6.0f)]
    [TestCase(new float[] { 1.0f, 2.4f, 3.5f, 4.0f }, 0.0f, 3.0f)]
    [TestCase(new float[] { 1.0f, 2.4f, 3.5f, 4.0f }, 3.0f, 6.0f)]
    public void IsInRangeNegativeTest(float[] array, float leftBound, float rightBound)
    {
        bool actual = FloatNumbers.IsInRange(array, leftBound, rightBound);
        Assert.IsFalse(actual);
    }

    [TestCase(new float[] {}, 3.0f, 6.0f)]
    public void IsInRangeEmptyValueTest(float[] array, float leftBound, float rightBound)
    {
        bool actual = FloatNumbers.IsInRange(array, leftBound, rightBound);
        Assert.IsFalse(actual);
    }

    [Test]
    [TestCase(new float[] { 1.0f, 2.4f, 3.5f, 4.0f }, 6.4f, 5.4f)]
    public void IsInRangeIllegalBoundsTest(float[] array, float leftBound, float rightBound)
    {
        bool actual = FloatNumbers.IsInRange(array, leftBound, rightBound);
        Assert.IsFalse(actual);
    }
   
}
