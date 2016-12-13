using FluentValidation;

namespace HierarchyOfGeometricShapes
{
    public class RectangleValidator : QuadrangleValidator
    {
        public RectangleValidator() : base()
        {
            RuleFor(rectangle => rectangle.Points)
                .Must(HasAllRightAngles)
                .WithMessage("\nAll angles should be right!");
        }

        private bool HasAllRightAngles(Point[] points)
        {
            var countOfSameCoordinates = 0;

            for (int i = 0; i < points.Length; i++)
            {
                for (int j = i + 1; j < points.Length; j++)
                {
                    if ((points[i].X == points[j].X) || (points[i].Y == points[j].Y))
                    {
                        countOfSameCoordinates++;
                    }
                }
            }

            return (countOfSameCoordinates == 4);
        }
    }
}
