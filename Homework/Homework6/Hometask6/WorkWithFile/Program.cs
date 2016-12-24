using System;
using System.IO;

namespace WorkWithFile
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                var phoneBook = new PhoneBook();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "phones.txt");

                phoneBook.ReadDataFromFile(path);
                phoneBook.ToFile("PhoneNumbers.txt");

                Console.WriteLine("Please, enter the name of person who's phone number you want to see:");
                var personName = Console.ReadLine();

                Console.WriteLine($"{personName} - {phoneBook.FindNumberByPersonName(personName)}");

                var format = @"^80\d{9}";

                phoneBook.ChangeFormatOfNumbers(format);
                phoneBook.ToFile("Changed format.txt");
            }
            catch (Exception ex)
            {               
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}