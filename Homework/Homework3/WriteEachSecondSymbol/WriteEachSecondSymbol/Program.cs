using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteEachSecondSymbol
{
    using AppropriateFunctions;
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter line of symbols:");
            var data = Console.ReadLine();

            Console.WriteLine("\nResult line with each second symbol:");
            Console.WriteLine(Functions.EachSecondSymbol(data));

            Console.ReadLine();

        }
    }
}
