using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork2._3
{
    enum HTTPError
    {
        Bad_Request = 400, Unauthorized, Payment_Required, Forbidden, Not_Found, Method_Not_Allowed,
        Not_Acceptable, Proxy_Authentication_Required, Request_Timeout, Conflict, Gone
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter HTTP error code (400 - 410): ");

            int err_code = int.Parse(Console.ReadLine());

            if (err_code >= 400 && err_code <= 410)
            {
                HTTPError error = (HTTPError)err_code;
                Console.Write("- {0}", error);
            }
            else
                Console.WriteLine("Wrong number");

            Console.ReadKey();
        }
    }
}
