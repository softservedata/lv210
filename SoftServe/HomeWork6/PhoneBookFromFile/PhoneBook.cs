using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PhoneBookFromFile
{
    class PhoneBook
    {
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();

        public Dictionary<string, string> ReadDictionaryFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            string[] phonePairs;

            while ((line = reader.ReadLine()) != null)
            {
                phonePairs = line.Split(' ');
                phoneBook.Add(phonePairs[0], phonePairs[1]);
            }

            return phoneBook;
        }

        public string GetValueByKey(Dictionary<string, string> dictionary, string key)
        {
            string value;
            if (dictionary.TryGetValue(key, out value))
            {
                return value;
            }
            else
            {
                throw new ArgumentException("This key doesn't exist in dictionary", "key");
            }
        }

        public Dictionary<string, string> ChangePhoneFormat(Dictionary<string,  string> dictionary)
        {
            var countryCode = "+3";

            foreach (var item in dictionary.Keys.ToList())
            {
                if (dictionary[item].StartsWith("80"))
                {
                    dictionary[item] = countryCode + dictionary[item];
                }
            }

            return dictionary;
        }

        public void WriteOnlyNumbersToFile(Dictionary<string, string> dictionary, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, string> item in dictionary)
                {
                    writer.WriteLine("{0}", item.Value);
                }
            }
        }

        public void WriteDictionaryToFile(Dictionary<string, string> dictionary, string path)
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (KeyValuePair<string, string> item in dictionary)
                {
                    writer.WriteLine("{0} {1}", item.Key, item.Value);
                }
            }
        }

        public void Output(Dictionary<string, string> dictionary)
        {
            foreach (KeyValuePair<string, string> item in dictionary)
            {
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
        }
    }
}
