using System;

namespace InformationAboutPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var person = PersonBuilder.BuildPerson();
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
