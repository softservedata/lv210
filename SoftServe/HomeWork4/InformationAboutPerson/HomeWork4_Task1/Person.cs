using System;

namespace HomeWork4_Task1
{
    public class Person
    {
        private string name;
        private int birthYear;

        public Person() { }

        public Person(string _name, int _birthYear)
        {
            name = _name;
            birthYear = _birthYear;

            if (!IsValidAge)
            {
                throw new ArgumentException("Age can't be less than 0, ", "_birthYear");
            }
        }

        public int GetAge()
        {
            int presentYear = DateTime.Now.Year;

            return presentYear - birthYear;
        }

        public static Person Input()
        {
            int birthYear;

            Console.WriteLine("Information about person.");
            Console.Write("Input name for person: ");
            var name = Console.ReadLine();

            Console.Write("Input year of person's birth: ");
            while (!int.TryParse(Console.ReadLine(), out birthYear))
            {
                Console.Write("You can't use characters, please try again: ");
            }
            
            Console.WriteLine();

            return new Person(name, birthYear);
        }

        public void Output()
        {
            Console.WriteLine("Person's name: {0}, age: {1}", name, GetAge());
        }

        public void ChangeName()
        {
            if (GetAge() < 16)
            {
                name = "Very Young";
            }   
        }

        private bool IsValidAge
        {
            get
            {
                return (GetAge() > 0);
            }
        }
    }
}
