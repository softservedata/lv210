using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    public static class ListUtilityClass
    {
        /// <summary>
        /// Check if read value from console is integer
        /// </summary>
        /// <param name="consoleString">String read from console</param>
        /// <returns></returns>
        private static bool IsInteger(string consoleString)
        {
            int integerValue;
            if (Int32.TryParse(consoleString, out integerValue))
                return true;

            return false;
        }

        /// <summary>
        /// Using IsInteger() method to check if value is integer.
        /// If false print error messagee 
        /// </summary>
        /// <returns>int value</returns>
        private static int ConsoleInput()
        {
            string readFromConsole;

            do
            {
                Console.Write("Enter integer number ==> ");
                readFromConsole = Console.ReadLine();

                if (!IsInteger(readFromConsole))
                    Console.WriteLine("\nNumber is not integer!");
            }
            while (!IsInteger(readFromConsole));

            return int.Parse(readFromConsole);
        }

        /// <summary>
        /// Prints all members from integer List
        /// </summary>
        /// <param name="list">List which would like to display</param>
        public static void ConsoleDisplay(List<int> list)
        {
            foreach (var number in list)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Overloaded display method for integer ArrayList
        /// </summary>
        /// <param name="list">ArrayList which would like to display</param>
        public static void ConsoleDisplay(ArrayList list)
        {
            foreach (var number in list)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Overloaded display method for integer SortedList
        /// </summary>
        /// <param name="list">SortedList to print</param>
        public static void ConsoleDisplay(SortedList list)
        {
            IList valuesInList = list.GetValueList();
            IList keysInList = list.GetKeyList();

            Console.WriteLine("-KEY-\t-VALUE-");
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("{0}\t{1}", keysInList[i], valuesInList[i]);
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Fill list with integer values.
        /// ConsoleInput() - read value from console and verifies it
        /// </summary>
        /// <param name="list">List to add new integer numbers</param>
        /// <param name="numbersToFill">How many element List would be consist</param>
        public static void Fill(List<int> list, int numbersToFill)
        {
            for (int i = 0; i < numbersToFill; i++)
            {
                list.Add(ConsoleInput());
            }
        }

        /// <summary>
        /// Overloaded Fill() method for ArrayList type
        /// </summary>
        /// <param name="list">ArrayList to add new integer numbers</param>
        /// <param name="numbersToFill">How many element ArrayList would be consist</param>
        public static void Fill(ArrayList list, int numbersToFill)
        {
            for (int i = 0; i < numbersToFill; i++)
            {
                list.Add(ConsoleInput());
            }
        }

        /// <summary>
        /// Overloaded Fill() method for SortedList type
        /// </summary>
        /// <param name="list">SortedList to add new integer numbers</param>
        /// <param name="numbersToFill">How many element ArrayList would be consist</param>
        public static void Fill(SortedList list, int numbersToFill)
        {
            for (int i = 0; i < numbersToFill; i++)
            {
                list.Add(i, ConsoleInput());
            }
        }

        /// <summary>
        /// Find and print all positions of given element in the list
        /// </summary>
        /// <param name="list">A List in which will be check conditions</param>
        /// <param name="number">Given element to find</param>
        public static List<int> FindPositions(List<int> list, int number)
        {
            List<int> positions = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == number)
                {
                    positions.Add(i);
                }
            }

            return positions;
        }

        /// <summary>
        /// Overloaded FindPosition() method for ArrayList type
        /// </summary>
        /// <param name="list">An ArrayList in which will be check conditions</param>
        /// <param name="number">Given element to find</param>
        public static List<int> FindPositions(ArrayList list, int number)
        {
            List<int> positions = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if ((int)list[i] == number)
                {
                    positions.Add(i);
                }
            }

            return positions;
        }

        /// <summary>
        /// Overloaded FindPosition() method for SortedList type
        /// </summary>
        /// <param name="list">A SortedList in which will be check conditions</param>
        /// <param name="number">Given element to find</param>
        public static List<int> FindPositions(SortedList list, int number)
        {
            List<int> positions = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if ((int)list[i] == number)
                {
                    positions.Add(i);
                }
            }

            return positions;
        }

        /// <summary>
        /// Remove from ArrayList elements, which are greater then defined limit.
        /// </summary>
        /// <param name="list">ArrayList to perform actions</param>
        /// <param name="upperLimit">Defined limit</param>
        public static void Remove(ArrayList list, int upperLimit)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((int)list[i] > upperLimit)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Remove from SortedList elements, which are greater then defined limit.
        /// </summary>
        /// <param name="list">SortedList to perform actions</param>
        /// <param name="upperLimit">Defined limit</param>
        public static void Remove(SortedList list, int upperLimit)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if ((int)list.GetByIndex(i) > upperLimit)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }
    }
}
