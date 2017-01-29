using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HwSixExceptions
{
    /// <summary>
    /// Declare Dictionary PhoneBook for keeping pairs PersonName-PhoneNumber.
    /// 1) From file "phones.txt" read 9 pairs into PhoneBook. Write only PhoneNumbers into file "Phones.txt".
    /// 2) Find and print phone number by the given name (name input from console)
    /// 3) Change all phone numbers, which are in format 80######### into new format +380#########. The result write into file "New.txt"
    /// </summary>
    public class PhoneBook
    {
        public Dictionary<string, string> PhoneDictionary { get; private set; }

        /// <summary>
        /// Reads the phonenumbers and keys.
        /// </summary>
        /// <param name="path"></param>
        public void ReadFromFile(string path)
        {
            PhoneDictionary = new Dictionary<string, string>();
            string[] text = { };

            try
            {
                text = File.ReadAllLines(path);

                foreach (string line in text)
                {
                    string[] data = line.Split(',');
                    PhoneDictionary.Add(data[0], data[1]);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File was not found");
            }

        }

        public void Output()
        {
            foreach (var item in PhoneDictionary)
            {
                Console.WriteLine("{0}, {1}", item.Key, item.Value);
            }
        }

        public void WritePhoneNumbersToFile(string fileName)
        {
            File.WriteAllLines(fileName, PhoneDictionary.Values);
        }

        /// <summary>
        /// Changes phone numbers from 80 to +380 format
        /// </summary>
        public void ChangeFormat()
        {
            List<string> keys = new List<string>(PhoneDictionary.Keys);
            foreach (string key in keys)
            {
                if (PhoneDictionary[key].StartsWith("80")) PhoneDictionary[key] = "+3" + PhoneDictionary[key];
            }
        }

        public void WriteToFile()
        {
            File.WriteAllLines("PhoneBook.txt", PhoneDictionary.Select(item => item.Key + ", " + item.Value));
        }

        /// <summary>
        /// Searches for users phone number
        /// </summary>
        /// <returns></returns>
        public string FindNumber()
        {
            Console.WriteLine("Please enter name to search");
            string name = Console.ReadLine();

            if (!PhoneDictionary.ContainsKey(name))
            {
                return name + "phone number can not be found";
            }
            return PhoneDictionary[name];
        }
    }
}
