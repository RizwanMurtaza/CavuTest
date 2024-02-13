using CavuTest.Application.Bookings.Queries;
using CavuTest.Application.Models;
using MediatR;

namespace CavuTest.Application.Bookings.Queries.PagedBooking
{
    public class BookingsWithPaginationQuery : PaginationRequestModel, IRequest<PaginatedList<BookingResponse>>
    {

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

    }
}
