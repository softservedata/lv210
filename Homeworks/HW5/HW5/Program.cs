using System;
using System.Collections.Generic;

namespace HW5_1
{
    /// <summary>
    /// Create interface IDeveloper with property Tool, methods Create() and Destroy()
    /// Create two classes Programmer and Builder, which implement this interface.
    ///  Create List of IDeveloper and add some Programmer and Builder to it. 
    ///  Call Create() and Destroy() methods, property Tool for all of it
    /// </summary>
    class Program
    {
        static List<IDeveloper> CreateList()
        {
            List<IDeveloper> DevelopersList = new List<IDeveloper>();

            IDeveloper Builder1 = new Builder("James", "Bond", "Hammer");
            IDeveloper Builder2 = new Builder("Martin", "Luther", "Ax");
            IDeveloper Builder3 = new Builder("Guy", "Fawkes", "Dynamite");

            IDeveloper Programmer1 = new Programmer("Fabian", "Hambuchen", "NodeJS");
            IDeveloper Programmer2 = new Programmer("Epke", "Zonderland", ".NET Core");
            IDeveloper Programmer3 = new Programmer("Kazuma", "Kaya", "Angular");

            DevelopersList.Add(Builder1);
            DevelopersList.Add(Builder2);
            DevelopersList.Add(Builder3);

            DevelopersList.Add(Programmer1);
            DevelopersList.Add(Programmer2);
            DevelopersList.Add(Programmer3);

            return DevelopersList;
        }

        static void Main(string[] args)
        {
            List<IDeveloper> DevelopersList = new List<IDeveloper>();
            DevelopersList = CreateList();

            foreach (var IDeveloper in DevelopersList)
            {
                IDeveloper.Create();   
            }
            Console.ReadLine();
        }
    }
}
