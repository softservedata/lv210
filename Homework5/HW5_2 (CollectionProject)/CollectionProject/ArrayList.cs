using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionProject
{
    class ArrayList
    {
        public static void TestArrayList()
        {
            // Input collection
            ArrayList array = new ArrayList();
            for (int i = 0; i < 5; i++)
            {
                array.Add(Convert.ToInt32(Console.ReadLine()));
            }
            foreach (object element in array)
            {
                Console.WriteLine(element);
            }
           
            //Print collection
            public void PrintArray(IEnumerable printArray)
            {
                foreach(var item in printArray)
                {
                    Console.Write(item);
                }
                Console.ReadKey();
            }
            
            
            // 1) Find and print all positions of element -10 in the collection
        public void DesiredElement(ArrayList array)
        {
            for (int i = 0; i < array.Count; i++)
            if (array[i] == -10)
                {
                    Console.WriteLine("\n Element {0} is -10", i);
                }
        }
           
        // 2. Remove elements, which are greater then 20
        public void RemoveElement(ArrayList array, int element)
        {
            for (int i = 0; i < array.Count; i++)
            {
                if ((int)array[i] > element)
                {
                    array.RemoveAt(i);
                }
            }
            Console.WriteLine("\n Result without number greater then 20");
            PrintArray(array);
        }

        // 3. Insert elements 1,-3,-4 in positions 2, 8, 5. Print collection
        public void InsertElement (ArrayList array)
        {
            array.Insert(2,1);
            array.Insert(2,1);
            array.Insert(2,1);
            Console.WriteLine("\n Result with new elements");
            PrintArray(array);
        }
        
        // 4) Sort and print collection

    
        }

    }
}
