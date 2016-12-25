using System;
using System.Collections.Generic;

namespace HwFive
{
    public interface IAnimal
    {
        string Name { get; set; }

        void Voice();
        void Feed();
    }

    public class Cat : IAnimal
    {
        private string catName;

        public string Name
        {
            get
            {
                return this.catName;
            }
            set
            {
                this.catName = value;
            }
        }

        public void Voice()
        {
            Console.WriteLine("Class Cat: method Voice() : {0}", catName);
            Console.ReadKey();
        }

        public void Feed()
        {
            Console.WriteLine("Class Cat: method Feed() : {0}", catName);
            Console.ReadKey();
        }

    }

    public class Dog : IAnimal
    {
        private string dogName;

        public string Name
        {
            get
            {
                return this.dogName;
            }
            set
            {
                this.dogName = value;
            }
        }

        public void Voice()
        {
            Console.WriteLine("Class Dog: method Voice() : {0}", dogName);
            Console.ReadKey();
        }

        public void Feed()
        {
            Console.WriteLine("Class Dog: method Feed() : {0}", dogName);
            Console.ReadKey();
        }
    }

    public class Program
    {

        public static void Main(string[] args)
        {
            List<IAnimal> animals = new List<IAnimal>();
            animals.Add(new Cat() { Name = "CatOne" });
            animals.Add(new Cat() { Name = "CatTwo" });
            animals.Add(new Dog() { Name = "DogOne" });
            animals.Add(new Dog() { Name = "DogTwo" });

            foreach (IAnimal animal in animals)
            {
                animal.Feed();
                animal.Voice();
            }
        }
    }
}
