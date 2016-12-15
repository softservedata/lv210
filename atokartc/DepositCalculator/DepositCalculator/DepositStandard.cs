using static DepositCalculator.ConstantValues;
using System;

namespace DepositCalculator
{
    /// <summary>
    /// DepositStandard class reproduces calculation logic for specific deposit named standard. 
    /// </summary>
    public class DepositStandard : Deposit
    {
        private string name = "DepositStandard";
        private int maxInvestmentTerm;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public override int MaxInvestmentTerm
        {
            get { return this.maxInvestmentTerm; }
        }

        public DepositStandard() { }

        public DepositStandard(int maxInvestmentTerm)
        {
            this.maxInvestmentTerm = maxInvestmentTerm;
        }

        #region Methods
        public override bool ValidatePeriod(int investmentTerm)
        {
            return investmentTerm > 0 && investmentTerm <= this.MaxInvestmentTerm;
        }

        public override double GetDepositRate(int investmentTerm)
        {
            double rate = 0;

            if (investmentTerm > 0 && investmentTerm <= standardFirstTermMax)
            {
                rate = mintPeriodRateStandard;
            }
            else if (investmentTerm > standardFirstTermMax && investmentTerm <= standardSecondTermMax)
            {
                rate = averageRateStandard;
            }
            else if (investmentTerm > standardSecondTermMax && investmentTerm <= this.MaxInvestmentTerm)
            {
                rate = maxPeriodRateStandard;
            }

            return rate;
        }

        public override double CalculateTotalInterest(double depositAmount, int investmentTerm)
        {
            double totalInterest = 0;

            if (this.ValidatePeriod(investmentTerm))
            {
                double rate = this.GetDepositRate(investmentTerm);

                totalInterest = depositAmount + depositAmount * rate / 100;
            }

            return totalInterest;
        }
        #endregion
    }
}
