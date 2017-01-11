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
            List<IDeveloper> DevelopersList = new List<IDeveloper>();

            DevelopersList.Add(new Builder("James", "Bond", "Hammer"));
            DevelopersList.Add(new Builder("Guy", "Fawkes", "Dynamite"));

            DevelopersList.Add(new Programmer("Fabian", "Hambuchen", "NodeJS"));
            DevelopersList.Add(new Programmer("Epke", "Zonderland", ".NET Core"));

            return DevelopersList;
        }

        static void Main(string[] args)
        {
            List<IDeveloper> DevelopersList = new List<IDeveloper>();
            DevelopersList = CreateDevelopersList();

            foreach (var item in DevelopersList)
            {
                item.Create();   
            }
            Console.ReadLine();
        }
    }
}
