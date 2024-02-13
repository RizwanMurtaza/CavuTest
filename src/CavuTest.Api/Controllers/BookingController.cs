using CavuTest.Application.Bookings.Queries.GetAll;
using Microsoft.AspNetCore.Mvc;
using CavuTest.Application.Bookings.Queries;
using CavuTest.Application.Bookings.Queries.PagedBooking;
using CavuTest.Application.Models;
using CavuTest.Application.Bookings.Commands.CreateBooking;
using CavuTest.Application.Bookings.Queries.GetBookingAvailability;
using MediatR;

namespace CavuTest.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly Mediator _mediator;

        public BookingController(Mediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<List<BookingResponse>> Get(GetAllBookingsQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet(Name = "GetPaged")]
        public async Task<PaginatedList<BookingResponse>> GetPaged(BookingsWithPaginationQuery query, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost(Name = "Create")]
        public async Task<Guid> GetPaged(CreateBookingCommandRequest command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpGet(Name = "GetAvailability")]
        public async Task<BookingAvailabilityResponse> GetPaged(BookingAvailabilityQuery command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return result;
        }
    }
}
