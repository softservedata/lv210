using Homework4;
using System;
namespace Homework4_b
{
    class Program
    {
        static NewPerson CreateNewPerson()
        {

            Console.WriteLine("Input name and  birth date: (use ',' as delimiter, date format(dd.mm.yyyy)");
            string[] input = Console.ReadLine().Split(',');
            string name = input[0];
            DateTime birthDate = DateTime.Parse(input[1]);
            return new NewPerson(name, birthDate);

        }
      
        static void Main(string[] args)
        {
            NewPerson[] personsList = new NewPerson[5];
            for (int i = 0; i < personsList.Length; i++)
            {
                personsList[i] = CreateNewPerson();
                
            }

            for (int i = 0; i < personsList.Length; i++)
            {
                if (personsList[i].Age() < 16)
                {
                    personsList[i].ChangeName("Very young");
                }
                personsList[i].Output();
              
            }
            Console.ReadKey();
           
        }

    }

}
