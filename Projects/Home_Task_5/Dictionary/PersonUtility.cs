using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    public static class PersonUtility
    {
        /// <summary>
        /// Check if read value from console is unsigned integer
        /// </summary>
        /// <param name="consoleString">String read from console</param>
        /// <returns></returns>
        private static bool IsUnsignedInteger(string consoleString)
        {
            uint integerValue;
            if (UInt32.TryParse(consoleString, out integerValue))
                return true;

            return false;
        }

        /// <summary>
        /// Throw exeption if in collection exist item with the same key
        /// </summary>
        /// <param name="idCollection">Collection which should be checked</param>
        /// <param name="id">Key (id) which should be checked for duplication</param>
        private static void CheckDublicatesForId(ICollection<uint> idCollection, uint id)
        {
            if (idCollection.Contains(id))
                throw new ArgumentException("\nPerson with the same key has already been added.");
        }

        /// <summary>
        /// If all conditions are passed, return valid ID, if not - throw exeption message
        /// </summary>
        /// <param name="idRead">ID read from console</param>
        /// <param name="idCollection">Collection with ID keys</param>
        /// <returns></returns>
        public static uint GetID(string idRead, ICollection<uint> idCollection)
        {
            uint validID;

            if (IsUnsignedInteger(idRead))
            {
                validID = UInt32.Parse(idRead);
                CheckDublicatesForId(idCollection, validID);
                return validID;
            }

            throw new FormatException($"\n{idRead} - is not unsigned integer!");
        }

        /// <summary>
        /// For input name of person
        /// </summary>
        /// <returns>Name read from Console</returns>
        public static string InputName()
        {
            Console.Write("Enter the name: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// For input ID of person
        /// </summary>
        /// <returns>(string)ID read from Console</returns>
        public static string InputId()
        {
            Console.Write("Enter ID: ");
            return Console.ReadLine();
        }

        /// <summary>
        /// Prints all members from dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary which would like to display</param>
        public static void Display(Dictionary<uint, string> dictionary)
        {
            foreach (KeyValuePair<uint, string> kvp in dictionary)
            {
                Console.WriteLine("ID:[{0}] ==> {1}", kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// Search name of person by its ID
        /// </summary>
        /// <param name="dictionary">Collections in which contains persons</param>
        /// <returns>If ID matches returns name of person</returns>
        public static string GetValueByID(Dictionary<uint, string> dictionary, string idRead)
        {
            string value;
            if (IsUnsignedInteger(idRead))
            {
                if (dictionary.TryGetValue(uint.Parse(idRead), out value))
                    return value;
            }

            return "Fail! Can't find this ID.";
        }
    }
}
