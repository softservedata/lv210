using System;

namespace DevelopersTask
{
    class Programmer : IDeveloper
    {
        private string firstName;
        private string lastName;
        private string tool;

        public string Tool { get; }

        public Programmer()
        {
        }

        public Programmer(string firstName, string lastName, string tool)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.tool = tool;
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
