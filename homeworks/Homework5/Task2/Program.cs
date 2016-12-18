using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        private static List<int> integersList = new List<int>();
     
        //private static ArrayList arrayList=new ArrayList();
        //private SortedList<int,int> sortedIntegerList=new SortedList<int, int>();
        
        public static void CreateList(string input)
        {
            char[] separators = {' ', ',', ';', '.'};
            string[] inputList = input.Split(separators);
            for (int i = 0; i < inputList.Length; i++)
            {
                integersList.Add(Convert.ToInt32(inputList[i]));
            }
        }

        public static void PrintValues<T>(IList<T> list)
        {
            foreach (T item in list)
            {
                Console.Write(" {0}", item);
            }
        }

        public static void TestList()
        {
            string input = Console.ReadLine();
            CreateList(input);
            Console.WriteLine("Integers list");
            PrintValues(integersList);

            Console.WriteLine("\nRemove values greater than");
            int valueToRemove = Convert.ToInt32(Console.ReadLine());
            integersList.RemoveAll(value => value > valueToRemove);
            PrintValues(integersList);

            Console.WriteLine("\nInserting values 1,-3,-4 to positions 2,8,5:");
            integersList.Insert(2, 1);
            integersList.Insert(8, -5);
            integersList.Insert(5, -4);
            PrintValues(integersList);
        }
        
        static void Main(string[] args)
        {
            TestList();
            Console.ReadKey();
        }
    }
}
