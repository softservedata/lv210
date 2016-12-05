using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace CreatingClassPerson
{
 
    /// <summary>
    /// This program creates class Person.
    /// User can enter information about 5 persons. 
    /// After that age of these persons is calculated and shown at the console.
    /// If age is less than 16, person's name is changed to "Very young".
    /// </summary>
    
    class Program
    {
        public static Person CreatePerson(string number)
        {
            Console.WriteLine("\nPerson {0}:", number);
            Console.Write("\nName - ");
            var inputName = Console.ReadLine();

            Console.Write("Date of birth - ");
            var inputDate = Console.ReadLine();
            DateTime date; 

            bool isValid = DateTime.TryParse(inputDate, out date);

            if (isValid)
                return new Person(inputName, date);
            else
            {
                Console.WriteLine("Incorrect format of date. Person is not created.");
                return null;

            }
        }

        public static void Main(string[] args)
        {
            List<Person> PersonsList = new List<Person>();

            Console.WriteLine("Please, enter information about five persons.");
            Console.WriteLine("(Date of birth enter in format xx.xx.xxxx)");

            for(int i=0; i<5; i++)
            {
                Person newPerson = CreatePerson((i + 1).ToString());
                if (newPerson != null) PersonsList.Add(newPerson);
            }

            Console.WriteLine("\nInformation about all persons:\n");

            for (int i = 0; i < PersonsList.Count; i++)
            {
                Console.WriteLine(PersonsList[i].ToString());
            }


            Console.WriteLine("\nChanged information about all persons:\n");
            for (int i = 0; i < PersonsList.Count; i++)
            {
                    if (PersonsList[i].Age() < 16) PersonsList[i].ChangeName("Very young");
                    Console.WriteLine(PersonsList[i].ToString());
            }

            Console.ReadLine();
        }
    }
}
