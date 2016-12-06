using System;

namespace HomeWork2_Task4
{
    class Program
    {
        /// <summary>
        /// Task Description : declare struct Dog with fields Name, Mark, Age. 
        /// Decleare variable myDog of Dog type and read values for it.
        /// Output myDos into console.(Decleare method ToString in struct) 
        /// </summary>

        static void Main(string[] args)
        {
            Dog myDog = new Dog();

            Console.Write("Input dog's name : ");
            myDog.Name = Console.ReadLine();

            Console.Write("Input dog's mark : ");
            myDog.Mark = Console.ReadLine();

            Console.Write("Input dog's age : ");
            myDog.Age = int.Parse(Console.ReadLine());

            Console.WriteLine(myDog);

            Console.ReadKey();
        }
    }
}
