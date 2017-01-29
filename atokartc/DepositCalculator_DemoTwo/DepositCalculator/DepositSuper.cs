using System;
using static DepositCalculator.ConstantValues;

namespace DepositCalculator
{
    /// <summary>
    /// DepositSuper class reproduces calculation logic for specific deposit named super. 
    /// </summary>
    public class DepositSuper : Deposit
    {
        private string name = "DepositSuper";
        private int maxInvestmentTerm;

        public DepositSuper(int maxInvestmentTerm)
        {
            this.maxInvestmentTerm = maxInvestmentTerm;
        }

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

        #region Methods
        public override bool ValidatePeriod(int investmentTerm)
        {
            return investmentTerm > 0 && investmentTerm <= this.MaxInvestmentTerm;
        }

        public override double GetDepositRate(int investmentTerm)
        {
            double rate = 0;

            if (investmentTerm > 0 && investmentTerm <= superFirstTermMax)
            {
                rate = mintPeriodRateSuper;
            }
            else if (investmentTerm > superFirstTermMax && 
                investmentTerm <= superSecondTermMax)
            {
                rate = averageRateSuper;
            }
            else if (investmentTerm > superSecondTermMax && 
                investmentTerm <= this.MaxInvestmentTerm)
            {
                rate = maxPeriodRateSuper;
            }

            return rate;
        }

        public double AddBonusToDeposit(double depositAmount, double personalBonusRate)
        {
            return depositAmount = depositAmount * personalBonusRate / 100;
        }
        /// <summary>
        /// Method allows to calculate Total interest with personal bonus.
        /// </summary>
        /// <param name="depositAmount"></param>
        /// <param name="investmentTerm"></param>
        /// <param name="personalBonusRate"></param>
        /// <returns></returns>
        public double CalculateTotalInterestBonus(double depositAmount, 
            int investmentTerm, double personalBonusRate)
        {
            double totalInterest = 0;

            if (this.ValidatePeriod(investmentTerm))
            {
                double rate = this.GetDepositRate(investmentTerm);

                totalInterest = depositAmount + depositAmount * rate / 100 +
                    AddBonusToDeposit(depositAmount, personalBonusRate);
            }

            return totalInterest;
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


