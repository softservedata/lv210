using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HwFive
{
    public class HwTestList
    {
        /// <summary>
        /// Create Console Application project in VS.
        /// A) Add to class method  static void TestList() and put in it code for solving next tasks:
        /// 1) Declare List myColl of integers and fill it from Console by 10 integer numbers.
        /// 2) Find and print all positions of element -10 in the list
        /// 2) Remove from list elements, which are greater then 20. Print list
        /// 3) Insert elements 1,-3,-4 in the positions 2, 8, 5. Print list
        /// 4) Sort and print list
        /// B)Add to class method  static void TestArrayList() and static void TestSortedList() for solving the same tasks
        /// C)In the method Main() Call developed methods TestList(), TestArrayList(), TestSortedList()
        /// </summary>
        public static void TestList()
        {
            int elementsToAdd = 10;
            int elementToFind = -10;
            int elementToRemove = 20;
            int[] elements = { 1, -3, -4 };
            int[] indexes = { 2, 8, 5 };

            List<int> myColl = new List<int>();
            MyTestList testList = new MyTestList();

            myColl = testList.FilledFromConsole(elementsToAdd);
            testList.FindElementsPosition(myColl, elementToFind);
            testList.RemoveElementsAndPrintList(myColl, elementToRemove);
            testList.InsertElements(myColl, elements, indexes);
            testList.SortList(myColl);
            testList.PrintList(myColl);
        }

        public static void TestSortedList()
        {
            int elementsToAdd = 10;
            int elementToFind = -10;
            int elementToRemove = 20;
            int[] elements = { 1, -3, -4 };
            int[] indexes = { 2, 8, 5 };

            SortedList mySortedColl = new SortedList();
            MySortedList testList = new MySortedList();

            mySortedColl = testList.FilledFromConsole(elementsToAdd);
            testList.FindElementsPosition(mySortedColl, elementToFind);
            testList.RemoveElementsAndPrintList(mySortedColl, elementToRemove);
            testList.InsertElements(mySortedColl, elements, indexes);
            testList.PrintList(mySortedColl);
        }

        public static void TestArrayList()
        {
            int elementsToAdd = 10;
            int elementToFind = -10;
            int elementToRemove = 20;
            int[] elements = { 1, -3, -4 };
            int[] indexes = { 2, 8, 5 };

            ArrayList myArrayColl = new ArrayList();
            MyArrayList testList = new MyArrayList();

            myArrayColl = testList.FilledFromConsole(elementsToAdd);
            testList.FindElementsPosition(myArrayColl, elementToFind);
            testList.RemoveElementsAndPrintList(myArrayColl, elementToRemove);
            testList.InsertElements(myArrayColl, elements, indexes);
            testList.SortList(myArrayColl);
            testList.PrintList(myArrayColl);
        }

        public static void Main()
        {
            TestList();
            TestSortedList();
            TestArrayList();
        }
    }

}






