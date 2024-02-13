using FluentValidation;

namespace CavuTest.Application.Bookings.Commands.DeleteBooking;

public class DeleteBookingCommandValidator : AbstractValidator<DeleteBookingCommandRequest>
{
    public DeleteBookingCommandValidator()
    {
        // Validation for delete booking booking exists etc 
    }

}
