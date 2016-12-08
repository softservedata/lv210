using System;

namespace HomeWork4_Task1
{
    class Person
    {
        private string name;
        private DateTime birthDate;

        public Person() { }

        public Person(string _name, DateTime _birthDate)
        {
            name = _name;
            birthDate = _birthDate;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
        }

        public int Age()
        {
            return DateTime.Now.Year - BirthDate.Year;
        }

        public static Person Input()
        {
            Console.WriteLine("Information about person.");
            Console.Write("Input name for person: ");
            var name = Console.ReadLine();

            Console.Write("Input year of person's birth: ");
            var date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine();

            return new Person(name, date);
        }

        public void Output()
        {
            Console.WriteLine("Person's name: {0}, age: {1}", Name, Age());
        }

        public void ChangeName()
        {
            if (Age() < 16)
            {
                name = "Very Young";
            }
        }
    }
}
