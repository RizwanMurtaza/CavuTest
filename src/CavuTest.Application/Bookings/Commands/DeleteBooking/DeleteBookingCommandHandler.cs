using CavuTest.Application.Interfaces;
using CavuTest.Application.Services;
using MediatR;

namespace CavuTest.Application.Bookings.Commands.DeleteBooking;

public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommandRequest, Guid>
{
    private readonly IApplicationDbContext _context;

    public DeleteBookingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(DeleteBookingCommandRequest request, CancellationToken cancellationToken)
    {

        //Booking validation is done on request level so it will always have value 
        var booking = _context.BookingEntities.FirstOrDefault(x => x.Id == request.BookingId);

        _context.BookingEntities.Remove(booking);
        await _context.SaveChangesAsync(cancellationToken);
        return booking.Id;
    }
}
