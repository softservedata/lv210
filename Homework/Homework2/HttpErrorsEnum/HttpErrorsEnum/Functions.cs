using System;
using System.Net;

namespace AppropriateFunctions
{
    public class Fucntions
    {
        //enum Errors { Bad_Request = 400, Unauthorized, Payment_Required, Forbidden, Not_Found };

        public static void GetErrorName()
        {
            Console.Write("Enter error number -");
            var input = Console.ReadLine();

            int error_number;

            var isInputValid = int.TryParse(input, out error_number);
            var isErrorValid = error_number >= 400 && error_number <= 451;

            if (isInputValid && isErrorValid)
            {
                Console.WriteLine("\nError name - {0}", (HttpStatusCode)error_number);
                //Console.WriteLine("Error name - {0}", (Error)error_number);
            }
            else
            {
                Console.WriteLine("Incorrect value!\n");
            }
                     
            Console.ReadLine();
        }
    }
}