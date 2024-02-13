using MediatR;

namespace CavuTest.Application.Bookings.Commands.UpdateBooking;

public record UpdateBookingCommandRequest : IRequest<Guid>
{
    public Guid BookingId { get; set; }
    public string? Title { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public decimal Price { get; set; }

}