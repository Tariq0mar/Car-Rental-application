using CarRentalApplication.DB.Models.Users;
using FluentValidation;

namespace CarRentalApplication.DB.Validators.UserValidators;

public class UserBodyRequestValidator : AbstractValidator<UserBodyRequest>
{
    public UserBodyRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .MaximumLength(100).WithMessage("Email must not exceed 100 characters.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(10).WithMessage("Password must be at least 10 characters long.")
            .MaximumLength(50).WithMessage("Password must not exceed 50 characters.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .MaximumLength(20).WithMessage("Phone number must not exceed 20 characters.");

        RuleFor(x => x.AddressLine1)
            .NotEmpty().WithMessage("Address Line 1 is required.")
            .MaximumLength(100).WithMessage("Address Line 1 must not exceed 100 characters.");

        RuleFor(x => x.AddressLine2)
            .MaximumLength(100).WithMessage("Address Line 2 must not exceed 100 characters.")
            .When(x => !string.IsNullOrWhiteSpace(x.AddressLine2));

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(50).WithMessage("City must not exceed 50 characters.");

        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(50).WithMessage("Country must not exceed 50 characters.");

        RuleFor(x => x.DriversLicenseNumber)
            .NotEmpty().WithMessage("Driver's license number is required.")
            .MaximumLength(20).WithMessage("Driver's license number must not exceed 20 characters.");
    }
}