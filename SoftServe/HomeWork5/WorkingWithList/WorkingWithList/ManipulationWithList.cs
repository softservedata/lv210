using System;
using System.Collections.Generic;

namespace WorkingWithList
{
    public class ManipulationWithList
    {
        public List<int> GetElementPositions(List<int> list, int element)
        {
            var positionsOfElement = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == element)
                {
                    positionsOfElement.Add(i);
                }
            }

            return positionsOfElement;
        }

        public List<int> RemovetElementsGraterThan(List<int> currentList, int elementsForRemove)
        {
            currentList.RemoveAll(x => x >= elementsForRemove);

            return currentList;
        }

        public List<int> InsertElements(List<int> currentList, List<int> elementsForInsertToList, List<int> listOfPositionsForElementsForInsert)
        {
            try
            {
                for (int i = 0; i < elementsForInsertToList.Count; i++)
                {
                    currentList.Insert(listOfPositionsForElementsForInsert[i], elementsForInsertToList[i]);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                throw new IndexOutOfRangeException(ex.Message);
            }

            return currentList;
        }
    }
}
