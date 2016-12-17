using System;

namespace HW5
{
    class Programmer : IDeveloper
    {
        private string firstName;
        private string lastName;
        private string tool;

        public Programmer()
        {
        }

        public Programmer(string firstName, string lastName, string tool)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.tool = tool;
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
            Console.WriteLine("Programmer {0} {1} was created", firstName, lastName);
        }

        public void Destroy()
        {
            firstName = null;
            lastName = null;
            tool = null;
        }
    }
}
