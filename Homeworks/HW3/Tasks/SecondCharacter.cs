using System;

namespace SecondCharacter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputData;
            Console.WriteLine("Input string:");
            inputData = Console.ReadLine();
            for (int i = 0; i < inputData.Length; i++)
            {
                if ((i + 1) % 2 == 0)
                    Console.Write(inputData[i]);
            }
            Console.ReadLine();
        }
    }
}
