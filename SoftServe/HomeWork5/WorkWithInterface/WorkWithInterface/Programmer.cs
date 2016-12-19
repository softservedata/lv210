using System;

namespace WorkWithInterface
{
    class Programmer : IDeveloper
    {
        private string name;
        public string Tool { get; set; }

        public Programmer(string name, string tool)
        {
            this.name = name;
            Tool = tool;
        }

        public void Create()
        {
            Console.WriteLine("Programmer {0} create some applications using {1}.", name, Tool);
        }

        public void Destroy()
        {
            Console.WriteLine("Programmer {0} destroy some applications using {1}.", name, Tool);
        }
    }
}
