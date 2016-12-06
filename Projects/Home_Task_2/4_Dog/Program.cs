using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog
{
    /// <summary>
    /// Declare struct Dog with fields Name, Mark, Age. 
    /// Decleare variable myDog of Dog type and read values for it.
    /// Output myDos into console.(Decleare method ToString in struct)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Reading info from console
            Console.Write("Enter the name of your dog: ");
            string n = Console.ReadLine();

            Console.Write("Enter the mark of your dog: ");
            string m = Console.ReadLine();

            Console.Write("Enter the age of your dog: ");
            int a = Convert.ToInt32(Console.ReadLine());

            //Create new var myDog
            Dog myDog = new Dog(n, m, a);

            //Print result
            Console.WriteLine(myDog);
        }
    }
}
