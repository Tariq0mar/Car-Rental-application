using CarRentalApplication.DB.Models.Cars;
using FluentValidation;

namespace CarRentalApplication.DB.Validators.CarValidators;

public class CarFilteringQueryParametersValidator : AbstractValidator<CarFilteringQueryParameters>
{
    public CarFilteringQueryParametersValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("PageSize must be between 1 and 100.");

        RuleFor(x => x.MaxPrice)
            .GreaterThanOrEqualTo(x => x.MinPrice)
            .When(x => x.MinPrice.HasValue && x.MaxPrice.HasValue)
            .WithMessage("MaxPrice must be greater than or equal to MinPrice.");

        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage("Model is required.")
            .MaximumLength(100)
            .WithMessage("Model must not exceed 100 characters.");
    }
}