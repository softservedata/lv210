using System;

namespace HwFive
{
    public class Programmer : IDeveloper
    {
        private string prgTool;

        public string Tool
        {
            get
            {
                return this.prgTool;
            }
            set
            {
                this.prgTool = value;
            }
        }

        public void Create()
        {
            Console.WriteLine("Programmer: Create() method executes using tool {0}", Tool);
            Console.ReadKey();
        }

        public void Destroy()
        {
            Console.WriteLine("Programmer: Destroy() method executes using tool {0}", Tool);
            Console.ReadKey();
        }
    }
}
