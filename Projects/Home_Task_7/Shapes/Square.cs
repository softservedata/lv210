using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Square : Shape
    {
        // Field

        private double _side;

        // Constructor

        public Square(string name, double side) : base(name)
        {
            _side = side;
            Perimeter = GetPerimeter();
            Area = GetArea();
        }

        // Methods

        /// <summary>
        /// Calculate area of square by formula: S = side^2
        /// </summary>
        /// <returns>Area value</returns>
        public override double GetArea()
        {
            return Math.Pow(_side, 2);
        }

        /// <summary>
        /// Calculate perimeter of square by formula: P = side*4
        /// </summary>
        /// <returns>Perimeter value</returns>
        public override double GetPerimeter()
        {
            return 4 * _side;
        }
    }
}
