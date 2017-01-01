using System;

namespace HW2
{
    class Program
    {
        void NumbersInRange()
        {
            float a1, a2, a3;
            Console.Write("Enter numer 1: ");
            a1 = float.Parse(Console.ReadLine());
            Console.Write("Enter numer 2: ");
            a2 = float.Parse(Console.ReadLine());
            Console.Write("Enter numer 3: ");
            a3 = float.Parse(Console.ReadLine());
            Console.WriteLine();
            String answer = ((a1 >= -5) && (a1 <= 5)) && ((a2 >= -5) && (a2 <= 5)) && ((a3 >= -5) && (a3 <= 5)) ? "All number are between -5 and 5" : "Some number is not between -5 and 5";
            Console.WriteLine(answer);
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Program prog = new Program();
            prog.NumbersInRange();
        }
    }
}
