using CavuTest.Application.Bookings.Queries.GetBookingCount;
using CavuTest.Application.Models;
using CavuTest.Application.Services;
using MediatR;

namespace CavuTest.Application.Bookings.Queries.GetBookingAvailability
{
    public class BookingAvailabilityQueryHandler : IRequestHandler<BookingAvailabilityQuery, BookingAvailabilityResponse>
    {
        private readonly IMediator _mediator;
        private readonly IPriceCalculatorService _priceCalculatorService;

        public BookingAvailabilityQueryHandler(IMediator mediator, IPriceCalculatorService priceCalculatorService)
        {
            _mediator = mediator;
            _priceCalculatorService = priceCalculatorService;
        }

        public async Task<BookingAvailabilityResponse> Handle(BookingAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var spaceCountRequest = new GetBookingsCountQuery()
            {
                DateFrom = request.DateFrom,
                DateTo = request.DateTo

            };
            var bookedSpacesCount = await _mediator.Send(spaceCountRequest, cancellationToken);
            var price = await _priceCalculatorService.CalculatePrice(request.DateFrom, request.DateTo);

            return new BookingAvailabilityResponse
            {
                Price = price,
                SpacesAvailable = ApplicationConstants.ParkingMaxCapacity - bookedSpacesCount
            };
        }
    }
}
