using System;
using System.Linq;

namespace MaxMin
{
    class Program
    {
		///<summary>
		///	Read 3 integres and write max and min of them.
		///</summary>
        static void Main(string[] args)
        {
            Console.Write("Input 3 integer numbers: ");
            int[] Variables;
            int ParsedValues;
            Variables = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select
                                                    (i => int.TryParse(i, out ParsedValues) ? ParsedValues : 0).ToArray();
            int min = Variables.Min();
            int max = Variables.Max();

            Console.WriteLine("Max = {0}\nMin = {1}", max, min);
            Console.ReadLine();
        }
    }
}
