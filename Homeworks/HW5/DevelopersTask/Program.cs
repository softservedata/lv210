using System;
using System.Collections.Generic;

namespace DevelopersTask
{
    internal class Program
    {
        private static IList<IDeveloper> CreateDevelopersList()
        {
            var developersList = new List<IDeveloper>
            {
                new Builder("James", "Bond", "Hammer"),
                new Builder("Guy", "Fawkes", "Dynamite"),
                new Programmer("Fabian", "Hambuchen", "NodeJS"),
                new Programmer("Epke", "Zonderland", ".NET Core")
            };
            return developersList;
        }

        private static void Main()
        {
            var developersList = CreateDevelopersList();
            if (developersList == null)
            {
                throw new ArgumentNullException(nameof(developersList));
            }
            foreach (var item in developersList)
            {
                item.Create();
                item.Destroy();                
            }
            Console.ReadLine();
        }
    }
}
