using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5_2
{
    class Program
    {
        static void TestList()
        {
            int numberCount = 10;
            List<int> myColl = new List<int>();
            int ParsedValues;
            myColl = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select
                                                    (i => int.TryParse(i, out ParsedValues) ? ParsedValues : 0).ToList();
            for (int i = 0; i < numberCount; i++)
            {
                if (myColl.ElementAt(i) == -10)
                {
                    Console.WriteLine("Index of element '-10': {0}", i);
                }
            }

            Console.Write("List without number greater then 20: ");
            for (int i = 0; i < numberCount; i++)
            {
                if (myColl.ElementAt(i) > 20)
                {
                    myColl.RemoveAt(i);
                }
                Console.Write(myColl.ElementAt(i) + " ");
            }
            Console.Write("\n");

            myColl.Insert(2, 1);
            myColl.Insert(8, -3);
            myColl.Insert(5, -4);

            Console.Write("List with new items: ");
            for (int i = 0; i < numberCount; i++)
            {
                Console.Write(myColl.ElementAt(i) + " ");
            }
            Console.Write("\n");

            myColl.Sort();
            Console.Write("Sorted list: ");
            for (int i = 0; i < numberCount; i++)
            {
                Console.Write(myColl.ElementAt(i) + " ");
            }
            Console.Write("\n");
        }

        static void TestArrayList()
        {

        }
        static void Main(string[] args)
        {
            TestList();
            TestArrayList();
            Console.ReadLine();
        }
    }
}
