using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_task
{
    class StaffCreator
    {
        public static void Main()
        {
            List<Person> personList=new List<Person>();
            personList.Add(new Person("John"));
            personList.Add(new Staff("George",200));
            personList.Add(new Developer("Roman",300,"junior"));
            personList.Add(new Teacher("Andriy",500,"Math"));
            
            foreach (Person person in personList)
            {
                
                person.Print();
                Console.WriteLine();
            }
            Console.WriteLine("Input persons name");
            string name = Console.ReadLine();

            foreach (Person person in personList)
            {
                if(person.Name.Contains(name)) person.Print();
               ;
            }
            Console.ReadKey();


        }
    }
}
