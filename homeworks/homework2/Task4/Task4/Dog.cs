using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    struct Dog
    {
        public string Name;
        public int Age;
        public string Mark;
        public void Input()
        {
            Console.Write("Dogs name:");
            Name = Console.ReadLine();
            Console.Write("Dogs age:");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Dogs mark:");
            Mark = Console.ReadLine();
        } 
        public override string ToString()
        {
            return "Dogs name:"+Name+"\nDogs mark:"+Mark+"\nAge:"+Age;
        }
    }
}
    

