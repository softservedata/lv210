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
    class Program
    {
        static List<IDeveloper> CreateDevelopersList()
        {
            var developersList = new List<IDeveloper>();

            developersList.Add(new Builder("James", "Bond", "Hammer"));
            developersList.Add(new Builder("Guy", "Fawkes", "Dynamite"));

            developersList.Add(new Programmer("Fabian", "Hambuchen", "NodeJS"));
            developersList.Add(new Programmer("Epke", "Zonderland", ".NET Core"));

            return developersList;
        }

        static void Main(string[] args)
        {
            List<IDeveloper> developersList = new List<IDeveloper>();
            developersList = CreateDevelopersList();

            foreach (var item in developersList)
            {
                item.Create();   
            }
            Console.ReadLine();
        }
    }
}
