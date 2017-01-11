using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    abstract class Shape
    {
        private string _name;

        public Shape(string name)
        {
            Name = name;
        }

        public double Perimeter { get; set; }
        public double Area { get; set; }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        /// <summary>
        /// Formating shape output
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format($"{Name} P = {Perimeter:F} S = {Area:F}");
        }

        /// <summary>
        /// Output shapes collection on console
        /// </summary>
        /// <param name="shapes">Shapes collection</param>
        public static void ConsoleDisplay(List<Shape> shapes)
        {
            foreach (var shape in shapes)
                Console.WriteLine(shape);
        }
    }
}
