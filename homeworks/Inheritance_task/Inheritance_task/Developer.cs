using System;

namespace Inheritance_task
{
    class Developer:Staff
    {
        private string level;
        public override string Name { get { return base.Name + " :Developer "; } }
        public Developer(string name, int salary,string level) : base(name, salary)
        {
            this.level = level;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine("\t level: {0}",level);
        }
    }
}
