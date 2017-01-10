using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    abstract class Shape : IComparable<Shape> 
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Shape(string name)
        {
            this.Name = name;
        }
        public abstract double Area();
        public abstract double Perimeter();

        public int CompareTo(Shape obj)
        {
            if (this.Area() > obj.Area())
                return 1;
            if (this.Area() < obj.Area())
                return -1;
            else
                return 0;
        }
    }
}
