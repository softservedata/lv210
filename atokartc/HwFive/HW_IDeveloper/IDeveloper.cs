using System;
using System.Collections.Generic;

namespace HwFive
{
    public interface IDeveloper
    {
        string Tool { get; set; }

        void Create();
        void Destroy();
    }

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

    public class Builder : IDeveloper
    {
        private string bldTool;

        public string Tool
        {
            get
            {
                return this.bldTool;
            }
            set
            {
                this.bldTool = value;
            }
        }

        public void Create()
        {
            Console.WriteLine("Builder: Create() method executes using tool {0}", Tool);
            Console.ReadKey();
        }

        public void Destroy()
        {
            Console.WriteLine("Builder: Destroy() method executes using tool {0}", Tool);
            Console.ReadKey();
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            List<IDeveloper> workers = new List<IDeveloper>();
            workers.Add(new Programmer() { Tool = "VS2012" });
            workers.Add(new Programmer() { Tool = "VS2015" });
            workers.Add(new Builder() { Tool = "Perforator1" });
            workers.Add(new Builder() { Tool = "Perforator2" });

            foreach (IDeveloper worker in workers)
            {
                worker.Create();
                worker.Destroy();
            }
        }
    }
}
