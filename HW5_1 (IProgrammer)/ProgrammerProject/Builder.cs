using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerProject
{
    class Builder : IDeveloper
    {
        private string tool;
        public Builder(string enteredTool)
        {
            tool = enteredTool;
        }
        public string Tool
        {
            get
            {
                return tool;
            }
            set
            {
                tool = value;
            }
        }
        public void Create()
        {
            Console.WriteLine("\nBuilder made a {0} ", Tool);
        }
        public void Destroy()
        {
            Console.WriteLine("\nBuilder destroyed a {0} ", Tool);
        }
    }
}
