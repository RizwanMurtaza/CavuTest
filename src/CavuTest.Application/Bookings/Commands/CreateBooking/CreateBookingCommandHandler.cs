using CavuTest.Application.Interfaces;
using CavuTest.Application.Models;
using CavuTest.Application.Services;
using CavuTest.Domain.Entities;
using MediatR;

namespace CavuTest.Application.Bookings.Commands.CreateBooking;

public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommandRequest, Guid>
{
    private readonly IApplicationDbContext _context;
    private readonly IPriceCalculatorService _priceCalculatorService;

    public CreateBookingCommandHandler(IApplicationDbContext context, IPriceCalculatorService priceCalculatorService)
    {
        _context = context;
        _priceCalculatorService = priceCalculatorService;
    }

    public async Task<Guid> Handle(CreateBookingCommandRequest request, CancellationToken cancellationToken)
    {

        var booking = BookingEntity.CreateBookingEntity(request.DateFrom,
                                    request.DateTo,
                                    request.Title,
                                    await _priceCalculatorService.CalculatePrice(request.DateFrom, request.DateTo));

        _context.BookingEntities.Add(booking);
        await _context.SaveChangesAsync(cancellationToken);
        return booking.Id;
    }
}
