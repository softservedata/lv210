using System;

namespace HomeWorkTwo
{
    class HW_2_7
    {
        /// <summary>
        /// Create Console Application project in VS.
        /// In method Main() write code for solving next task:
        /// declare struct Dog with fields Name, Mark, Age. Decleare variable myDog of Dog type and read values for it.Output myDos into console.(Decleare method ToString in struct)
        /// </summary>
        public struct Dog
        {
            public string Name;
            public string Mark;
            public int Age;


            public void Inputs()
            {
                Console.WriteLine("Enter dog's name:");
                Name = Console.ReadLine();
                Console.WriteLine("Enter dog's mark:");
                Mark = Console.ReadLine();
                Console.WriteLine("Enter dog's age:");
                Age = Convert.ToInt32(Console.ReadLine());
            }
            public override string ToString()
            {
                return "Dogs name:" + Name + "\nDogs mark:" + Mark + "\nAge:" + Age;
            }
        }

        static void Main()
        {
            Dog myDog = new Dog();
            myDog.Inputs();
            Console.WriteLine(myDog);
            Console.ReadKey();
        }
    }
}
