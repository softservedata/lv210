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

        public void ElementPosition()
        {
            Console.Write("Input element for find position of it : ");
            var elementPosition = int.Parse(Console.ReadLine());
            Console.Write("Position(s) of element {0} is(are) : ", elementPosition);
            list.GetElementPosition(myCollection, elementPosition);
        }

        public void RemoveFromList()
        {
            Console.Write("\nInput element which you want to remove from list (we remove all elements which greater than inputed element) : ");
            var elementForRemove = int.Parse(Console.ReadLine());
            Console.WriteLine("List after remove some element(s) : ");
            list.RemoveElement(myCollection, elementForRemove);
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
        }

        public void SortList()
        {
            Console.WriteLine("List after sort : ");
            list.Sort(myCollection);
        }

        private static List<int> GetListFromConsole()
        {
            List<int> list = new List<int>();

            Console.WriteLine("Input integer numbers separated by space : ");
            string[] inputData = Console.ReadLine().Split(' ');

            list = ConvertFromStringToList(inputData);

            return list;
        }
        private static List<int> ConvertFromStringToList(string[] stringArray)
        {
            var list = new List<int>();

            for (int i = 0; i < stringArray.Length; i++)
            {
                list.Add(int.Parse(stringArray[i]));
            }

            return list;
        }
    }
}
