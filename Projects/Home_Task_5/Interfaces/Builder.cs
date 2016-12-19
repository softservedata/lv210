using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    class Builder : IDeveloper
    {
        // Propertis
        public string Name { get; set; }
        public string Tool { get; set; }

        // Ctor
        public Builder() { }

        public Builder(string name, string tool)
        {
            Name = name;
            Tool = tool;
        }

        // Methods
        public void Create()
        {
            Console.WriteLine("{0} creates buildings using {1} tool.", Name, Tool);
        }

        public void Destroy()
        {
            Console.WriteLine("{0} destroy buildings using {1} tool.", Name, Tool);
        }
    }
}
