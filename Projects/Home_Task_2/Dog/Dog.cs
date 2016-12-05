using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dog
{
    struct Dog
    {
        public string Name;
        public string Mark;
        public int Age;

        public Dog(string name, string mark, int age)
        {
            Name = name;
            Mark = mark;
            Age = age;
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return "\nDog info: \n" + Name + ", " + Age + " years old. Mark - " + Mark+"\n";
        }
    }
}
