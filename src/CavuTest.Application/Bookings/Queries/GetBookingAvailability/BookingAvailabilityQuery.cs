using MediatR;

namespace CavuTest.Application.Bookings.Queries.GetBookingAvailability
{
    public class BookingAvailabilityQuery : IRequest<BookingAvailabilityResponse>
    {

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

    }
}