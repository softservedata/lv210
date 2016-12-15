using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    /// <summary>
    /// The particular case of triangles with two equal sides
    /// </summary>
    public class Isosceles : Triangle
    {
        public Isosceles()
            : base() { }

        /// <summary>
        /// Constructor with parameter. Create objects by side lenght 
        /// </summary>
        /// <param name="lenghtA">Side AB and BC lenght</param>
        /// <param name="lenghtB">Side CA lenght</param>
        public Isosceles(double lenghtA, double lenghtB)
            : base(lenghtA, lenghtA, lenghtB) { }

        /// <summary>
        /// Override base class method for area, and calculate it by formula:
        /// S = b/4 * √(4 * a^2 - b^2), 
        /// where a - side AB
        /// b - side CA 
        /// </summary>
        /// <returns>(double) value</returns>
        public override double GetArea()
        {
            double a = SideAB.Lenght;
            double b = SideCA.Lenght;

            double S = b / 4 * Math.Sqrt(4 * a * a - b * b);

            return Math.Round(S, 2);
        }
    }
}
