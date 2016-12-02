using System;

namespace AppropriateFunction
{
    public class Functions
    {
        public static bool IsInRange(float x, float a, float b)
        {
            return (x >= a && x <= b) ? true : false;
        }

        public static bool logical_conjunction(bool a, bool b, bool c)
        {
            return a && b && c;
        }

        public static void VerifyNumbers()
        {
            Console.WriteLine("Enter three float numbers:");

            var input_x1 = Console.ReadLine();
            var input_x2 = Console.ReadLine();
            var input_x3 = Console.ReadLine();

            float x1, x2, x3;

            var isInputX1Valid = float.TryParse(input_x1, out x1);
            var isInputX2Valid = float.TryParse(input_x2, out x2);
            var isInputX3Valid = float.TryParse(input_x3, out x3);

            if (isInputX1Valid && isInputX2Valid && isInputX3Valid)
            {
                Console.WriteLine("\nAll these numbers are from the interval [-5,5] - {0} ", logical_conjunction(IsInRange(x1, -5, 5), IsInRange(x2, -5, 5), IsInRange(x3, -5, 5)));
            }
            else
            {
                Console.WriteLine("Incorrect value!\n");
            }

            Console.ReadLine();

           
        }
    }
}