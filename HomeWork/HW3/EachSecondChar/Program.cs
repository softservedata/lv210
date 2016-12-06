using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EachSecondChar
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter text:");

            string text = Convert.ToString(Console.ReadLine());
            Print(text);

            Console.ReadKey();

        }

        static void Print(string text)
        {
            char[] temp = text.ToCharArray();

            for (int i = 0; i < temp.Length; i += 2)
                Console.WriteLine("- '{0}'", temp[i]);
        }
    }
}
