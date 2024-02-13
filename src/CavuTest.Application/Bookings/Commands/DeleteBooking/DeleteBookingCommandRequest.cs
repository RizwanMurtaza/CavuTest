using MediatR;

namespace CavuTest.Application.Bookings.Commands.DeleteBooking;

public record DeleteBookingCommandRequest : IRequest<Guid>
{
    public Guid BookingId { get; set; }

}