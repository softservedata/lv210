using System;

namespace HomeWorkTwo
{
    class HW_2_6
    {
        /// <summary>
        /// Create Console Application project in VS.
        /// In method Main() write code for solving next task:
        /// read number of HTTP Error (400, 401,402, ...) and write the name of this error (Decleare enum HTTPError)
        /// </summary>
        enum Errors
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
            REQUEST_ENTITY_TOO_LARGE,
            REQUEST_URI_TOO_LARGE,
            UNSUPPORTED_MEDIA_TYPE,
            RANGE_NOT_SATISFIABLE,
            EXPECTATION_FAILED
        };

        public static int GetErrorNumberFromConsole()
        {
            int readedVar = 0;
            bool isIntEntered = Int32.TryParse(Console.ReadLine(), out readedVar);

            if (isIntEntered && readedVar >= 400)
            {
                return readedVar;
            }
            else
            {
                Console.WriteLine("Please, enter a positive error number. Number should > 400");
                return GetErrorNumberFromConsole();
            }
        }

        static void Main()
        {
            Console.WriteLine("Please enter number of error:");
            Errors error = (Errors)GetErrorNumberFromConsole();
            Console.WriteLine("Error's name: {0}", error);
            Console.ReadKey();
        }
    }
}