using CarRentalApplication.DB.Models.Bookings;
using FluentValidation;

namespace CarRentalApplication.DB.Validators.BookingValidators;

public class BookingFilteringQueryParametersValidator : AbstractValidator<BookingFilteringQueryParameters>
{
    public BookingFilteringQueryParametersValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId  must be greater than 0.");

        RuleFor(x => x.CarId)
            .GreaterThan(0)
            .WithMessage("UserId  must be greater than 0.");

        RuleFor(x => x.PageNumber)
            .GreaterThan(0)
            .WithMessage("PageNumber must be greater than 0.");

        RuleFor(x => x.PageSize)
            .InclusiveBetween(1, 100)
            .WithMessage("PageSize must be between 1 and 100.");

        RuleFor(x => x.StartDateTo)
            .GreaterThanOrEqualTo(x => x.StartDateFrom)
            .When(x => x.StartDateFrom.HasValue && x.StartDateTo.HasValue)
            .WithMessage("StartDateTo must be greater than or equal to StartDateFrom.");

        RuleFor(x => x.EndDateTo)
            .GreaterThanOrEqualTo(x => x.EndDateFrom)
            .When(x => x.EndDateFrom.HasValue && x.EndDateTo.HasValue)
            .WithMessage("EndDateTo must be greater than or equal to EndDateFrom.");
    }
}