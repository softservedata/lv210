using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionProject
{
    // 1) Find and print all positions of element -10 in the collection
    // 2) Remove from collection elements, which are greater then 20.  
    // 3) Insert elements 1,-3,-4 in positions 2, 8, 5. Print collection
    // 4) Sort and print collection

    class Program
    {
        private static void PrintCollection(List<int> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }

        private static bool isMoreThan20(int number)
        {
            return number > 20;
        }

        static void Main(string[] args)
        {
            // Input collection
            int element;
            List<int> myColl = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                element = Convert.ToInt32(Console.ReadLine());
                myColl.Add(element);
            }
            // PrintCollection
            Console.WriteLine("\n Collection");
            PrintCollection(myColl);
            Console.ReadKey();

            // 1) Find and print all positions of element -10 in the collection
            for (int i=0; i<myColl.Count; i++)
                if (myColl[i]==-10)
                {
                    Console.WriteLine("\n Element {0} is -10", i);
                }
            Console.ReadKey();


            // 2) Remove from collection elements, which are greater then 20.  
            myColl.RemoveAll(isMoreThan20);
            Console.WriteLine("\n Result without number greater then 20");
            PrintCollection(myColl);
            Console.ReadKey();

            // 3) Insert elements 1,-3,-4 in positions 2, 8, 5. Print collection
            myColl.Insert(2, 1);
            myColl.Insert(3, -3);
            myColl.Insert(5, -4);
            Console.WriteLine("\n Result with new elements");
            PrintCollection(myColl);
            Console.ReadKey();

            // 4) Sort and print collection
            myColl.Sort();
            Console.WriteLine("\n Sorted list");
            PrintCollection(myColl);
            Console.ReadKey();
        }
    }
}
