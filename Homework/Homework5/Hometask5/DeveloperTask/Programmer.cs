using System;

namespace DeveloperTask
{
    public class Programmer : IDeveloper
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Tool { get; set; }     
        public DateTime Birthday { get; private set; }
        public Programmer(string name, string surname, string tool, DateTime birthDay)
        {
            this.Name = name;
            this.Surname = surname;
            this.Tool = tool;
            this.Birthday = birthDay;
        }
        public string Create()
        {
            return "";//$"Programmer {Name} {Surname} is created.";
        }

        public string Destroy()
        {
            var currentProgrammerData = " ";//$"Programmer {Name} {Surname} is destroyed.";
            this.Name = null;
            this.Surname = null;
            this.Tool = null;
            this.Birthday = DateTime.MinValue;
            return currentProgrammerData;
        }

    }
}
