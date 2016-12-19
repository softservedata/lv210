using System;
using System.Collections.Generic;

namespace WorkWithInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            IDeveloper developer = new Programmer("Dima", "VS2015");
            IDeveloper builder = new Builder("Steam", "Taras");

            List<IDeveloper> list = new List<IDeveloper>();

            list.Add(developer);
            list.Add(builder);

            foreach (var item in list)
            {
                item.Create();
                item.Destroy();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
