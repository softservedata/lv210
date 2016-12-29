using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_task
{
    class Teacher:Staff
    {
        private string subject;
        public override string Name { get { return base.Name + " :Teacher"; } }
        public Teacher(string name, int salary,string subject) : base(name, salary)
        {
            this.subject = subject;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("\t teaches subject {1}",Name,subject);
        }
    }
}
