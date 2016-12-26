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
            int numberOfPersons = 2;

            try
            {
                for (int i = 0; i < numberOfPersons; i++)
                {
                    string name = PersonUtility.InputName();
                    uint id = PersonUtility.GetID(PersonUtility.InputId(), persons.Keys);

                    persons.Add(id, name);
                }
            }

            catch (FormatException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            catch (ArgumentException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }

            Console.WriteLine("\n----List of Persons----");
            PersonUtility.Display(persons);

            Console.WriteLine("\n----Find Person in List----");
            Console.WriteLine(PersonUtility.GetValueByID(persons, PersonUtility.InputId()));
        }
    }
}
