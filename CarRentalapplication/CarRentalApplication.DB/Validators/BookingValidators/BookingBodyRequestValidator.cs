using CarRentalApplication.DB.Models.Bookings;
using FluentValidation;

namespace CarRentalApplication.DB.Validators.BookingValidators;

public class BookingBodyRequestValidator : AbstractValidator<BookingBodyRequest>
{
    public BookingBodyRequestValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId  must be greater than 0.");

        RuleFor(x => x.CarId)
            .GreaterThan(0)
            .WithMessage("UserId  must be greater than 0.");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(x => x.EndDate)
            .WithMessage("StartDateTo must be greater than or equal to StartDateFrom.");
    }
}