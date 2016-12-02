using System;
using System.Collections.Generic;
using System.Linq;

namespace AppropriateFunctions
{
    public class Functions
    {
      
        public static List<int> ReadData()
        {
            int current_int_number;
            List<int> inputed_numbers = new List<int>();

            while(int.TryParse(Console.ReadLine(), out current_int_number) && current_int_number >=0 )
            {
                inputed_numbers.Add(current_int_number);
            }

            return inputed_numbers;
        }

        public static void Execution()
        {
            Console.WriteLine("Please, enter sequence of numbers:");
            Console.WriteLine("(till first negative)");

            List<int> sequence_of_numbers = ReadData();

            if (sequence_of_numbers.Count != 0) Console.WriteLine("\nAverage value is {0}.", sequence_of_numbers.Average());
            else Console.WriteLine("\n The sequence is empty. Probably, you have entered nothing or incorrect value. Please, try again.");

            Console.ReadLine();
        }
    }
    
}