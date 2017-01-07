using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammerProject
{
    class Developer : IDeveloper
    {
        private string name;
        private string tool;
        public Developer(string enteredName, string enteredTool)
        {
            name = enteredName;
            tool = enteredTool;
        }
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
        public string Tool
        {
            get
            {
                return tool;
            }

            set
            {
                tool=value;
            }
        }

        public void Create()
        {
            Console.WriteLine("/nDeveloper {0} created {1}", Name, Tool);
        }

        public void Destroy()
        {
            Console.WriteLine("/nDeveloper {0} destroyed {1}", Name, Tool);
        }
    }
}
