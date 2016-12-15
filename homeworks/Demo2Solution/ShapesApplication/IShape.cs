namespace ShapesApplication
{
    public interface IShape
    {
        Color Color { get; set; }

        double CalculateArea();

        bool CanDraw();
    }
}
