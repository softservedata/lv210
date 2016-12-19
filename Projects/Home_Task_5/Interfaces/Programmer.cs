using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Programmer : IDeveloper
    {
        // Prop
        public string Name { get; set; }
        public string Tool { get; set; }

        // Ctor
        public Programmer() { }

        public Programmer(string name, string tool)
        {
            Name = name;
            Tool = tool;
        }

        // Methods
        public void Create()
        {
            Console.WriteLine("{0} creates programs using {1} language.", Name, Tool);
        }

        public void Destroy()
        {
            Console.WriteLine("{0} destroy programs written on {1} language.", Name, Tool);
        }
    }
}
