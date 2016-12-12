using System.Drawing;
using System.Linq;
using FluentValidation;

namespace CreatingClassCar
{
    public class CarValidator: AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.Price)
                .GreaterThan(0)
                .WithMessage("\nCar's price cannot be less or equal zero!");
            RuleFor(car => car.Brand)
                .Length(0, 40)
                .NotNull()
                .NotEmpty()
                .Must(IsCharacterStringOnly)
                .WithMessage("\nCar's brand cannot be empty, contain digits or specific characters!");
            RuleFor(car => car.Color)
                .NotNull()
                .NotEmpty()
                .Must(IsExistingColor)
                .WithMessage("\n Car color cannot be empty or unknown!");
        }

        private bool IsCharacterStringOnly(string brand)
        {
            return !((brand.Any(char.IsDigit)) || (brand.Any(c => !char.IsLetterOrDigit(c))));
        }

        private bool IsExistingColor(Color color)
        {
            return color.IsKnownColor;
        }
    }
}
