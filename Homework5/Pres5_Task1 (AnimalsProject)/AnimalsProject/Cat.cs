using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalsProject
{
    public class Cat : IAnimal
    {
        private string name;
        private int food = 0;
        public string Name { get { return name; } set { name = value; } }
        public int Food { get { return food; } set { food = value; } }
        public void Feed()
        {
            this.Food++;
        }
        public void Voice()
        {
            Console.WriteLine("miau-miau");
        }
    }
}
