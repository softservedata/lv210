using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  In Main() method declare Dictionary PhoneBook for keeping pairs PersonName-PhoneNumber. 
//  1) From file "phones.txt" read 9 pairs into PhoneBook. Write only PhoneNumbers into file "Phones.txt".
//  2) Find and print phone number by the given name(name input from console)
//  3) Change all phone numbers, which are in format 80######### into new format +380#########. The result write into file "New.txt"

namespace PhoneBook
{
    class Program
    {
        const string Path = "C:\\Docs\\Anya\\Data\\";
        
        static void Main(string[] args)
        {

            ////  1) From file "phones.txt" read 9 pairs into PhoneBook. Write only PhoneNumbers into file "Phones.txt".
           
            //Dictionary<string, string> phoneNumbers = new Dictionary<string, string>();
            //StreamReader reader = new StreamReader(Program.Path + "phones.txt");
            //using (StreamWriter writer = new StreamWriter(Program.Path + "PhoneNumbers.txt"))
            //{
            //    string line;
            //    while ((line = reader.ReadLine()) != null)
            //    {
            //        //Console.WriteLine(line);
            //        string[] phonePairs = line.Split('-');
            //        phoneNumbers.Add(phonePairs[0].Trim(), phonePairs[1].Trim());
            //        // writer.WriteLine(phonePairs[0]);
            //    }
            //    foreach (KeyValuePair<string, string> item in phoneNumbers)
            //    {
            //        Console.WriteLine("{0} has number {1}", item.Key, item.Value);
            //        writer.WriteLine(item.Value);
            //    }
            //}

            ////  2) Find and print phone number by the given name(name input from console)
            //Console.WriteLine("Enter person's name");
            //string name = Console.ReadLine().Trim();
            //foreach (KeyValuePair<string, string> item in phoneNumbers)
            //{
            //    if (item.Key == name)
            //    {
            //        Console.WriteLine(item.Value);
            //    }
            //}
            //Console.ReadKey();

            ////  3) Change all phone numbers, which are in format 80######### into new format +380#########. The result write into file "New.txt"

            //using (StreamWriter newWriter = new StreamWriter(Program.Path + "New.txt"))
            //{
            //    foreach (KeyValuePair<string, string> item in phoneNumbers)
            //    {
            //        if (item.Value.Substring(0, 2) == "80")
            //        {
            //            newWriter.WriteLine(item.Key + " +3" + item.Value);
            //        }
            //        else
            //        {
            //            newWriter.WriteLine(item.Key + " " + item.Value);
            //        }
            //    }
            //}


            //1) From file "phones.txt" read 9 pairs into PhoneBook. Write only PhoneNumbers into file "Phones.txt".
            PhoneNumberBook phoneBook = new PhoneNumberBook();
            phoneBook.readDataFromTheFile(Path, "phones.txt");
            phoneBook.writeNumbersToTheFile(Path, "OnlyPhones.txt");

            //2) Find and print phone number by the given name(name input from console)
            string name = Console.ReadLine();
            Console.WriteLine(phoneBook.findPhoneNumberByPersonsName(name));

            //3) Change all phone numbers, which are in format 80######### into new format +380#########. The result write into file "New.txt"
            phoneBook.changeFormatNumbers();
            phoneBook.writeDataToTheFile(Path, "NewData.txt");

            phoneBook.printToConsole();

            Console.ReadKey();

        }
    }
}
