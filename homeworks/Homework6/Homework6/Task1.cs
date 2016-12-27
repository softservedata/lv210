using System;

namespace Homework6
{
    class Task1
    {
        public static void Main()
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.ReadFromFile("phones.txt");
            phoneBook.Output();

            phoneBook.WritePhoneNumbersToFile("OnlyPhones.txt");

            string findNumber = phoneBook.FindNumber();
            Console.WriteLine(findNumber);

            Console.WriteLine("\nNumbers in +38 format");
            phoneBook.ChangeFormat();

            phoneBook.WriteToFile();
            phoneBook.Output();
            Console.ReadKey();
        }
    }
}
