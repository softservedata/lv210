using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVG
{
    /// <summary>
    /// Task
    /// Введіть послідовність додатніх цілих чисел (до першого від’ємного). 
    /// Обчисліть середнє арифметичне значення введених чисел
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Declaration and initialization of variables
            int a, sum = 0, n = 0;

            //Declare 'for' loop
            for (;;)
            {
                Console.Write("Enter the number: ");

                //Reading variable and conver it to Int32 type
                a = Int32.Parse(Console.ReadLine());

                //Condition
                if (a > 0)
                {
                    sum += a;
                    n++;
                }
                //Condition fail
                else
                    break;
            }
            //Output results
            double avg = (double)sum / n;
            Console.WriteLine("------------------------------------");
            Console.WriteLine("AVG of the entered values is {0:F2}", avg);
        }
    }
}
