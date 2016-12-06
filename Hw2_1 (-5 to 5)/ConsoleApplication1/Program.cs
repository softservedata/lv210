using System;

namespace HW2
{
    class Program
    {
        static void Main(string[] args)
        {
           // Read 3 float numbers and check: are they all belong to the range[-5, 5]
            float a1, a2, a3;
            Console.Write("Enter numer 1: ");
            a1 = float.Parse(Console.ReadLine());
            Console.Write("Enter numer 2: ");
            a2 = float.Parse(Console.ReadLine());
            Console.Write("Enter numer 3: ");
            a3 = float.Parse(Console.ReadLine());
            Console.WriteLine();
            String answer = ((a1 >= -5) && (a1 <= 5)) && ((a2 >= -5) && (a2 <= 5)) && ((a3 >= -5) && (a3 <= 5) )? "All number are between -5 and 5" : "Some number is not between -5 and 5";
            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
