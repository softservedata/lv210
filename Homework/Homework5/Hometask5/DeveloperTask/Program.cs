using System;
using System.Collections.Generic;

namespace DeveloperTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var listOfDevelopers = new List<IDeveloper>();
            listOfDevelopers.Add(new Programmer("Orest","Tkachuk","CloudMine", new DateTime(1995,10,15)));
            listOfDevelopers.Add(new Builder("Andrew", "Dunas", "Viximo", 2000));

            foreach (var developer in listOfDevelopers)
            {
                Console.WriteLine(developer.Create());
                Console.WriteLine(developer.Destroy());
            }

            Console.ReadLine();
        }
    }
}
