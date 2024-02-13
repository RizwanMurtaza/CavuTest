using CavuTest.Application.Interfaces;
using FluentValidation;

namespace CavuTest.Application.Bookings.Commands.CreateBooking;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommandRequest>
{
    public CreateBookingCommandValidator()
    {
        RuleFor(v => v.Title)
            .NotEmpty()
            .WithMessage("Booking Title is required")
            .MaximumLength(200);

        RuleFor(v => v.DateFrom)
            .NotEmpty()
            .WithMessage("Booking Start Date is required")
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Booking Start Date Must be in future");

        RuleFor(v => v.DateTo)
            .NotEmpty()
            .WithMessage("Booking End date is required")
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Booking End Date Must be in future")
            .GreaterThan(r => r.DateFrom)
            .WithMessage("Booking End Date must be greater than start date");
    }

}
