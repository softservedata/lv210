using System;

namespace HomeWork2_Task3
{
    class Program
    {
        /// <summary>
        /// Task Description : read number of HTTP Error (400, 401,402, ...) 
        /// and write the name of this error (Decleare enum HTTPError)
        /// </summary>

        static void Main(string[] args)
        {
            Console.Write("Enter number of HTTP Error from range [400,417] : ");
            HTTPErrors errorMessage = (HTTPErrors)int.Parse(Console.ReadLine());

            int errorNumber = (int)errorMessage;

            Console.WriteLine("Number of HTTP Error : {0}, Error message : {1}", errorNumber, errorMessage);

            Console.ReadKey();
        }
    }
}
