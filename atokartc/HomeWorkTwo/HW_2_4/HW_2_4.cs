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

            float one;
            float two;
            float three;

            if (float.TryParse(Console.ReadLine(), out one) && float.TryParse(Console.ReadLine(), out two) &&
                float.TryParse(Console.ReadLine(), out three))
            {
                float[] oneTwoThree = { one, two, three };
                bool check = true;

                for (int i = 0; i < oneTwoThree.Length; i++)
                {
                    if (oneTwoThree[i] < -5 || oneTwoThree[i] > 5)
                    {
                        check = false;
                        Console.WriteLine("Number # {0} are not in the range of [-5;5]", oneTwoThree[i]);
                    }
                }

                if (check)
                {
                    Console.WriteLine("All three numbers are in the range of [-5;5]");
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Please enter floats!");
                Main();
            }
        }
    }
}
        
