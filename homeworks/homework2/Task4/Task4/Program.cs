using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class DogsInformation
    {
        static void Main(string[] args)
        {
            Dog myDog=new Dog();
            myDog.Input();
            Console.WriteLine(myDog);
            Console.ReadKey();
        }
    }
}
