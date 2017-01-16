using System;

namespace ShapesProject
{
    public abstract class Shape: IComparable<Shape>
    {
        public string Name { get; set; }
        
        public Shape(string name)
        {
            this.Name = name;
        }

        public abstract double Area();
        public abstract double Perimeter();
        
        public int CompareTo(Shape other)
        {
            return this.Area().CompareTo(other.Area());
        }
    }
}
