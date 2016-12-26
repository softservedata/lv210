using System;

namespace Presntation7
{
    public class Staff : Person
    {
        private int salary;

        public Staff(string name, int salary) : base(name)
        {
            this.salary = salary;
        }

        override public string Name
        {
            get
            {
                return base.Name + "Staff";
            }
        }

        override public void Print()
        {
            Console.Write("\tPerson {0} has salary: ${1}", Name, salary);
        }
    }
}
