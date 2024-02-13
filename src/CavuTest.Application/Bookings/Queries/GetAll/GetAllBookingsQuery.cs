using MediatR;

namespace CavuTest.Application.Bookings.Queries.GetAll
{
    public class GetAllBookingsQuery : IRequest<List<BookingResponse>>
    {

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

    }
}