using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositCalculator
{
    /// <summary>
    /// Class reproduces constant values that are used in the application
    /// </summary>
    public class ConstantValues
    {
        #region Invest terms in monthes for deposits 
        public const int standardFirstTermMax = 3;
        public const int standardSecondTermMax = 9;
        public const int superFirstTermMax = 3;
        public const int superSecondTermMax = 6;
        #endregion
        #region Rates for Super deposit
        public const int mintPeriodRateSuper = 22;
        public const int averageRateSuper = 23;
        public const int maxPeriodRateSuper = 24;
        #endregion
        #region Rates for Super deposit
        public const int mintPeriodRateStandard = 18;
        public const int averageRateStandard = 19;
        public const int maxPeriodRateStandard = 20;
        #endregion
    }
}
