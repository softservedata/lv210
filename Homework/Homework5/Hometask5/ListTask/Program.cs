using System;
using System.Collections;
using System.Collections.Generic;

namespace ListTask
{
    internal class Program
    {
        private static void TestListOrArrayList<T>(string[] inputedData, ref T listOfIntegers) where T : IList
        {
            foreach (var value in inputedData)
            {
                listOfIntegers.Add(int.Parse(value));
            }

            var listOfPositions = FindAllPossitionsOfElement(listOfIntegers, -10);
            Console.WriteLine("\nSearched positions:");
            PrintList(listOfPositions);

            RemoveFromList(ref listOfIntegers, 20);
            Console.WriteLine("\nRemoving items...");
            PrintList(listOfIntegers);

            InsertElementOnPosition(ref listOfIntegers, 1, 1);
            InsertElementOnPosition(ref listOfIntegers, -4, 4);
            InsertElementOnPosition(ref listOfIntegers, -3, 7);
            Console.WriteLine("\nInserting items...");
            PrintList(listOfIntegers);
        }

        private static void TestSortedList(string[] inputedData, ref SortedList listOfIntegers)
        {
            for (var i = 0; i < inputedData.Length; i++)
            {
                listOfIntegers.Add(i, int.Parse(inputedData[i]));
            }

            var listOfPositions = FindAllPossitionsOfElement(listOfIntegers, -10);
            Console.WriteLine("\nSearched positions:");
            PrintList(listOfPositions);

            RemoveFromList(ref listOfIntegers, 20);
            Console.WriteLine("\nRemoving items...");
            PrintSortedList(listOfIntegers);

            InsertElementOnPosition(ref listOfIntegers, 1, 1);
            InsertElementOnPosition(ref listOfIntegers, -4, 4);
            InsertElementOnPosition(ref listOfIntegers, -3, 7);
            Console.WriteLine("\nInserting items...");
            PrintSortedList(listOfIntegers);
        }

        #region FunctionsForListAndArrayList

        private static void PrintList<T>(T listOfElements) where T : IList
        {
            if (listOfElements.Count == 0)
            {
                Console.WriteLine("\nList is empty!");
            }

            foreach (var element in listOfElements)
            {
                Console.Write("{0} ", element);
            }

            Console.WriteLine();
        }

        private static List<int> FindAllPossitionsOfElement<T>(T listOfIntegers, int searchedElement) where T : IList
        {
            var listOfPositions = new List<int>();

            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                if ((int)listOfIntegers[i] == searchedElement)
                {
                    listOfPositions.Add(i);
                }
            }

            return listOfPositions;
        }

        private static void InsertElementOnPosition<T>(ref T listOfIntegers, int element, int position) where T : IList
        {
            if ((position < 0) || (position > listOfIntegers.Count))
            {
                throw new ArgumentException("Incorrect data!");
            }

            listOfIntegers.Insert(position, element);
        }

        private static void RemoveFromList<T>(ref T listOfIntegers, int element) where T : IList
        {
            for (int i = 0; i < listOfIntegers.Count; i++)
            {
                if ((int)listOfIntegers[i] > element)
                {
                    listOfIntegers.RemoveAt(i);
                    i--;
                }
            }
        }

        #endregion

        #region FunctionsForSortedArray

        private static List<int> FindAllPossitionsOfElement(SortedList listOfIntegers, int searchedElement)
        {
            var listOfPositions = new List<int>();

            for (var i = 0; i < listOfIntegers.Count; i++)
            {
                if ((int)listOfIntegers.GetByIndex(i) == searchedElement)
                {
                    listOfPositions.Add(i);
                }
            }

            return listOfPositions;
        }

        private static void InsertElementOnPosition(ref SortedList listOfIntegers, int element, int position)
        {
            if ((position < 0) || (position > listOfIntegers.Count))
            {
                throw new ArgumentException("Incorrect data!");
            }

            listOfIntegers.SetByIndex(position, element);
        }

        private static void Swap(ref SortedList listOfIntegers, int j)
        {
            var elementJ = (int)listOfIntegers.GetByIndex(j);
            var elementJPlusOne = (int)listOfIntegers.GetByIndex(j + 1);

            listOfIntegers.SetByIndex(j, elementJPlusOne);
            listOfIntegers.SetByIndex(j + 1, elementJ);
        }


        private static void RemoveFromList(ref SortedList listOfIntegers, int element)
        {
            for (var i = 0; i < listOfIntegers.Count; i++)
            {
                if ((int)listOfIntegers.GetByIndex(i) > element)
                {
                    listOfIntegers.RemoveAt(i);
                    i--;
                }
            }
        }

        private static void SortByValues(ref SortedList listOfIntegers)
        {
            var wasSwapped = true;
            for (var i = 1; (i < listOfIntegers.Count) && wasSwapped; i++)
            {
                wasSwapped = false;
                for (var j = 0; j < (listOfIntegers.Count - i); ++j)
                {
                    if ((int)listOfIntegers.GetByIndex(j) > (int)listOfIntegers.GetByIndex(j + 1))
                    {
                        Swap(ref listOfIntegers, j + 1);
                        wasSwapped = true;
                    }
                }
            }
        }

        private static void PrintSortedList(SortedList listOfElements)
        {
            if (listOfElements.Count == 0)
            {
                Console.WriteLine("\nList is empty:");
            }

            for (var i = 0; i < listOfElements.Count; i++)
            {
                Console.Write("{0} ", (int)listOfElements.GetByIndex(i));
            }

            Console.WriteLine();
        }

        #endregion

        #region RunListsFunction

        private static void RunList(string[] arrayOfStringNumbers)
        {
            Console.WriteLine("\n\n\nTest List: ");
            var listOfIntegers = new List<int>();
            TestListOrArrayList(arrayOfStringNumbers, ref listOfIntegers);
            listOfIntegers.Sort();
            Console.WriteLine("\nSorted List: ");
            PrintList(listOfIntegers);
        }

        private static void RunArrayList(string[] arrayOfStringNumbers)
        {
            Console.WriteLine("\n\n\nTest ArrayList: \n");
            var arrayListOfIntegers = new ArrayList();
            TestListOrArrayList(arrayOfStringNumbers, ref arrayListOfIntegers);
            arrayListOfIntegers.Sort();
            Console.WriteLine("\nSorted ArrayList: ");
            PrintList(arrayListOfIntegers);
        }

        private static void RunSortedList(string[] arrayOfStringNumbers)
        {
            Console.WriteLine("\n\n\nTest SortedList: \n");
            var sortedListOfIntegers = new SortedList();
            TestSortedList(arrayOfStringNumbers, ref sortedListOfIntegers);
            Console.WriteLine("\nSortedList: ");
            SortByValues(ref sortedListOfIntegers);
            PrintSortedList(sortedListOfIntegers);
        }

        #endregion


        private static void Main()
        {
            const int count = 10;
            Console.WriteLine($"Please, input {count} integer numbers:");
            var readedData = Console.ReadLine();
            var arrayOfStringNumbers = readedData?.Split(' ');

            try
            {
                RunList(arrayOfStringNumbers);
                RunArrayList(arrayOfStringNumbers);
                RunSortedList(arrayOfStringNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
