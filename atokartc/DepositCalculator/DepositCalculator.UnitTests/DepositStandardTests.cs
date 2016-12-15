using NUnit.Framework;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

namespace DepositCalculator.UnitTests
{
    /// <summary>
    /// TestMethod_ConditionAndER
    /// </summary>
    [TestFixture]
    public class DepositStandardTests
    {
        private int twelveMonth = 12;

        /// <summary>
        /// Positive boundary values analysis for ValidatePeriod() method.
        /// </summary>
        /// <param name="investTerm"></param>
        [TestCase(1)]
        [TestCase(11)]
        [TestCase(12)]
        public void ValidatePeriodTest_PositiveBoundaryValues_TrueIfValid(int investTerm)
        {
            DepositStandard standard = new DepositStandard(12);

            bool expected = true;
            bool actual = standard.ValidatePeriod(investTerm);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Negative boundary values analysis for ValidatePeriod() method.
        /// </summary>
        /// <param name="investTerm"></param>
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(13)]
        public void ValidatePeriodTest_NegativeBoundaryValues_FalseIfValid(int investTerm)
        {
            DepositStandard standard = new DepositStandard(12);

            bool expected = false;
            bool actual = standard.ValidatePeriod(investTerm);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Equivaence partitioning analysis for ValidatePeriod() method.
        /// </summary>
        /// <param name="investTerm"></param>
        /// <param name="result"></param>
        [Sequential]
        public void ValidatePeriodTest_EquivalencePartitioning_TrueIfValidFalseIfInvalid
            ([Values(-5, 6, 55)] int investTerm, [Values(false, true, false)] bool result)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            bool expected = result;
            bool actual = standard.ValidatePeriod(investTerm);

            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Positive boundary values analysis for GetDepositRateTest() method. For month 1-3.
        /// </summary>
        /// <param name="investTerm"></param>
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void GetDepositRateTest_PositiveBoundaryValuesOneToThreeMonth_ReturnCorrectRate(int investTerm)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            double expected = 18;
            double actual = standard.GetDepositRate(investTerm);

            Assert.AreEqual(expected, actual, 0.00001);
        }

        /// <summary>
        /// Positive boundary values analysis for GetDepositRateTest() method. For month 4-9.
        /// </summary>
        /// <param name="investTerm"></param>
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(8)]
        [TestCase(9)]
        public void GetDepositRateTest_PositiveBoundaryValuesFourToNineMonth_ReturnCorrectRate(int investTerm)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            double expected = 19;
            double actual = standard.GetDepositRate(investTerm);

            Assert.AreEqual(expected, actual, 0.00001);
        }

        /// <summary>
        /// Positive boundary values analysis for GetDepositRateTest() method. For month 10-12.
        /// </summary>
        /// <param name="investTerm"></param>
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        public void GetDepositRateTest_PositiveBoundaryValuesNineToTwelveMonth_ReturnCorrectRate(int investTerm)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            double expected = 20;
            double actual = standard.GetDepositRate(investTerm);

            Assert.AreEqual(expected, actual, 0.0001);
        }

        /// <summary>
        /// Negative boundary values analysis for GetDepositRateTest() method. 
        /// If we get 0 or - program should return 0;
        /// </summary>
        /// <param name="investTerm"></param>
        [TestCase(0)]
        [TestCase(13)]
        public void GetDepositRateTest_NegativeBoundaryValues_ReturnZero(int investTerm)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            double expected = 0;
            double actual = standard.GetDepositRate(investTerm);

            Assert.AreEqual(expected, actual, 0.00001);
        }

        /// <summary>
        /// Equivaence partitioning analysis for GetDepositRateTest() method.
        /// </summary>
        /// <param name="investTerm"></param>
        /// <param name="result"></param>
        [Sequential]
        public void GetDepositRateTest_EquivalencePartion_ReturnCorrectRate
            ([Values(-1, 2, 5, 11, 55)] int investTerm,
            [Values(0, 18, 19, 20, 0)] double result)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            double expected = result;
            double actual = standard.GetDepositRate(investTerm);

            Assert.AreEqual(expected, actual, 0.00001);
        }

        /// <summary>
        /// CalculateTotalInterest positive scenario testing
        /// </summary>
        /// <param name="depositAmount"></param>
        [TestCase(1000)]
        public void CalculateTotalInterestTest_PositiveScenarioTest_ReturnCorrectDoubleResult
            (double depositAmount)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            Deposit deposit = Substitute.For<Deposit>();
            deposit.ValidatePeriod(3).Returns(true);
            deposit.GetDepositRate(3).Returns(18);

            double expected = 1200;
            double actual = standard.CalculateTotalInterest(depositAmount, twelveMonth);

            Assert.AreEqual(expected, actual, 0.00001);
        }

        /// <summary>
        /// CalculateTotalInterest positive scenario testing
        /// </summary>
        /// <param name="depositAmount"></param>
        [TestCase(-1)]
        public void CalculateTotalInterestTest_NegativeScenarioTest_ReturnCorrectDoubleResult
            (double depositAmount)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            Deposit deposit = Substitute.For<Deposit>();
            deposit.ValidatePeriod(3).Returns(true);
            deposit.GetDepositRate(3).Returns(18);

            double expected = 1200;
            double actual = standard.CalculateTotalInterest(depositAmount, twelveMonth);

            Assert.AreEqual(expected, actual, 0.00001);
        }

        /// <summary>
        /// CalculateTotalInterest testing scenario with invalid type entered.
        /// </summary>
        /// <param name="depositAmount"></param>
        [TestCase("1231231")]
        public void CalculateTotalInterestTest_ValueWithInvalidTypeEntered_ReturnCorrectDoubleResult
            (double depositAmount)
        {
            DepositStandard standard = new DepositStandard(twelveMonth);

            Deposit deposit = Substitute.For<Deposit>();
            deposit.ValidatePeriod(3).Returns(true);
            deposit.GetDepositRate(3).Returns(18);

            Assert.Throws<System.ArgumentException>(() => standard.CalculateTotalInterest(depositAmount, twelveMonth));
        }
    }
}
