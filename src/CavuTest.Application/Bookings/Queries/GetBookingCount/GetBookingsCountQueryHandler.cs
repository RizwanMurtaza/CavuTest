using CavuTest.Application.Interfaces;
using CavuTest.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CavuTest.Application.Bookings.Queries.GetBookingCount
{
    public class GetBookingsCountQueryHandler : IRequestHandler<GetBookingsCountQuery, int>
    {
        private readonly IApplicationDbContext _context;

        public GetBookingsCountQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(GetBookingsCountQuery request, CancellationToken cancellationToken)
        {
            return await _context.BookingEntities
                .CountAsync(x =>
                    x.DateFrom >= request.DateFrom.ToEpochTime() && x.DateTo <= request.DateTo.ToEpochTime() ||
                    x.DateFrom <= request.DateFrom.ToEpochTime() &&
                    x.DateTo >= request.DateFrom.ToEpochTime() || // overlapping start date
                    x.DateFrom <= request.DateTo.ToEpochTime() &&
                    x.DateTo >= request.DateTo.ToEpochTime(), cancellationToken: cancellationToken); //overlapping end date

        }
    }
}
