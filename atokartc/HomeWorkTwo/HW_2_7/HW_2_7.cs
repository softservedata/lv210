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
            public string name;
            public string mark;
            public int age;

            public static int GetPositiveValueFromConsole()
            {
                int readedVar = 0;
                bool isIntEntered = Int32.TryParse(Console.ReadLine(), out readedVar);

                if (isIntEntered && readedVar >= 0)
                {
                    return readedVar;
                }
                else
                {
                    Console.WriteLine("Please, enter a positive integer");
                    return GetPositiveValueFromConsole();
                }
            }

            public void Inputs()
            {
                Console.WriteLine("Enter dog's name:");
                name = Console.ReadLine();

                Console.WriteLine("Enter dog's mark:");
                mark = Console.ReadLine();

                Console.WriteLine("Enter dog's age:");
                age = GetPositiveValueFromConsole();
            }
            public override string ToString()
            {
                return String.Format("Dogs name: {0}{3} Dogs mark:{1}{3} Age: {2}{3}", name, mark, age, Environment.NewLine);
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
