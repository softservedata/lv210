using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_daysOfMonth
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Is it a leap year?");
            string answer = Console.ReadLine();
            Console.WriteLine("Enter month number ");
            int monthNumber=Convert.ToInt32(Console.ReadLine());
            int daysCount=0;

            if (answer == "Y" || answer == "y") 
            { 
                switch(monthNumber)
                {
                  case 1: case 3: case 5:  case 7:  case 8: case 10:  case 12: 
                      daysCount=31;
                      break;
                  case 4:  case 6: case 9: case 11: 
                      daysCount=30;
                      break;
                  case 2: 
                      daysCount = 29; 
                      break;
                }
           } 
            else {
                switch (monthNumber)
                {
                    case 1:
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12:
                        daysCount = 31;
                        break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:
                        daysCount = 30;
                        break;
                    case 2:
                        daysCount = 28;
                        break;
                }
            }
            Console.WriteLine("Month {0} has {1} days", monthNumber, daysCount);
            Console.ReadKey();
        }
    }
}
