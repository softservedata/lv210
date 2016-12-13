using HomeWorkThree;
using NUnit.Framework;

namespace HomeWorkThree.Test
{
    [TestFixture]
    public class IsIntEnteredIntInRangeMonthTest
    {
        [Test]
        public void PositiveValTest()
        {
            bool expected;
            bool actual;

            actual = HW_3_2.IsIntEnteredIntInRangeMonth(6);
            expected = true;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NegativeValTest()
        {
            bool expected;
            bool actual;

            actual = HW_3_2.IsIntEnteredIntInRangeMonth(15);
            expected = false;

            Assert.AreEqual(expected, actual);
        }

        [Test, Sequential]
        public void BoundaryValueValidTest([Values(0, 1, 12, 13)] int values, [Values(false, true, true, false)] bool result)
        {
            bool expected;
            bool actual;

            actual = HW_3_2.IsIntEnteredIntInRangeMonth(values);
            expected = result;

            Assert.AreEqual(expected, actual);
        }

        [Test, Sequential]
        public void EquivalenceClassesTest([Values(-1, 5, 22),] int values, [Values(false, true, false)] bool result)
        {
            bool expected;
            bool actual;

            actual = HW_3_2.IsIntEnteredIntInRangeMonth(values);
            expected = result;

            Assert.AreEqual(expected, actual);
        }


    }
}
