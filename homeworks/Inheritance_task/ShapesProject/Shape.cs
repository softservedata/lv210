using System;

namespace ShapesProject
{
    public abstract class Shape:IComparable<Shape>
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
            return (int) ((int)this.Area() - other.Area());
        }
    }
}
