using System;

namespace AppropriateFunction
{
    public class Function
    {
        public struct Dog
        {
            public string Name;
            public string Mark;
            public int Age;

            public void ToString()
            {
                Console.WriteLine("\nInformation about dog: it name is {0}, it mark is {1}, it age is {2}.", Name, Mark, Age);
            }
        }

        public static void GetInformationAboutDog()
        {
            Console.WriteLine("Enter data about your dog:");

            Console.Write("Name - ");
            var name = Console.ReadLine();

            Console.Write("Mark - ");
            var mark = Console.ReadLine();

            Console.Write("Age - ");
            var input_age = Console.ReadLine();

            int age;

            var isInputAgeValid = int.TryParse(input_age, out age);
            var isAgeValid = age > 0;

            if (isInputAgeValid && isAgeValid)
            {
                Dog myDog;

                myDog.Name = name;
                myDog.Mark = mark;
                myDog.Age = age;

                myDog.ToString();
            }
            else
            {
                Console.WriteLine("Incorrect value!\n");
            }
            Console.ReadLine();
           
        }

    }
}