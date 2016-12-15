using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    /// <summary>
    /// The particular case of triangles with three equal sides
    /// </summary>
    public class Equilateral : Triangle
    {
        public Equilateral()
            : base() { }

        /// <summary>
        /// Get only one parametr, because all sides are equal
        /// </summary>
        /// <param name="lenghtA">Side lenght</param>
        public Equilateral(double lenghtA)
            : base(lenghtA, lenghtA, lenghtA) { }

        /// <summary>
        /// Override base class method for area, and calculate it by formula:
        /// S = 1/4 * a^2 *√3,
        /// where a - lenght of side
        /// </summary>
        /// <returns>(double) Value</returns>
        public override double GetArea()
        {
            double a = SideAB.Lenght;
            double S = (a * a * Math.Sqrt(3))/4;

            return Math.Round(S, 2);
        }
    }
}
