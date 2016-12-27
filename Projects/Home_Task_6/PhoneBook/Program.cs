using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    /// <summary>
    ///   In Main() method declare Dictionary PhoneBook for keeping pairs PersonName-PhoneNumber
    ///   1) From file "phones.txt" read 9 pairs into PhoneBook.Write only PhoneNumbers into file "Phones.txt".
    ///   2) Find and print phone number by the given name(name input from console)
    ///   3) Change all phone numbers, which are in format 80######### into new format +380#########. 
    ///   The result dictionary write into file "New.txt"
    /// </summary>
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
