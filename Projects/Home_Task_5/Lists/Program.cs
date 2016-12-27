using System;
using System.Collections;
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
            TestList();

            Console.WriteLine("\n-----ARRAY LIST-----");
            TestArrayList();

            Console.WriteLine("\n-----SORTED LIST-----");
            TestSortedList();
        }

        /// <summary>
        /// Testing method for integer List type
        /// </summary>
        public static void TestList()
        {
            List<int> myColl = new List<int>();

            ListUtilityClass.Fill(myColl, 10);
            ListUtilityClass.ConsoleDisplay(myColl);

            Console.WriteLine("\n---Find Position---");
            ListUtilityClass.ConsoleDisplay(ListUtilityClass.FindPositions(myColl, -10));

            Console.WriteLine("\n---Remove---");
            myColl.RemoveAll(item => item > 20);
            ListUtilityClass.ConsoleDisplay(myColl);

            Console.WriteLine("\n---Insert---");
            myColl.Insert(2, 1);
            myColl.Insert(8, -3);
            myColl.Insert(5, -4);
            ListUtilityClass.ConsoleDisplay(myColl);

            Console.WriteLine("\n---Sort---");
            myColl.Sort();
            ListUtilityClass.ConsoleDisplay(myColl);
        }

        /// <summary>
        /// Testing method for ArrayList type
        /// </summary>
        public static void TestArrayList()
        {
            ArrayList myColl = new ArrayList();

            ListUtilityClass.Fill(myColl, 10);
            ListUtilityClass.ConsoleDisplay(myColl);

            Console.WriteLine("\n---Find Position---");
            ListUtilityClass.ConsoleDisplay(ListUtilityClass.FindPositions(myColl, -10));

            Console.WriteLine("\n---Remove---");
            ListUtilityClass.Remove(myColl, 20);
            ListUtilityClass.ConsoleDisplay(myColl);

            Console.WriteLine("\n---Insert---");
            myColl.Insert(2, 1);
            myColl.Insert(8, -3);
            myColl.Insert(5, -4);
            ListUtilityClass.ConsoleDisplay(myColl);

            Console.WriteLine("\n---Sort---");
            myColl.Sort();
            ListUtilityClass.ConsoleDisplay(myColl);
        }

        /// <summary>
        /// Testing method for SortedList type
        /// </summary>
        public static void TestSortedList()
        {
            SortedList myColl = new SortedList();

            ListUtilityClass.Fill(myColl, 10);
            ListUtilityClass.ConsoleDisplay(myColl);

            Console.WriteLine("\n---Find Position---");
            ListUtilityClass.ConsoleDisplay(ListUtilityClass.FindPositions(myColl, -10));

            Console.WriteLine("\n---Remove---");
            ListUtilityClass.Remove(myColl, 20);
            ListUtilityClass.ConsoleDisplay(myColl);

            Console.WriteLine("\n---Insert---");
            myColl.SetByIndex(2, 1);
            myColl.SetByIndex(8, -3);
            myColl.SetByIndex(5, -4);
            ListUtilityClass.ConsoleDisplay(myColl);
        }
    }
}
