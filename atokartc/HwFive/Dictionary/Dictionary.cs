using System;
using System.Collections.Generic;

namespace HwFive
{
    /// <summary>
    /// Create Console Application project in VS.
    /// In the Main() method declare Dictionary of pairs<uint, string>.Add to Dictionary from Console 7 pairs(ID, Name) of some persons.
    /// Ask user to enter ID, then find and write corresponding Name from your Dictionary.If you can't find this ID - say about it to user. 
    /// </summary>
    public class DictionaryUtils
    {
        private uint GetPositiveNumber()
        {
            uint readedVar = 0;
            bool isIntEntered = UInt32.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered == false)
            {
                Console.WriteLine("Please, enter an positive integer");
                return this.GetPositiveNumber();
            }
            return readedVar;
        }

        public Dictionary<uint, string> AddValuesToDictiuonary(int numberOfValues)
        {
            bool doesKeyBefore;
            uint key = 0;
            string value = null;
            Dictionary<uint, string> dictionary = new Dictionary<uint, string>();

            for (int i = 0; i < numberOfValues; i++)
            {
                key = GetPositiveNumber();
                value = Console.ReadLine();
                doesKeyBefore = dictionary.ContainsKey(key);

                if (doesKeyBefore)
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

        public void GetNameById(Dictionary<uint, string> dictionary)
        {
            Console.Write("Enter number Id to get name: ");
            uint id = GetPositiveNumber();
            string name;

            if (dictionary.TryGetValue(id, out name))
            {
                Console.WriteLine("Id: {0} - Name: {1}", id, name);
            }
            else
            {
                Console.WriteLine("There is no such id in Dictionary: {0}", id);
            }
        }
    }
}

