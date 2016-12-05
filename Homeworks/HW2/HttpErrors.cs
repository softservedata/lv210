using System;

namespace HttpErrors
{
/*
	read number of HTTP Error (400, 401,402, ...) 
	and write the name of this error (Decleare enum HTTPError)
*/
    enum HTTPEror
    {
        BAD_REQUEST = 400,
        UNAUTHORIZED,
        PAYMENT_REQUIRED,
        FORBIDDEN,
        NOT_FOUND,
        METHOD_NOT_ALLOWED,
        NOT_ACCEPTABLE,
        PROXY_AUTHENTICATION_REQUIRED,
        REQUEST_TIMEOUT,
        CONFLICT,
        GONE,
        LENGTH_REQUIRED,
        PRECONDITION_FAILED,
        PAYLOAD_TOO_LARGE,
        URI_TOO_LARGE,
    }
    class Program
    {
        static void Main(string[] args)
        {
            HTTPEror error;
            Console.Write("Input http error (400 - 414): ");
            error = (HTTPEror)Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(error);
            Console.ReadLine();
        }
    }
}
