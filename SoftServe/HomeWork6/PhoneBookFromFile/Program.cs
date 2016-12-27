using System;
using System.Collections.Generic;

namespace PhoneBookFromFile
{
    /// <summary>
    /// Create Console Application project in VS.
    /// In Main() method declare Dictionary PhoneBook for keeping pairs PersonName-PhoneNumber
    /// 1) From file "phones.txt" read 9 pairs into PhoneBook.Write only PhoneNumbers into file "Phones.txt".
    /// 2) Find and print phone number by the given name(name input from console)
    /// 3) Change all phone numbers, which are in format 80######### into new format +380#########. 
    /// The result dictionary write into file "New.txt"
    /// </summary>
    class Program
    {
        static string pathForReadFile = @"C:\Users\Dima\Documents\Visual Studio 2015\Projects\SoftServe\HomeWork6\Files\phones.txt";
        static string pathForWriteToFileNumbers = @"C:\Users\Dima\Documents\Visual Studio 2015\Projects\SoftServe\HomeWork6\Files\PhonesOnly.txt";
        static string pathForWriteToFileDictionary = @"C:\Users\Dima\Documents\Visual Studio 2015\Projects\SoftServe\HomeWork6\Files\New.txt";

        static void Main(string[] args)
        {
            Dictionary<string, string> phoneBook;
            PhoneBook book = new PhoneBook();

            phoneBook = book.ReadDictionaryFromFile(pathForReadFile);

            book.WriteOnlyNumbersToFile(phoneBook, pathForWriteToFileNumbers);

            Console.Write("Input name for value : ");
            var name = Console.ReadLine();

            try
            {
                var phoneNumber = book.GetValueByKey(phoneBook, name);

                Console.WriteLine("Phone number for name : \'{0}\' is - {1}", name, phoneNumber);
            }
            catch
            {
                throw;
            }

            book.ChangePhoneFormat(phoneBook);

            book.WriteDictionaryToFile(phoneBook, pathForWriteToFileDictionary);

            book.Output(phoneBook);

            Console.ReadKey();
        }
    }
}
