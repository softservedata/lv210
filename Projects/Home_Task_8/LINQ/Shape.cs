using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class Shape
    {
        // Field

        private string _name;

        // Prop

        public double Perimeter { get; set; }

        public double Area { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Ctor

        public Shape(string name)
        {
            Name = name;
        }

        // Methods

        public abstract double GetArea();

        public abstract double GetPerimeter();

        public override string ToString()
        {
            return String.Format($"{Name} P = {Perimeter:F} S = {Area:F}");
        }
    }
}
