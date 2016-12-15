using FluentValidation;

namespace HierarchyOfGeometricShapes
{
    /// <summary>
    /// <para>Class CircleValidator is inherited from AbstractValidator class.</para>
    /// <para>This class is from FluentValidation library.</para>
    /// <para>It allows to validate class fields using some rules.</para>
    /// </summary>

    public class CircleValidator : AbstractValidator<Circle>
    {
        public CircleValidator()
        {
            RuleFor(circle => circle.RadiusPoint)
                .NotEqual(circle => circle.CenterPoint)
                .WithMessage("\nCannot create circle with such radius point!");
        }
    }
}