using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    class Person
    {
        // Properties

        public uint ID { get; set; }
        public string Name { get; set; }

        // Constructors

        public Person() { }

        public Person(string name)
        {
            ID = IDInput();
            Name = name;
        }

        /// <summary>
        /// Check if read value from console is integer
        /// </summary>
        /// <param name="consoleString">String read from console</param>
        /// <returns></returns>
        private static bool IsUInteger(string consoleString)
        {
            uint integerValue;
            if (UInt32.TryParse(consoleString, out integerValue))
                return true;

            return false;
        }

        /// <summary>
        /// Using IsUInteger() method to check if value is unsigned integer.
        /// </summary>
        /// <returns>Int value</returns>
        private static uint IDInput()
        {
            string readFromConsole;

            do
            {
                Console.Write("Enter ID: ");
                readFromConsole = Console.ReadLine();
                if (!IsUInteger(readFromConsole))
                    Console.WriteLine("\nID is not unsigned integer!");
            }
            while (!IsUInteger(readFromConsole));

            return uint.Parse(readFromConsole);
        }
    }
}
