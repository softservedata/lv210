namespace ComplexTaskAboutShape
{
    /// <summary>
    /// Class SquareFactory implements class ShapeFactory.
    /// Method CreateShape() returns square.
    /// </summary>
    
    class SquareFactory : ShapeFactory
    {
        public override IShape CreateShape()
        {
            Point firstPoint = GetCoordinate();
            Point secondPoint = GetCoordinate();
            Point thirdPoint = GetCoordinate();
            Point fourthPoint = GetCoordinate();

            IShape square = new Square(firstPoint, secondPoint, thirdPoint, fourthPoint);

            return square;
        }
    }
}
