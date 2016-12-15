using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Point
    {
        /// <summary>
        /// Coordinate X
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// Coordinate Y
        /// </summary>
        public double Y { get; set; }

        public Point() { }

        public Point(double coordinateX, double coordinateY)
        {
            X = coordinateX;
            Y = coordinateY;
        }
    }
}
