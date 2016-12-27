using System;
using System.Collections.Generic;

namespace WorkingWithList
{
    class ListInfo
    {
        ManipulationWithList list;
        List<int> myCollection;
        string[] inputData;

        public ListInfo()
        {
            list = new ManipulationWithList();
            myCollection = GetListFromConsole();
        }

        private static List<int> GetListFromConsole()
        {
            List<int> list = new List<int>();

            Console.WriteLine("Input integer numbers separated by space : ");
            string[] inputData = Console.ReadLine().Split(' ');

            list = ConvertFromStringToList(inputData);

            return list;
        }

        public void ElementPosition()
        {
            Console.Write("Input element for find position of it : ");
            var elementPosition = int.Parse(Console.ReadLine());
            Console.Write("Position(s) of element {0} is(are) : ", elementPosition);
            var getElementPosition = list.GetElementPosition(myCollection, elementPosition);

            PrintList(getElementPosition);
        }

        public void RemoveFromList()
        {
            Console.Write("\nInput element which you want to remove from list (we remove all elements which greater than inputed element) : ");
            var elementForRemove = int.Parse(Console.ReadLine());
            Console.WriteLine("List after remove some element(s) : ");
            myCollection = list.RemoveElement(myCollection, elementForRemove);

            PrintList(myCollection);
        }

        public void InsertToList()
        {
            Console.WriteLine("Input separated by space elements what you want to insert : ");
            inputData = Console.ReadLine().Split(' ');
            var insertElements = ConvertFromStringToList(inputData);

            Console.WriteLine("Input separated by space indexes where you want to insert (index can't be greater than list count): ");
            inputData = Console.ReadLine().Split(' ');
            var insertIndexes = ConvertFromStringToList(inputData);

            Console.WriteLine("List after insert some element(s) : ");
            myCollection = list.InsertElements(myCollection, insertElements, insertIndexes);

            PrintList(myCollection);
        }

        public void SortList()
        {
            Console.WriteLine("List after sort : ");
            myCollection =  list.Sort(myCollection);

            PrintList(myCollection);
        }

        public void PrintList(List<int> list)
        {
            list.ForEach(p => Console.Write(p.ToString() + " "));
            Console.WriteLine();
        }

        private static List<int> ConvertFromStringToList(string[] stringToConvert)
        {
            var list = new List<int>();

            for (int i = 0; i < stringToConvert.Length; i++)
            {
                list.Add(int.Parse(stringToConvert[i]));
            }

            return list;
        }
    }
}
