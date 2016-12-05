using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTTP_Erors
{
    class Program
    {
        static void Main(string[] args)
        {
            //read number of HTTP Error (400, 401,402, ...) and write the name of this error (Decleare enum HTTPError)
            HTTPErors error;
            Console.Write("Enter the namber of Client Error 4xx: ");
            error = (HTTPErors)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Client Error {0}: {1}",(int)error,error);
        }
    }
}
