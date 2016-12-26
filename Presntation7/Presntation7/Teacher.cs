using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presntation7
{
    public class Teacher : Staff
    {
        private string subject;
        public Teacher(string name, int salary, string subject) : base(name, salary)
        {
            this.subject = subject;
        }

        override public void Print()
        {
            Console.Write("\tTeacher {0} has salary: ${1}. And he teach {2}", Name, salary, subject);
        }
    }
}
