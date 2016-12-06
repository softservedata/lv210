using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Errors
{
    /// <summary>
    /// Read number of HTTP Error (400, 401,402, ...) and write the name of this error (Decleare enum HTTPError)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //Declare var
            int error;

            //Read from console
            Console.Write("Enter the namber of Client Error 4xx: ");
            error = Convert.ToInt32(Console.ReadLine());

            //Output result
            if (error > 399 && error < 418)
                Console.WriteLine("Client Error {0}: {1}", error, (HTTPErrors)error);
            else
                Console.WriteLine("This error is not Client!");
        }
    }
}
