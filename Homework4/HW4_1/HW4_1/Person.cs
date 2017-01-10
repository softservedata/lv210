using System;

namespace HW4_1
{
    class Person
    {
        private string name;
        private DateTime birthDate;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public DateTime BirthYear
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }
        public Person() { }
        public Person(string n, DateTime b)
        {
            name = n;
            birthDate = b;
        }
        public int Age ()
        {
            return DateTime.Now.Year - this.birthDate.Year;
        }
        public void Input ()
        {
            Console.Write("Please enter person's name: ");
            this.name = Console.ReadLine();
            Console.Write("Please enter person's birth date: ");
            this.birthDate = Convert.ToDateTime(Console.ReadLine());
        }
        public string Output ()
        {
            return "This person has name "+this.name+". His birthyear is "+ Convert.ToString(this.birthDate);
        }
        public void ChangeName(string n)
        {
            this.name = n;
        }
    }
}
