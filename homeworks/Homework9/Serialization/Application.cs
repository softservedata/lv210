using System;

namespace Serialization
{
    class Application
    {
        static void Main(string[] args)
        {
            Person person = new Person("Roman",new DateTime(1994, 05, 26));
            CustomSerializer.SerializeToBinary(person, "Person.bin");

            Console.ReadLine();
        }
    }
}
