using System;
using System.Collections.Generic;

namespace WorkingWithList
{
    class ListInfo
    {
        ManipulationWithList manipulationWithList;
        List<int> list;
        string[] inputDataFromConsole;

        public ListInfo()
        {
            manipulationWithList = new ManipulationWithList();
            list = GetListFromConsole();
        }

        /// <summary>
        /// Read from console numbers, set this numbers to string array.
        /// Call ConvertFromStringToList(), which convert these strings to list of numbers.
        /// </summary>
        /// <returns>List of numbers</returns>
        private static List<int> GetListFromConsole()
        {
            var list = new List<int>();

            Console.WriteLine("Input integer numbers separated by space : ");
            string[] inputData = Console.ReadLine().Split(' ');

            list = ConvertFromStringToList(inputData);

            return list;
        }

        /// <summary>
        /// Ask for which element find position(s) in list.
        /// Call GetElementPositions() for find position(s) of element.
        /// Print into console element positions. 
        /// </summary>
        public void ElementPosition()
        {
            Console.Write("Input element for find position of it : ");
            var searchedElementPosition = int.Parse(Console.ReadLine());
            Console.Write("Position(s) of element {0} is(are) : ", searchedElementPosition);
            var elementPositions =  manipulationWithList.GetElementPositions(list, searchedElementPosition);

            PrintList(elementPositions);
        }

        /// <summary>
        /// Ask which element(s) should be deleted from list.
        /// Call RemovetElementsGraterThan() for removing from list elements
        /// which are greater or equal given element.
        /// Print resulted list into console.
        /// </summary>
        public void RemoveFromList()
        {
            Console.Write("\nInput element which you want to remove from list (we remove all elements which greater than inputed element) : ");
            var elementsForRemove = int.Parse(Console.ReadLine());
            Console.WriteLine("List after remove some element(s) : ");
            list = manipulationWithList.RemovetElementsGraterThan(list, elementsForRemove);

            PrintList(list);
        }

        /// <summary>
        /// Ask which element(s) should be inserted into the list
        /// and which position(s) should have these element(s) in list.
        /// Call InsertElements() for it.
        /// Print resulted list into console.
        /// </summary>
        public void InsertToList()
        {
            Console.WriteLine("Input separated by space elements what you want to insert : ");
            inputDataFromConsole = Console.ReadLine().Split(' ');
            var elementsForInsertToList = ConvertFromStringToList(inputDataFromConsole);

            Console.WriteLine("Input separated by space indexes where you want to insert (index can't be greater than list count): ");
            inputDataFromConsole = Console.ReadLine().Split(' ');
            var indexesForInsert = ConvertFromStringToList(inputDataFromConsole);

            Console.WriteLine("List after insert some element(s) : ");
            list = manipulationWithList.InsertElements(list, elementsForInsertToList, indexesForInsert);

            PrintList(list);
        }
        
        /// <summary>
        /// Sort and print resulted list into console.
        /// </summary>
        public void SortList()
        {
            list.Sort();
            Console.WriteLine("List after sort : ");

            PrintList(list);
        }

        /// <summary>
        /// Print appropriate list into console.
        /// </summary>
        /// <param name="list"></param>
        private void PrintList(List<int> list)
        {
            list.ForEach(p => Console.Write(p.ToString() + " "));
            Console.WriteLine();
        }

        /// <summary>
        /// Convert from strings array to list. 
        /// </summary>
        /// <param name="stringsForConvert">Input strings array</param>
        /// <returns>List of numbers</returns>
        private static List<int> ConvertFromStringToList(string[] stringsForConvert)
        {
            var listFromString = new List<int>();

            for (int i = 0; i < stringsForConvert.Length; i++)
            {
                listFromString.Add(int.Parse(stringsForConvert[i]));
            }

            return listFromString;
        }
    }
}
