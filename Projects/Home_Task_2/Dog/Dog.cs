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
        public string Name;
        public string Mark;
        public int Age;

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
            Console.ForegroundColor = ConsoleColor.Green;
            return "\n-----Dog info-----\n" + Name + ", " + Age + " years old. Mark - " + Mark + "\n";
        }
    }
}
