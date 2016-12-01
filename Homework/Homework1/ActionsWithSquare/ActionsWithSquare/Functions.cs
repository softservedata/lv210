using System;

namespace AppropriateFunctios
{
    public class Functions
    {
        public static int Square(int a)
        {
            return a * a;
        }

        public static int Perimeter(int a)
        {
            return 4 * a;
        }

        public static void CalcSquareParametrs()
        {
            Console.WriteLine("Please, enter side length of square:");
            Console.Write("a = ");

            var input = Console.ReadLine();
            int size;

            var isInputValid = int.TryParse(input, out size);
            var isSizeValid = size > 0;

            if (isInputValid && isSizeValid)
            {
                var square = Square(size);

                var perimeter = Perimeter(size);
            
                Console.WriteLine("\nArea = {0}", square);
                Console.WriteLine("Periment = {0}\n", perimeter);

            }
            else
            {
                Console.WriteLine("Incorrect value!\n");
            }

            Console.ReadLine();
        }
    }
}