using System.Collections.Generic;
using FluentValidation.Results;

namespace HierarchyOfGeometricShapes
{
    public class Rectangle : Quadrangle
    {
        public Rectangle(Point[] points) : base(points) { }

        public override double Area()
        {
            var a = Line(Points[0], Points[1]);
            var b = Line(Points[0], Points[1]);

            return a * b;
        }

        public new IList<ValidationFailure> Validate()
        {
            var validator = new RectangleValidator();
            var result = validator.Validate(this);

            return result.Errors;
        }

        public override string ToString()
        {
            return $"Hi! This is a Rectangle. Perimeter is {Perimeter()}, area is {Area()}.";
        }
    }
}
