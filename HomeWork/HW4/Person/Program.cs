using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    class Program
    {
        static void Main(string[] args)
        {
            Person[] persons = new Person[5];

            persons[0] = new Person("Andrew", 2000);
            persons[1] = new Person("Roman", 1996);
            persons[2] = new Person("Ivan", 1984);
            persons[3] = new Person("Oleg", 2006);
            persons[4] = new Person("Pavlo", 1999);

            for(int i = 0; i < persons.Length; i++)
            {
                if(persons[i].Age() < 16)
                {
                    persons[i].ChangeName("Very Young");
                }
                persons[i].Output();
            }
            //
            PersonNEw[] personsNew = new PersonNEw[5];

            personsNew[0] = new PersonNEw("Andrew", new DateTime(2000, 12, 31));
            personsNew[1] = new PersonNEw("Roman", new DateTime(1996, 10, 13));
            personsNew[2] = new PersonNEw("Ivan", new DateTime(1984, 03, 22));
            personsNew[3] = new PersonNEw("Oleg", new DateTime(2006, 01, 11));
            personsNew[4] = new PersonNEw("Pavlo", new DateTime(1999, 02, 21));

            for (int i = 0; i < personsNew.Length; i++)
            {
                if (personsNew[i].Age() < 16)
                {
                    personsNew[i].ChangeName("Very Young");
                }
                personsNew[i].Output();
            }

            Console.ReadKey();
        }
    }
}
