using FluentValidation;

namespace CavuTest.Application.Bookings.Commands.UpdateBooking;

public class UpdateBookingCommandValidator : AbstractValidator<UpdateBookingCommandRequest>
{
    public UpdateBookingCommandValidator()
    {
        // Validation for update booking booking exists etc 
    }

}
