using System.Linq;
using FluentValidation;

namespace InformationAboutPerson
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.Age)
                .GreaterThan(0)
                .LessThan(150)
                .WithMessage("\nPerson's age cannot be less or equal zero or greater 150!");
            RuleFor(person => person.Name)
                .Length(0, 40)
                .NotNull()
                .NotEmpty()
                .Must(IsCharacterStringOnly)
                .WithMessage("\nPerson's name cannot be empty, contain digits or specific characters");
        }

        private bool IsCharacterStringOnly(string name)
        {
            return !((name.Any(char.IsDigit)) || (name.Any(c => !char.IsLetterOrDigit(c))));
        }
    }
}
