using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_task
{
  public  class Person
    {
        private string name;
        public Person(string name)
        { this.name = name; }
        virtual public string Name { get { return name; } }
        virtual public void Print()
        {
            Console.Write("Name: {0}", this.name);
        }

    }
}
