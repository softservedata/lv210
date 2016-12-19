using System;

namespace WorkingWithList
{
    /// <summary>
    /// Create Console Application project in VS.
    /// A) Add to class method  static void TestList() and put in it code for solving next tasks:
    ///     1) Declare List myColl of integers and fill it from Console by 10 integer numbers.
	///     2) Find and print all positions of element -10 in the list
	///     3) Remove from list elements, which are greater then 20. Print list
	///     4) Insert elements 1,-3,-4 in the positions 2, 8, 5. Print list
	///     ) Sort and print list
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ListInfo info = new ListInfo();

            info.ElementPosition();
            info.RemoveFromList();
            info.InsertToList();
            info.SortList();

            Console.ReadKey();
        }
    }
}
