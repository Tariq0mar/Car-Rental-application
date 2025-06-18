using CarRentalApplication.DB.Models.Users;
using FluentValidation;

namespace CarRentalApplication.DB.Validators.UserValidators;

public class UserFilteringQueryParametersValidator : AbstractValidator<UserFilteringQueryParameters>
{
    public UserFilteringQueryParametersValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("PageSize must be between 1 and 100.");

        RuleFor(x => x.MaxDateOfBirth)
            .GreaterThanOrEqualTo(x => x.MinDateOfBirth)
            .When(x => x.MinDateOfBirth.HasValue && x.MaxDateOfBirth.HasValue)
            .WithMessage("MaxDateOfBirth must be greater than or equal to MinDateOfBirth.");

        RuleFor(x => x.FirstName)
            .MaximumLength(50)
            .WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .MaximumLength(50)
            .WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .MaximumLength(100)
            .WithMessage("Email must not exceed 100 characters.");

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(20)
            .WithMessage("Phone number must not exceed 20 characters.");

        RuleFor(x => x.City)
            .MaximumLength(50)
            .WithMessage("City name must not exceed 50 characters.");

        RuleFor(x => x.Country)
            .MaximumLength(50)
            .WithMessage("Country name must not exceed 50 characters.");
    }
}