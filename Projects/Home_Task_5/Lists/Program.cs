using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----LIST-----");
            ListUtilityClass.TestList();

            Console.WriteLine("\n-----ARRAY LIST-----");
            ListUtilityClass.TestArrayList();

            Console.WriteLine("\n-----SORTED LIST-----");
            ListUtilityClass.TestSortedList();
        }
    }
}
