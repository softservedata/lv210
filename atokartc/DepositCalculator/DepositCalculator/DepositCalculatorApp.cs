using System;

namespace DepositCalculator
{
    public class DepositCalculatorApp
    {
        public static void Main()
        {
            DepositStandard Deposit = new DepositStandard(12);
            Console.WriteLine(Deposit.ValidatePeriod(11));
            Console.WriteLine(Deposit.GetDepositRate(5));
            Console.WriteLine(Deposit.CalculateTotalInterest(1000.00, 3));

            DepositSuper DepositTwo = new DepositSuper(13);
            Console.WriteLine(DepositTwo.ValidatePeriod(11));
            Console.WriteLine(DepositTwo.GetDepositRate(5));
            Console.WriteLine(DepositTwo.CalculateTotalInterest(2000.00, 4));
            Console.WriteLine(DepositTwo.AddBonusToDeposit(2000.00, 10));
            Console.WriteLine(DepositTwo.CalculateTotalInterestBonus(2000.00, 4, 10));

            Console.Read();
        }
    }
}
