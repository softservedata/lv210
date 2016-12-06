using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog
{
    struct Dog
    {
        //fields
        string Name;
        string Mark;
        int Age;

        //constructor
        public Dog(string name, string mark, int age)
        {
            Name = name;
            Mark = mark;
            Age = age;
        }

        //override ToString() method
        public override string ToString()
        {
            return "\n-------Dog info-------\n" + Name + ", " + Age + " years old. Mark - " + Mark + "\n";
        }
    }
}
