using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework4
{
    class NewPerson
    {
        private string name;
        private DateTime birthDate;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
        }
       public NewPerson() { }
        public NewPerson(string name,DateTime birthDate)
        {
            this.name = name;
            this.birthDate = birthDate;
        }

        public int Age()
        {
            return DateTime.Now.Year - birthDate.Year;
        }
      
        public void Output()
        {
            Console.WriteLine("Name: {0}", name);
            Console.WriteLine("birth year: {0}", birthDate);
            Console.WriteLine("Age: {0}", Age());
                    }
        public void ChangeName(string newName)
        {
            name = newName;
        }
        public void Input()
        {
           
        }
    }
}
