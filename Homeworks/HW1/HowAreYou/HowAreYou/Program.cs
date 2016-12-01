using System;

namespace HowAreYou
{
    class Program
    {
        static void Main(string[] args)
        {
            string answer;
            Console.WriteLine("How are you?");
            answer = Console.ReadLine();
            Console.WriteLine("You are {0}", answer);
            Console.ReadLine();
        }
    }
}
