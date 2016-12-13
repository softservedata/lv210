using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Input number of error(400-405):");
            int errorNumber = Convert.ToInt32(Console.ReadLine());
            HTTPErrors error = (HTTPErrors)errorNumber;
            Console.WriteLine("{0} {1}",errorNumber, error);
            Console.ReadKey();
        }
    }
}
