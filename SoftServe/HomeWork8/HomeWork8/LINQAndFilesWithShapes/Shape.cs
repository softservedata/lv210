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

        public abstract int CompareTo(Shape shape);
    }
}
