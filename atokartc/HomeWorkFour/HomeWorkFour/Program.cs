using System;

namespace HomeWorkFour
{
    class Program
    {
        public static void Main()
        {
            Person[] personsList = new Person[3];

            for (int i = 0; i < personsList.Length; i++)
            {
                personsList[i] = new Person();
                personsList[i].Input();

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
