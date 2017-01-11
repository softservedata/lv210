using System;
using System.Collections.Generic;

namespace HW5_1
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

            IDeveloper firstBuilder = new Builder("James", "Bond", "Hammer");
            IDeveloper secondBuilder = new Builder("Martin", "Luther", "Ax");
            IDeveloper thirdBuilder = new Builder("Guy", "Fawkes", "Dynamite");

            IDeveloper firstProgrammer = new Programmer("Fabian", "Hambuchen", "NodeJS");
            IDeveloper secondProgrammer = new Programmer("Epke", "Zonderland", ".NET Core");
            IDeveloper thirdProgrammer = new Programmer("Kazuma", "Kaya", "Angular");

            DevelopersList.Add(firstBuilder);
            DevelopersList.Add(secondBuilder);
            DevelopersList.Add(thirdBuilder);

            DevelopersList.Add(firstProgrammer);
            DevelopersList.Add(secondProgrammer);
            DevelopersList.Add(thirdProgrammer);

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
