﻿using System;

namespace HW1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            int age;
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine("How old are you, {0}?", name);
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Your name is {0} and you are {1} years old.", name, age);
            Console.ReadLine();
        }
    }
}