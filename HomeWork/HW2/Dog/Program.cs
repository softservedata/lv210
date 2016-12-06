using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2._4
{
    struct Dog
    {
        public string Name;
        public string Mark;
        public int Age;

        public void Tostring()
        {
            Console.WriteLine("Name: {0}", Name);
            Console.WriteLine("Mark: {0}", Mark);
            Console.WriteLine("Age: {0}", Age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            Console.WriteLine("Enter the information about dog: ");
            Console.Write("Name: ");
            dog.Name = Convert.ToString(Console.ReadLine());

            Console.Write("Mark: ");
            dog.Mark = Convert.ToString(Console.ReadLine());

            Console.Write("Age: ");
            dog.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Info: ");
            dog.Tostring();
            

            Console.ReadKey();

        }
    }
}
