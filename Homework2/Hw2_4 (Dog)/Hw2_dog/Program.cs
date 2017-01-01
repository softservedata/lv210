using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw2_dog
{
    public struct Dog
    {
        public string Name;
        public string Mark;
        public string Age;
        public string toString()
        {
            string r ="Dog has name "+ this.Name + " and mark " + this.Mark + " and age " + this.Age;
            return r;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Dog myDog;
            Console.Write("Enter dog name: ");
            myDog.Name = Console.ReadLine();
            Console.Write("Enter dog mark: ");
            myDog.Mark = Console.ReadLine();
            Console.Write("Enter dog age: ");
            myDog.Age = Console.ReadLine();
            Console.WriteLine(myDog.toString());
            Console.ReadKey();
        }
    }
}
