﻿using System;

namespace Dog
{
/*
	declare struct Dog with fields Name, Mark, Age. 
	Decleare variable myDog of Dog type and read values for it.
	Output myDos into console.(Decleare method ToString in struct)
*/
    struct Dog
    {
        public string Name;
        public string Mark;
        public int Age;
        public void toString()
        {

            Console.WriteLine("Name : {0}", Name);
            Console.WriteLine("Mark : {0}", Mark);
            Console.WriteLine("Age : {0}", Age);
        }
    };
    class Program
    {
        static void Main(string[] args)
        {
            Dog myDog = new Dog();
            Console.WriteLine("Input dog`s name");
            myDog.Name = Console.ReadLine();
            Console.WriteLine("Input dog`s mark");
            myDog.Mark = Console.ReadLine();
            Console.WriteLine("Input dog`s age");
            myDog.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Information about dog:");
            myDog.toString();
            Console.ReadLine();
        }
    }
}
