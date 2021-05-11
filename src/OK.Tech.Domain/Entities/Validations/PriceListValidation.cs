using FluentValidation;

namespace OK.Tech.Domain.Entities.Validations
{
    public class PriceListValidation : AbstractValidator<PriceList>
    {
        public PriceListValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("The {PropertyName} must be supplied")
                .Length(3, 200).WithMessage("The field {PropertyName} length must be between {MinLength} and {MaxLength}");
        }
    }
}