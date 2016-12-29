using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_task
{
    class Staff:Person
    {
        private int salary;
        public Staff(string name, int salary) : base(name)
        { this.salary = salary; }
        public override string Name { get { return base.Name + " Staff"; } }
        public override void Print()
        {
            Console.Write("\tPerson {0} has salary: ${1}", Name, this.salary);
        }
    }
}
