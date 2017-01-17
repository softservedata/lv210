using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Circle : Shape
    {
        // Field

        private double _radius;

        // Constructor

        public Circle(string name, double radius) : base(name)
        {
            _radius = radius;
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        // Methods

        /// <summary>
        /// Calculate area of circle by formula: S = PI*radius^2
        /// </summary>
        /// <returns>Area value</returns>
        public override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        /// <summary>
        /// Calculate perimeter of circle by formula: P = 2*PI*radius
        /// </summary>
        /// <returns>Perimeter value</returns>
        public override double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }
}
