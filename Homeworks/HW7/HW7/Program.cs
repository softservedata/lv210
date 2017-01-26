namespace HW7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var shapeOperations = new ShapeOperations();
            var shapesList = shapeOperations.CreateShapesList();

            shapeOperations.FindAndPrintShapeWithMaxPerimeter(shapesList);

            shapesList.Sort();
            shapeOperations.PrintShapes(shapesList);
        }
    }
}
