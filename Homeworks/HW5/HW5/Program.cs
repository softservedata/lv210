using System;
using System.Collections.Generic;

namespace HW5_1
{
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
