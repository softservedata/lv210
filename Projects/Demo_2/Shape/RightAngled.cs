using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    /// <summary>
    /// For the particular case of triangles - right angled
    /// </summary>
    public class RightAngled : Triangle
    {
        /// <summary>
        /// Using default constructor from Triangle class
        /// </summary>
        public RightAngled()
            : base() { }

        /// <summary>
        /// Constructor with parameter. Create objects by side lenght 
        /// </summary>
        /// <param name="cathetusA">Side a lenght - first cathetus</param>
        /// <param name="cathetusB">Side b lenght - second cathetus</param>
        public RightAngled(double cathetusA, double cathetusB)
            : base(cathetusA, cathetusB, Math.Round(Math.Sqrt(cathetusA * cathetusA +
                   cathetusB * cathetusB), 2))
        { }

        /// <summary>
        /// Override base class method for area, and calculate it by formula:
        /// S = 1/2 * a * b,
        /// where a - first cathetus
        /// b - second cathetus
        /// </summary>
        /// <returns>(double) Area value</returns>
        public override double GetArea()
        {
            return 1.0 / 2 * SideAB.Lenght * SideBC.Lenght;
        }
    }
}
