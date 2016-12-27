using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PhoneBook
{
    class PhoneBook
    {
        // Field

        private Dictionary<string, string> _phoneBook;

        // Methods

        /// <summary>
        /// Read from file phone numbers
        /// </summary>
        /// <param name="filePath">Path to file</param>
        public void ReadFromFile(string filePath)
        {
            _phoneBook = new Dictionary<string, string>();

            try
            {
                using (StreamReader strReader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = strReader.ReadLine()) != null)
                    {
                        string[] records = line.Split(' ');
                        _phoneBook.Add(records[1], records[0]);
                    }
                }
            }

            catch (FileNotFoundException exception)
            {
                Console.Error.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Represent result on console
        /// </summary>
        public void ConsoleDisplay()
        {
            foreach (KeyValuePair<string, string> record in _phoneBook)
            {
                Console.WriteLine("{0}\ttel. {1}", record.Value, record.Key);
            }
        }

        /// <summary>
        /// Write only numbers whithout names
        /// </summary>
        /// <param name="fileName">Name of file (*.txt format)</param>
        public void WritePhoneNumbersToFile(string fileName)
        {
            File.WriteAllLines(fileName, _phoneBook.Keys);
            Console.WriteLine("\nWriting to file done!");
        }

        /// <summary>
        /// Write numbers and names to *.txt file
        /// </summary>
        /// <param name="fileName">Name of file</param>
        public void WritePhoneBookToFile(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (KeyValuePair<string, string> record in _phoneBook)
                {
                    writer.WriteLine("{0} {1}", record.Value, record.Key);
                }
            }
            Console.WriteLine("\nWriting to file done!");
        }

        /// <summary>
        /// If given name is in the phonebook - use FindNumber() 
        /// to find and display correspond phonenumber
        /// </summary>
        /// <param name="name">Given name to find it phone number</param>
        public void GetNumberByName(string name)
        {
            if (_phoneBook.ContainsValue(name))
                FindNumber(name);

            else
                Console.WriteLine("There aren't phone number for {0}!", name);
        }

        /// <summary>
        /// By given name find correspond phone number
        /// </summary>
        /// <param name="name">Given name to find it phone number</param>
        private void FindNumber(string name)
        {
            foreach (var record in _phoneBook)
            {
                if (record.Value == name)
                {
                    Console.WriteLine(record);
                }
            }
        }

        /// <summary>
        /// Change all phone numbers, which are not in format +380#########
        /// </summary>
        public void ChangeNumberFormat()
        {
            List<string> numbers = new List<string>(_phoneBook.Keys);

            foreach (var number in numbers)
            {
                if (!number.StartsWith("+38"))
                {
                    string newNumber = String.Format("+380{0}", number.TrimStart('8', '0'));
                    _phoneBook.Add(newNumber, _phoneBook[number]);
                    _phoneBook.Remove(number);
                }
            }
        }
    }
}
