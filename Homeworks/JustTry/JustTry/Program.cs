using System;

namespace JustTry
{
    class Program
    {
        static void TestTryFinally()
        {
            Console.WriteLine("Code executed before try-finally.");
            try
            {
                string str = Console.ReadLine();
                Int32.Parse(str);
                Console.WriteLine("Parsing was successful.");
                return; // Exit from the current method
            }
            catch (FormatException)
            {
                Console.WriteLine("Parsing failed!");
            }
            finally
            {
                Console.WriteLine(
                  "This cleanup code is always executed.");
            }
            Console.WriteLine(
              "This code is after the try-finally block.");
        }

        static void Main(string[] args)
        {
            TestTryFinally();
            Console.ReadLine();
        }
    }
}
