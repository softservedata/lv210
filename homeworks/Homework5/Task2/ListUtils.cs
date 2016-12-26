using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class ListUtils
    {
        public static List<int> FindPositions(List<int> list, int value)
        {
            if (list == null || list.Capacity == 0)
            {
                throw new ArgumentNullException("List can not be null or empty");
            }
            List<int> positions = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == value) positions.Add(i + 1);
            }

            return positions;
        }

    }
}
