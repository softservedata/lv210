using System;

namespace HW1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Сalculate area and perimetr of square with length a
            Console.WriteLine("Enter the length of the square: ");
            String a_s = Console.ReadLine();
            int a = Convert.ToInt32(a_s);
            Console.WriteLine("Area of square = {0}", a * a);
            Console.WriteLine("Perimeter of square = {0}", 4 * a);
            Console.ReadKey();

            //Define string variable name and integer value age
            Console.WriteLine("What is your name? ");
            string name = Console.ReadLine();
            Console.WriteLine("How old are you? ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Yor are {0} and you are {1} years old.", name, age);
            Console.ReadKey();
        }
    }
}
