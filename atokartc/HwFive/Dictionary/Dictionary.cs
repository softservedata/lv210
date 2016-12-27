using System;
using System.Collections.Generic;

namespace HwFive
{
    /// <summary>
    /// Create Console Application project in VS.
    /// In the Main() method declare Dictionary of pairs<uint, string>.Add to Dictionary from Console 7 pairs(ID, Name) of some persons.
    /// Ask user to enter ID, then find and write corresponding Name from your Dictionary.If you can't find this ID - say about it to user. 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Adds specific amount of values to Dictionary which could be specified by user. 
        /// </summary>
        /// <param name="numberOfValues"></param>
        /// <returns></returns>
        public Dictionary<uint, string> AddValuesToDictiuonary(int numberOfValues)
        {
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();
            Console.WriteLine("Enter id press Enter than enter name. Press Enter. Emter all vakues one by one");

            for (int i = 0; i < numberOfValues; i++)
            {
                uint key = UInt16.Parse(Console.ReadLine());
                string value = Console.ReadLine();

                if (dictionary.ContainsKey(key))
                {
                    dictionary[key] = value;
                }
                else
                {
                    dictionary.Add(key, value);
                }
            }
            return dictionary;
        }
        /// <summary>
        /// Gets name from dictionary using id(key)
        /// </summary>
        /// <param name="dictionary"></param>
        public void GetNameById(Dictionary<uint, string> dictionary)
        {
            Console.Write("Enter number Id to get name: ");
            uint enteredId = UInt16.Parse(Console.ReadLine());
            string name;

            if (dictionary.TryGetValue(enteredId, out name))
            {
                Console.WriteLine("Id: {0} - Name: {1}", enteredId, name);
            }
            else
            {
                Console.WriteLine("There is no such id in Dictionary: {0}", enteredId);
            }
        }

        public static void Main()
        {
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();

            Program p = new Program();
            dictionary = p.AddValuesToDictiuonary(3);
            p.GetNameById(dictionary);
        }
    }
}

