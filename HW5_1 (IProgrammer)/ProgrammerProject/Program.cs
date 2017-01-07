using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerProject
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IDeveloper> developers = new List<IDeveloper>();
            IDeveloper builder1 = new Builder("Application 1");
            IDeveloper developer1 = new Developer("Ivan", "Program1");
            developers.Add(builder1);
            developers.Add(developer1);
            foreach(var item in developers)
            {
                item.Create();
                item.Destroy();
            }
            Console.ReadKey();
        }
    }
}
