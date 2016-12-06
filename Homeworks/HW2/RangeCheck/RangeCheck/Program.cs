using System;

namespace RangeCheck
{
    class Program
    {
	///<summary>
	///	Read 3 float numbers and check: are they all belong to the range [-5,5].
	///</summary>
        static void Main(string[] args)
        {
            double a, b, c;
            Console.WriteLine("Input 3 float numbers:");
            a = Convert.ToSingle(Console.ReadLine());
            b = Convert.ToSingle(Console.ReadLine());
            c = Convert.ToSingle(Console.ReadLine());
            bool answer = ((a <= 5) && (a >= -5)) && ((b <= 5) && (b >= -5)) && ((c <= 5) && (c >= -5));
            Console.WriteLine("All number belong to the range [-5;5]: {0}", answer);
            Console.ReadLine();
        }
    }
}
