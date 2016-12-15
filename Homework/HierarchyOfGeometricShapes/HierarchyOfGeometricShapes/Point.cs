namespace HierarchyOfGeometricShapes
{
    /// <summary>
    /// <para>Struct Point has two properties X and Y to display point in Cartesian coordinate system.</para>
    /// <para>Some standart operators are overloaded.</para>
    /// </summary>

    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public static bool operator !=(Point pointFirst, Point pointSecond)
        {
            return !(pointFirst == pointSecond);
        }

        public static bool operator ==(Point pointFirst, Point pointSecond)
        {
            return (pointFirst.X == pointSecond.X) && ((pointFirst.Y == pointSecond.Y));
        }

        public bool Equals(Point otherPoint)
        {
            return (X == otherPoint.X) && (Y == otherPoint.Y);
        }
    }
}