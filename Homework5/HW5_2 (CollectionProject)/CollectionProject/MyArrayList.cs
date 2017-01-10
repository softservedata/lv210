using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionProject
{
    class MyArrayList
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
        } 
            //Print collection
            public void PrintArrayList(ArrayList arrayList)
            {
                foreach(var item in arrayList)
                {
                    Console.Write(item);
                }
                Console.ReadKey();
            }
            
            
            // 1) Find and print all positions of element -10 in the collection
        public void DesiredElement(ArrayList arrayList)
        {
            for (int i = 0; i < arrayList.Count; i++)
            if ((int) arrayList[i] == -10)
                {
                    Console.WriteLine("\n Element {0} is -10", i);
                }
        }
           
        // 2. Remove elements, which are greater then 20
        public void RemoveElement(ArrayList arrayList, int element)
        {
            for (int i = 0; i < arrayList.Count; i++)
            {
                if ((int) arrayList[i] > element)
                {
                    arrayList.RemoveAt(i);
                }
            }
            Console.WriteLine("\n Result without number greater then 20");
            PrintArrayList(arrayList);
        }

        // 3. Insert elements 1,-3,-4 in positions 2, 8, 5. Print collection
        public void InsertElement (ArrayList arrayList)
        {
            arrayList.Insert(2,1);
            arrayList.Insert(2,1);
            arrayList.Insert(2,1);
            Console.WriteLine("\n Result with new elements");
            PrintArrayList(arrayList);
        }
        
        // 4) Sort and print collection
        public void SortAndPrint(ArrayList arrayList) 
        {
            arrayList.Sort();
            Console.WriteLine("\n Sorted list");
            PrintArrayList(arrayList);
            Console.ReadKey();
        }
    
        }

    }

