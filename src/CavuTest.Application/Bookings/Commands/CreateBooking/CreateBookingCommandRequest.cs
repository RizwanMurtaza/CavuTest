using MediatR;

namespace CavuTest.Application.Bookings.Commands.CreateBooking;

public record CreateBookingCommandRequest : IRequest<Guid>
{
    public string? Title { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

}