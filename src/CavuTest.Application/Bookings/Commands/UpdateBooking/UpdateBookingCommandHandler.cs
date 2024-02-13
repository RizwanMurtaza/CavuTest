using CavuTest.Application.Interfaces;
using CavuTest.Application.Services;
using CavuTest.Domain;
using CavuTest.Domain.Common;
using CavuTest.Domain.Entities;
using MediatR;

namespace CavuTest.Application.Bookings.Commands.UpdateBooking;

public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommandRequest, Guid>
{
    private readonly IApplicationDbContext _context;

    public UpdateBookingCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> Handle(UpdateBookingCommandRequest request, CancellationToken cancellationToken)
    {

        //Booking validation is done on request level so it will always have value 
        var booking = _context.BookingEntities.FirstOrDefault(x => x.Id == request.BookingId);
        booking.DateFrom = request.DateFrom.ToEpochTime();
        booking.DateTo = request.DateTo.ToEpochTime();
        booking.Name = request.Title;
        booking.Price = (double)request.Price;

        _context.BookingEntities.Update(booking);
        await _context.SaveChangesAsync(cancellationToken);
        return booking.Id;
    }
}
