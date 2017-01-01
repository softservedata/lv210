using System;

namespace HW2_HTTP_errors
{
    enum HTTPErrors : int { Bad_Request = 400, Unauthorized = 401, Forbidden = 403, Not_Found = 404, Method_Not_Allowed = 405, Not_Acceptable = 406,
        Proxy_Authentication_Required = 407, Request_Timeout = 408, Conflict = 409, Gone = 410    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter mistake cod (betwin 400 and 410): ");
            int mistake = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine((HTTPErrors)mistake);
            Console.ReadKey();
        }
    }
}