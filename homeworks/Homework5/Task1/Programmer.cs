using System;

namespace Task1
{
    class Programmer : IDeveloper
    {
        public string Tool { get; set; }

        public void Create()
        {
            Console.WriteLine("Programmer with tool {0} is created", Tool);
        }

        public void Destroy()
        {
            Console.WriteLine("Programmer is destroyed");
        }
    }
}
