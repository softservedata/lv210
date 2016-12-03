using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaysCount
{
    /*
     * This program shows user the count of days in appropriate month.
     */
    using MonthStructure;
    class Program
    {
        
        static void Main(string[] args)
        {

            StructureAndFunctions.Month[] allMonths = new StructureAndFunctions.Month[12];

            StructureAndFunctions.InitializeStructure(allMonths);

            Console.WriteLine("Please, enter number of month:");

            var input = Console.ReadLine();

            int number;

            bool isInputValid = int.TryParse(input, out number);
            bool isNumberValid = (number > 0 && number < 13);

            if (isInputValid && isNumberValid)
            {
                StructureAndFunctions.Month currentMonth = StructureAndFunctions.GetMonth(allMonths, number);
                Console.WriteLine("\n{0}-th month ({1}) has {2} days.", number, currentMonth.Name, currentMonth.days_number);

            }
            else
            {
                Console.WriteLine("\nIncorrect value!");
            }

            Console.ReadLine();
        }
    }
}
