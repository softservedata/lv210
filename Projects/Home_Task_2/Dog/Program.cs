using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog
{
    class Program
    {
        static void Main(string[] args)
        {
            //declare struct Dog with fields Name, Mark, Age. 
            //Decleare variable myDog of Dog type and read values for it.
            //Output myDos into console.(Decleare method ToString in struct)
            
            Console.Write("Enter the name of your dog: ");
            string n = Console.ReadLine();
            Console.Write("Enter the mark of your dog: ");
            string m = Console.ReadLine();
            Console.Write("Enter the age of your dog: ");
            int a = Convert.ToInt32(Console.ReadLine());

            Dog myDog = new Dog(n,m,a);
            Console.WriteLine(myDog);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
}
