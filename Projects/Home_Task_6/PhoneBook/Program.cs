using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    class Program
    {
        static void Main(string[] args)
        {
            PhoneBook book = new PhoneBook();

            book.ReadFromFile("phones.txt");
            book.ConsoleDisplay();

            book.WritePhoneNumbersToFile("PhonesNumbers.txt");

            Console.WriteLine("\nEnter the name to find: ");
            book.GetNumberByName(Console.ReadLine()); 

            Console.WriteLine("\n----Changing Format----");
            book.ChangeNumberFormat();
            book.ConsoleDisplay();
            
            book.WritePhoneBookToFile("New.txt");           
        }
    }
}
