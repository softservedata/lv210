using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    public abstract class Shape : IComparable<Shape>
    {
        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }

        }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();
        public abstract double Perimeter();


        public int CompareTo(Shape other)
        {
            return (int)((int)this.Area() - other.Area());
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
