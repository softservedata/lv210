using System;
using System.Collections.Generic;

namespace HW5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDeveloper> DevelopersList = new List<IDeveloper>();

            IDeveloper Builder1 = new Builder("James", "Bond", "Hammer");
            IDeveloper Builder2 = new Builder("Martin", "Luther", "Ax");
            IDeveloper Builder3 = new Builder("Guy", "Fawkes", "Dynamite");

            IDeveloper Programmer1 = new Programmer("Fabian", "Hambuchen", "Mouse");
            IDeveloper Programmer2 = new Programmer("Epke", "Zonderland", "Keyboard");
            IDeveloper Programmer3 = new Programmer("Kazuma", "Kaya", "Touch screen");

            DevelopersList.Add(Builder1);
            DevelopersList.Add(Builder2);
            DevelopersList.Add(Builder3);

            DevelopersList.Add(Programmer1);
            DevelopersList.Add(Programmer2);
            DevelopersList.Add(Programmer3);

            foreach (var IDeveloper in DevelopersList)
            {
                IDeveloper.Create();   
            }
            Console.ReadLine();
        }
    }
}
