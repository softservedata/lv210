using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary
{
    /// <summary>
    /// In the Main() method declare Dictionary of pairs (uint,string). 
    /// Add to Dictionary from Console 7 pairs (ID, Name) of some persons.
    /// Ask user to enter ID, then find and write corresponding Name from your Dictionary.
    /// If you can't find this ID - say about it to user.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<uint, string> persons = new Dictionary<uint, string>();

            int numberOfPersons = 7;

            for (int i = 0; i < numberOfPersons; i++)
            {
                Console.Write("Enter the name: ");
                Person person = new Person(Console.ReadLine());
                persons.Add(person.ID, person.Name);
            }

            Display(persons);

            Console.WriteLine("Enter ID to find: ");
            string searchingID = Console.ReadLine();

            Console.WriteLine(GetValueByID(persons, searchingID));
        }

        /// <summary>
        /// Prints all members from Dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary which would like to display</param>
        static void Display(Dictionary<uint, string> dictionary)
        {
            foreach (KeyValuePair<uint, string> kvp in dictionary)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }

        /// <summary>
        /// By given ID try get relevant value from Dictionary
        /// </summary>
        /// <param name="dictionary">Dictionary which will search for</param>
        /// <param name="readFromConsoleID">Given ID by User</param>
        /// <returns></returns>
        static string GetValueByID(Dictionary<uint, string> dictionary, string readFromConsoleID)
        {
            uint id;
            UInt32.TryParse(readFromConsoleID, out id);

            string value;
            if (dictionary.TryGetValue(id, out value))
                return value;

            return "Fail! Can't find this ID.";
        }
    }
}
