using NUnit.Framework;

namespace HomeWorkThree.Test
{
    [TestFixture]
    public class IsIntEnteredIntInRangeMonthTest
    {
        [Test]
        public void PositiveValueEnteredTest()
        {
            bool actual = HW_3_2.IsMonthEntered(6);

            Assert.IsTrue(actual);
        }

        [Test]
        public void NegativeValueEnteredTest()
        {
            bool actual = HW_3_2.IsMonthEntered(15);

            Assert.IsTrue(!actual);
        }

        [Test, Sequential]
        public void BoundaryValueValidTest([Values(0, 1, 12, 13)] int values, [Values(false, true, true, false)] bool result)
        {
            bool expected;
            bool actual;

            actual = HW_3_2.IsMonthEntered(values);
            expected = result;

            Assert.AreEqual(expected, actual);
        }

        [Test, Sequential]
        public void EquivalenceClassesTest([Values(-1, 5, 22),] int values, [Values(false, true, false)] bool result)
        {
            bool expected;
            bool actual;

            actual = HW_3_2.IsMonthEntered(values);
            expected = result;

            Assert.AreEqual(expected, actual);
        }
    }
}
