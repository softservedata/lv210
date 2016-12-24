using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace WorkWithFile
{
    public class PhoneBook
    {
        public Dictionary<string, string> BookOfPhones { get; set; }

        public PhoneBook(Dictionary<string, string> bookOfPhones)
        {
            BookOfPhones = bookOfPhones;
        }

        public PhoneBook()
        {
            BookOfPhones = new Dictionary<string, string>();
        }

        public void ReadDataFromFile(string fileName)
        {
            var reader = new StreamReader(fileName);

            string line;
            var listOfData = new List<string>();

            while ((line = reader.ReadLine()) != null)
            {
                if (line != string.Empty)
                {
                    listOfData.Add(line);
                }
            }

            var countOfLines = listOfData.Count;

            if (listOfData.Count % 2 != 0)
            {
                countOfLines = listOfData.Count - 1;
            }

            for (var i = 0; i < countOfLines - 1; i+=2)
            {
                BookOfPhones.Add(listOfData[i], listOfData[i+1]);
            }

            reader.Close();
        }

        public void ToFile(string fileName)
        {
            using (var writer = new StreamWriter(fileName))
            {
                foreach (var phone in BookOfPhones)
                {
                    writer.WriteLine(phone.Value);
                }
            }
        }

        /// <summary>
        /// <para> This function finds phone number of appropriate person. </para>
        /// </summary>

        public string FindNumberByPersonName(string personName)
        {
            string number;
            var isInBookOfPhones = BookOfPhones.TryGetValue(personName, out number);

            if (!isInBookOfPhones)
            {
                throw new ArgumentException("There is no such person in a phone book!");
            }

            return number;
        }

        private List<string> FindAllWithAppropriateFormat(string format)
        {
            var listOfKeys = new List<string>();

            foreach (var phone in BookOfPhones)
            {
                if (Regex.IsMatch(phone.Value, format))
                {
                    listOfKeys.Add(phone.Key);
                }
            }

            return listOfKeys;
        }

        /// <summary>
        /// <para> This function finds all phone numbers with specified format
        /// and replace them in +380xxxxxxxxx format. </para>
        /// </summary>

        public void ChangeFormatOfNumbers(string formatToChange)
        { 
            var listOfKeys = FindAllWithAppropriateFormat(formatToChange);

            foreach (var key in listOfKeys)
            {
                BookOfPhones[key] = Regex.Replace(BookOfPhones[key], formatToChange, $"+380{BookOfPhones[key].Substring(2)}");
            }
        }
    }
}