using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    /// <summary>
    /// For the particular case of right angled triangles with equal cathetus
    /// </summary>
    public class IsoscelesRightAngle : RightAngled
    {
        public IsoscelesRightAngle()
            : base() { }

        /// <summary>
        /// Constructor with one cathetus parametr
        /// </summary>
        /// <param name="cathetusA">Side a,b lenght cathetus</param>
        public IsoscelesRightAngle(double cathetusA)
            : base(cathetusA, cathetusA) { }

        /// <summary>
        /// Override base class method for area, and calculate it by formula:
        /// S = 1/2 * h * c,
        /// where h - height,
        /// c - hypotenuse.
        /// </summary>
        /// <returns>(double) value</returns>
        public override double GetArea()
        {
            double h = SideAB.Lenght * SideBC.Lenght / SideCA.Lenght;
            return 1.0 / 2 * SideCA.Lenght * h;
        }
    }
}
