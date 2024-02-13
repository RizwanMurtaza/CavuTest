using Microsoft.AspNetCore.Mvc;
using CavuTest.Application.Bookings.Queries;
using CavuTest.Application.Models;
using CavuTest.Application.Bookings.Queries.GetBookingAvailability;
using CavuTest.Api.Controllers.Request;
using CavuTest.Application.Bookings.Commands.UpdateBooking;
using CavuTest.Application.Bookings.Commands.DeleteBooking;

namespace CavuTest.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookingController : ApiControllerBase
    {

        [HttpGet(Name = "GetAll")]
        public async Task<List<BookingResponse>> Get([FromQuery] GetBookingRequestModel request, CancellationToken cancellationToken)
        {
            var query = request.ToGetAllBookingsQuery();
            var result = await Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpGet(Name = "GetPage")]
        public async Task<PaginatedList<BookingResponse>> GetPaged([FromQuery] GetBookingRequestModel request, CancellationToken cancellationToken)
        {
            var query = request.ToBookingsWithPaginationQuery();
            var result = await Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost(Name = "Create")]
        public async Task<Guid> Create(CreateBookingRequestModel request, CancellationToken cancellationToken)
        {
            var command = request.ToCommand();
            var result = await Mediator.Send(command, cancellationToken);
            return result;
        }

        [HttpGet(Name = "GetAvailability")]
        public async Task<BookingAvailabilityResponse> GetAvailability([FromQuery] GetBookingRequestModel request, CancellationToken cancellationToken)
        {
            var query = request.ToBookingAvailabilityQuery();
            var result = await Mediator.Send(query, cancellationToken);
            return result;
        }

        [HttpPost(Name = "Update")]
        public async Task<Guid> Update(UpdateBookingCommandRequest request, CancellationToken cancellationToken)
        {
            // should be request that is converted to command 
            var result = await Mediator.Send(request, cancellationToken);
            return result;
        }

        [HttpPost(Name = "Delete")]
        public async Task<Guid> Delete(DeleteBookingCommandRequest request, CancellationToken cancellationToken)
        {
            // should be request that is converted to command 
            var result = await Mediator.Send(request, cancellationToken);
            return result;
        }
    }
}
