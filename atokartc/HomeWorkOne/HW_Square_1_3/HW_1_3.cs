using System;

namespace HomeWorkOne
{
    /// <summary>
    /// Create Console Application project in VS.
    /// In method Main() write code for solving next tasks:
    /// define integer variable a.Read the value of a from console and calculate area and perimetr of square with length a. 
    /// Output obtained results.
    /// </summary>
    public class HW_1_3
    {
        public static int GetPositiveValueFromConsole()
        {
            int readedVar = 0;
            bool isIntEntered = Int32.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered && readedVar >= 0)
            {
                return readedVar;
            }
            else
            {
                Console.WriteLine("Please, enter a positive integer");
                return GetPositiveValueFromConsole();
            }
        }

        public static void Main()
        {
            Console.WriteLine("Define a integer variable: ");
            int a = GetPositiveValueFromConsole();
            double area = Math.Pow(a, 2);
            double perimeter = 4 * a;

            Console.WriteLine("Area of Square is:{0}", area);
            Console.WriteLine("Perimeter of Square is:{0}", perimeter);
            Console.ReadKey();
        }
    }
}
