using MediatR;

namespace CavuTest.Application.Bookings.Queries.GetBookingCount
{
    public class GetBookingsCountQuery : IRequest<int>
    {

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

    }
}