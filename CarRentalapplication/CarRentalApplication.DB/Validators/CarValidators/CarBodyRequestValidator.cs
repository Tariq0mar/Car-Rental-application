using CarRentalApplication.DB.Models.Cars;
using FluentValidation;

namespace CarRentalApplication.DB.Validators.CarValidators;

public class CarBodyRequestValidator : AbstractValidator<CarBodyRequest>
{
    public CarBodyRequestValidator()
    {
        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage("Model is required.")
            .MaximumLength(100)
            .WithMessage("Model must not exceed 100 characters.");

        RuleFor(x => x.PricePerDay)
            .GreaterThan(0)
            .WithMessage("PricePerDay must be greater than 0.");
    }
}