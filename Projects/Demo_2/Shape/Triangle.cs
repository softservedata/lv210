using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shape
{
    /// <summary>
    /// For creating and manipulating with triangles. Inherited from class Shape2D
    /// </summary>
    public class Triangle : Shape2D
    {
        #region Properties

        public TriangleTypes Type { get; set; }

        public Point VerticeA { get; set; }
        public Point VerticeB { get; set; }
        public Point VerticeC { get; set; }

        public Line SideAB { get; set; }
        public Line SideBC { get; set; }
        public Line SideCA { get; set; }

        public double AngleA { get; set; }
        public double AngleB { get; set; }
        public double AngleC { get; set; }

        #endregion

        #region Constructors

        public Triangle() { }

        /// <summary>
        /// Create triangle using three points
        /// </summary>
        /// <param name="A">Point A</param>
        /// <param name="B">Point B</param>
        /// <param name="C">Point C</param>
        public Triangle(Point A, Point B, Point C)
        {
            VerticeA = A;
            VerticeB = B;
            VerticeC = C;

            SideAB = new Line(VerticeA, VerticeB);
            SideBC = new Line(VerticeB, VerticeC);
            SideCA = new Line(VerticeC, VerticeA);

            AngleA = Math.Round(GetAngle(SideAB, SideCA, SideBC));
            AngleB = Math.Round(GetAngle(SideAB, SideBC, SideCA));
            AngleC = Math.Round(GetAngle(SideBC, SideCA, SideAB));

            Type = ObtainType();

            CheckConditions();
        }

        /// <summary>
        /// Create triangle by length parties
        /// </summary>
        /// <param name="lenghtA">Lenght of side AB</param>
        /// <param name="lenghtB">Lenght of side BC</param>
        /// <param name="lenghtC">Lenght of side CA</param>
        public Triangle(double lenghtA, double lenghtB, double lenghtC)
        {
            SideAB = new Line(lenghtA);
            SideBC = new Line(lenghtB);
            SideCA = new Line(lenghtC);
            CheckConditions();
            AngleA = Math.Round(GetAngle(SideAB, SideCA, SideBC));
            AngleB = Math.Round(GetAngle(SideAB, SideBC, SideCA));
            AngleC = Math.Round(GetAngle(SideBC, SideCA, SideAB));
            Type = ObtainType();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Verifies whether met the existence conditions for triangle
        /// </summary>
        /// <returns>(bool) True if condition met, false - if not</returns>
        public bool AreExistingConditionsMeet()
        {
            double a = SideAB.Lenght;
            double b = SideBC.Lenght;
            double c = SideCA.Lenght;

            if ((a < b + c) && (b < c + a) && (c < a + b))
                return true;

            return false;
        }

        /// <summary>
        /// Check condition and if they not satisfy throw exeption message
        /// </summary>
        public bool CheckConditions()
        {
            if (!AreExistingConditionsMeet())
            {
                throw new Exception("Conditions for the existence of a triangle are not met!");
            }

            return true;
        }

        /// <summary>
        /// Calculate angle by formula:
        /// angleA = arccos ((side1^2 + side2^2 - sideOpp^2) / (2 * side1 * side2))
        /// </summary>
        /// <param name="side1">First side adjacent to angle</param>
        /// <param name="side2">Second side adjacent to angle</param>
        /// <param name="sideOpposite">Side opposite angle</param>
        /// <returns>(double) Angle in degrees</returns>
        private double GetAngle(Line side1, Line side2, Line sideOpposite)
        {
            double angleRadian = Math.Acos((side1.Lenght * side1.Lenght +
                                            side2.Lenght * side2.Lenght -
                                            sideOpposite.Lenght * sideOpposite.Lenght) /
                                           (2 * side1.Lenght * side2.Lenght));

            return Math.Round((angleRadian * (180 / Math.PI)), 2);
        }

        /// <summary>
        /// Calculate perimetr
        /// </summary>
        /// <returns>(double) The sum of the three sides</returns>
        public override double GetPerimetr()
        {
            return SideAB.Lenght + SideBC.Lenght + SideCA.Lenght;
        }

        /// <summary>
        /// Calculate area by Heron formula:
        /// S = √(p(p - a)(p - b)(p - c)), 
        /// where p = Perimetr / 2
        /// a,b,c - sides
        /// </summary>
        /// <returns>double value</returns>
        public override double GetArea()
        {
            double p = GetPerimetr() / 2;
            double S = Math.Sqrt(p * (p - SideAB.Lenght) * (p - SideBC.Lenght) * (p - SideCA.Lenght));

            return Math.Round(S, 2);
        }

        /// <summary>
        /// Determines the type of triangle
        /// </summary>
        /// <returns>(TriangleTypes) value</returns>
        public TriangleTypes ObtainType()
        {
            if (IsEquilateral())
                return TriangleTypes.Equilateral;

            if (IsIsosceles())
            {
                if (IsRightAngled())
                    return TriangleTypes.Isosceles_Right_Angle;
                else
                    return TriangleTypes.Isosceles;
            }

            if (IsRightAngled())
                return TriangleTypes.Right_Angled;

            return TriangleTypes.Versatile;
        }

        /// <summary>
        /// Verifies whether triangle is right angled using angles
        /// </summary>
        /// <returns>(bool) True if at least one of the angles is 90 degrees</returns>
        private bool IsRightAngled()
        {
            if ((AngleA == 90) || (AngleB == 90) || (AngleC == 90))
                return true;

            return false;
        }

        /// <summary>
        /// Verifies whether triangle is isosceles using sides
        /// </summary>
        /// <returns>(bool) True if arbitrary two sides equal</returns>
        private bool IsIsosceles()
        {
            if ((SideAB.Lenght == SideBC.Lenght) || (SideBC.Lenght == SideCA.Lenght) ||
                (SideAB.Lenght == SideCA.Lenght))
                return true;

            return false;
        }

        /// <summary>
        /// Verifies whether triangle is equilateral using sides
        /// </summary>
        /// <returns>(bool) True if all sides equal</returns>
        private bool IsEquilateral()
        {
            if (SideAB.Lenght == this.SideBC.Lenght &&
                this.SideBC.Lenght == this.SideCA.Lenght)
                return true;

            return false;
        }

        public override string ToString()
        {
            return string.Format("type: {0}\nAB={1} BC={2} CB={3} \nangA={4} angB={5} angC={6}",Type,SideAB.Lenght, SideBC.Lenght, SideCA.Lenght,
                AngleA, AngleB, AngleC);
        }

        #endregion
    }
}