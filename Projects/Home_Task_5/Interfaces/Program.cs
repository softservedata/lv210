using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    /// <summary>
    /// + Create interface IDeveloper with property Tool, methods Create() and Destroy()
    /// + Create two classes Programmer and Builder, which implement this interface.
    /// + Create List of IDeveloper and add some Programmer and Builder to it. 
    /// + Call Create() and Destroy() methods, property Tool for all of it 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            IDeveloper firstProgrammer = new Programmer("Nick", "Java");
            IDeveloper secondProgrammer = new Programmer("James", "C++");

            IDeveloper firstBuilder = new Builder("Ivan", "Hammer");
            IDeveloper secondBuilder = new Builder("Oleg", "Ax");

            List<IDeveloper> developersList = new List<IDeveloper>();

            developersList.Add(firstProgrammer);
            developersList.Add(secondProgrammer);
            developersList.Add(firstBuilder);
            developersList.Add(secondBuilder);

            foreach (var developer in developersList)
            {
                developer.Create();
                developer.Destroy();
                Console.WriteLine();
            }
        }
    }
}
