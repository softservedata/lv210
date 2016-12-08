using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationAboutPerson
{
    class Program
    {
        public static string ReadName()
        {
            Console.WriteLine("What is your name?");
            var name = Console.ReadLine();

            return name;
        }

        public static string ReadAge(string name)
        {
            Console.WriteLine("\nHow old are you, {0}?", name);
            var age = Console.ReadLine();

            return age;
        }
        static void Main(string[] args)
        {
            try
            {
                var name = ReadName();
                name = name.Replace(string.Format(" "), string.Empty);
                var readedAge = ReadAge(name);
                var dataParser = new DataParser();
                var age = dataParser.Parse(readedAge);
                var person = new Person(name,age);

                Console.WriteLine(person);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
