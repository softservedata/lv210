using System;

namespace Hometask7
{
    /// <summary>
    /// Abstract class Shape contains property Name and abstract methods 
    /// Area() and Perimeter() which will be implemented in derived classes.
    /// </summary>

    public abstract class Shape : IComparable
    {
        protected const double Tolerance = 0.001;
        public string Name { get; }

        public Shape(string name)
        {
            this.Name = name;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            var shape = obj as Shape;

            if (shape != null)
            {
                return this.Area().CompareTo(shape.Area());
            }
            else
            {
                throw new ArgumentException("Object is not a Shape!"); 
            }
        }

        public static bool operator <(Shape firstShape, Shape secondShape)
        {
            return (firstShape.Area() < secondShape.Area());
        }

        public static bool operator >(Shape firstShape, Shape secondShape)
        {
            return (firstShape.Area() > secondShape.Area());
        }

        public static bool operator <=(Shape firstShape, Shape secondShape)
        {
            return (firstShape.Area() <= secondShape.Area());
        }

        public static bool operator >=(Shape firstShape, Shape secondShape)
        {
            return (firstShape.Area() >= secondShape.Area());
        }

        public override string ToString()
        {
            return $"\nMy name is {Name}.\nArea = {Area()}.\nPerimeter = {Perimeter()}.";
        }

        public abstract double Area();
        public abstract double Perimeter();
    }
}