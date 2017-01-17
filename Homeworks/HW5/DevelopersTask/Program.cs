using System;
using System.Collections.Generic;

namespace DevelopersTask
{
    /// <summary>
    /// Create interface IDeveloper with property Tool, methods Create() and Destroy()
    /// Create two classes Programmer and Builder, which implement this interface.
    /// Create List of IDeveloper and add some Programmer and Builder to it. 
    /// Call Create() and Destroy() methods, property Tool for all of it
    /// </summary>
    internal class Program
    {
        private static List<IDeveloper> CreateDevelopersList()
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
            }
            Console.ReadLine();
        }
    }
}
