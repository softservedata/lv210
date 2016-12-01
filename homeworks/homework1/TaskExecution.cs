using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    public class TaskExecution
    {
        public static void Main()
        {
            Console.WriteLine("Input square length:");
            string s = Console.ReadLine();
            int a = Convert.ToInt32(s);
            Console.WriteLine("Perimeter of square with length={0} is {1}", a, a * 4);
            Console.WriteLine("Area of square is {0}",a * a);
        
            Console.WriteLine("Input your name:");
            string name= Console.ReadLine();
            Console.WriteLine("How old are you,{0}?",name);
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} is {1} years old", name,age);
            Console.ReadKey();
        }
        
    }
}
