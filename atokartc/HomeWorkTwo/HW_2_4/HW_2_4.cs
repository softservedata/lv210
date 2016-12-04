using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkTwo
{
    /// <summary>
    /// Practical task:
    /// Create Console Application project in VS.
    /// In method Main() write code for solving next task:
    /// read 3 float numbers and check: are they all belong to the range [-5,5].
    /// </summary>
    public class HW_2_4
    {
        public static void Main()
        {
            Console.WriteLine("Enter three float numbers");

            float one = Convert.ToSingle(Console.ReadLine());
            float two = Convert.ToSingle(Console.ReadLine());
            float three = Convert.ToSingle(Console.ReadLine());

            if (one >= -5 && one <= 5)
            {
                if (two >= -5 && two <= 5)
                {
                    if (three >= -5 && three <= 5)
                    {
                        Console.WriteLine("All three numbers are in the range of [-5;5]");
                    }
                }
            }
            else
            {
                Console.WriteLine("One of the numbers are in the range of [-5;5]");
            }
            Console.ReadKey();
        }
    }
}
