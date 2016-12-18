using System;
using System.Collections.Generic;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDeveloper> list = new List<IDeveloper>();
            list.Add(new Programmer());
            list.Add(new Builder());

            list[0].Tool = "Visual Studio";
            list[1].Tool = "Build tool";

            foreach (IDeveloper developer in list)
            {
                developer.Create();
                developer.Destroy();
            }

            Console.ReadKey();
        }
    }
}
