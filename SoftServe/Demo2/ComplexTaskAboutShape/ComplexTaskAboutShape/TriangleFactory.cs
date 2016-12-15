namespace ComplexTaskAboutShape
{
    /// <summary>
    /// Class TriangleFactory implements class ShapeFactory.
    /// Method CreateShape() returns triangle.
    /// </summary>
    
    class TriangleFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            Point firstPoint = GetCoordinate();
            Point secondPoint = GetCoordinate();
            Point thirdPoint = GetCoordinate();

            IShape triangle = new Triangle(firstPoint, secondPoint, thirdPoint);

            return triangle;
        }
    }
}
