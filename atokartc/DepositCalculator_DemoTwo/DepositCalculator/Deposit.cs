using System;

namespace DepositCalculator
{
    /// <summary>
    /// Abstract class Deposit reproduces apps methods that are implemented in subclasses.
    /// </summary>
    public abstract class Deposit
    {
        public abstract int MaxInvestmentTerm { get; }
        #region Methods
        public abstract double CalculateTotalInterest(double depositAmount, int investmentTerm);
        public abstract double GetDepositRate(int investmentTerm);
        public abstract bool ValidatePeriod(int investmentTerm);
        # endregion
    }

}
