using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public abstract class Shape
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
                this.name = value;
            }
        }

        public Shape(string name)
        {
            this.name = name;
        }

        public abstract double Area();
        public abstract double Perimeter();
    }

    public class Circle : Shape
    {
        private double radius;

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                this.radius = value;
            }
        }

        public Circle(string name, double radius)
           : base(name)
        {
            this.radius = radius;
        }

        public override double Area()
        {
            return Math.PI * radius * radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
    }

    public class Square : Shape
    {
        private double side;

        public double Side
        {
            get
            {
                return side;
            }
            set
            {
                this.side = value;
            }
        }

        public Square(string name, double side)
           : base(name)
        {
            this.side = side;
        }

        public override double Area()
        {
            return side * side;
        }

        public override double Perimeter()
        {
            return 4 * side;
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Shape> shapes = new List<Shape>();
        }
    }
}


