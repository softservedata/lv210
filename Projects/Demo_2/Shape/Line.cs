using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    public class Line
    {
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
        public double Lenght { get; set; }

        public Line() { }

        /// <summary>
        /// Create line using only lenght value
        /// </summary>
        /// <param name="lenght">Line lenght</param>
        public Line(double lenght)
        {
            Lenght = lenght;
        }

        /// <summary>
        /// Create line using points and calculate it lenght
        /// </summary>
        /// <param name="startPoint">Starting point</param>
        /// <param name="endPoint">End of line</param>
        public Line(Point startPoint, Point endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            Lenght = GetLenght();
        }

        /// <summary>
        /// Calculate line lenght by formula:
        /// // l = √((X2 - X1)²+(Y2 - Y1)²),
        /// where X1,Y1 - coordinate for starting point
        /// X2,Y2 - coordinate for end point
        /// </summary>
        /// <returns>double value</returns>
        public double GetLenght()
        {
            double l = Math.Sqrt(Math.Pow((EndPoint.X - StartPoint.X), 2) +
                             Math.Pow((EndPoint.Y - StartPoint.Y), 2));
            return Math.Round(l, 2);
        }
    }
}
