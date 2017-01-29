using System;

namespace HwSixExceptions
{
    class Program
    {
        public const string READFROMFILE = "phones.txt";
        public const string WRITENUMBERSTOFILE = "OnlyPhones.txt";

        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.ReadFromFile(READFROMFILE);
            phoneBook.Output();

            phoneBook.WritePhoneNumbersToFile(WRITENUMBERSTOFILE);

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
