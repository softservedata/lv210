using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQAndFilesWithShapes
{
    public abstract class Shape : IComparable<Shape>
    {
        private string name;
        public string Name { get; set; }

        public Shape(string name)
        {
            Name = name;
        }

        public abstract double GetArea();

        public abstract double GetPerimetr();

        public int CompareTo(Shape other)
        {
            return GetArea().CompareTo(other.GetArea());
        }

        public override bool Equals(object obj)
        {
            var other = obj as Shape;
            if (other == null)
            {
                return false;
            }
            else
            {
                return this.Name.Equals(other.Name);
            }
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }
}
