using System;
using System.Collections.Generic;
using System.Linq;

namespace WorkingWithList
{
    public class ManipulationWithList
    {
        public List<int> GetElementPosition(List<int> list, int element)
        {
            var foundIndex = list.Select((n, i) => new { number = n, index = i })
                .Where(l => l.number == element)
                .ToList();

            var indexes = foundIndex.Select(l => l.index).ToList();

            return indexes;
        }

        public List<int> RemoveElement(List<int> list, int element)
        {
            list.RemoveAll(x => x >= element);

            return list;
        }

        public List<int> InsertElements(List<int> list, List<int> element, List<int> index)
        {
            for (int i = 0; i < element.Count; i++)
            {
                list.Insert(index[i], element[i]);
            }

            return list;
        }
        public List<int> Sort(List<int> list)
        {
            list.Sort();

            return list;
        }
    }
}
