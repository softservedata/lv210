using System;
using System.Collections;
using System.Collections.Generic;

namespace AnimalsProject
{
    class Program
    {
        static void Main(string[] args)
        {
            IAnimal myCat = new Cat();
                                                                               
            IAnimal myDog = new Dog();

            List<IAnimal> animals = new List<IAnimal>();      
            animals.Add(myCat);
            animals.Add(myDog);

            foreach(IAnimal item in animals)
            {
                item.Feed();
                item.Voice();
                Console.WriteLine(item.Food);
            }

            Console.ReadKey();
        }
    }
}
