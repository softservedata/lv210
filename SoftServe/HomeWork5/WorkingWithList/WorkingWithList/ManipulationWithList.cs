using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithList
{
    class ManipulationWithList
    {
        public void GetElementPosition(List<int> list, int element)
        {
            var foundIndex = list.Select((n, i) => new { number = n, index = i })
                .Where(l => l.number == element)
                .ToList();
            foundIndex.ForEach(l => Console.Write(l.index + " "));
        }

        public void RemoveElement(List<int> list, int element)
        {
            list.RemoveAll(x => x >= element);

            PrintList(list);
        }

        public List<int> InsertElements(List<int> list, List<int> element, List<int> index)
        {
            for (int i = 0; i < element.Count; i++)
            {
                list.Insert(index[i], element[i]);
            }

            PrintList(list);

            return list;
        }
        public void Sort(List<int> list)
        {
            var array = list.ToArray();
            Array.Sort(array);
            var sortedList = array.ToList();

            PrintList(sortedList);
        }

        public void PrintList(List<int> list)
        {
            list.ForEach(p => Console.Write(p.ToString() + " "));
            Console.WriteLine();
        }
    }
}
