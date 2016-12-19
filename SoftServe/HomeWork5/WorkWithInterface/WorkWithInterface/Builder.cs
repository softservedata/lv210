using System;

namespace WorkWithInterface
{
    class Builder : IDeveloper
    {
        private string name;
        public string Tool { get; set; }

        public Builder(string tool, string name)
        {
            Tool = tool;
            this.name = name;
        }
        public void Create()
        {
            Console.WriteLine("Tool {0} created by some programmer {1}.", Tool, name);
        }

        public void Destroy()
        {
            Console.WriteLine("Tool {0} destroyed by some programmer {1}.", Tool, name);
        }
    }
}
