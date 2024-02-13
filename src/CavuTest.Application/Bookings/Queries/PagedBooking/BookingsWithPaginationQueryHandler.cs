using AutoMapper;
using AutoMapper.QueryableExtensions;
using CavuTest.Application.Bookings.Queries;
using CavuTest.Application.Interfaces;
using CavuTest.Application.Models;
using CavuTest.Domain.Common;
using MediatR;

namespace CavuTest.Application.Bookings.Queries.PagedBooking;

public class BookingsWithPaginationQueryHandler : IRequestHandler<BookingsWithPaginationQuery, PaginatedList<BookingResponse>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public BookingsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<BookingResponse>> Handle(BookingsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.BookingEntities.
                Where(x =>
                    x.DateFrom >= request.DateFrom.ToEpochTime()
                    && x.DateFrom <= request.DateTo.ToEpochTime())
            .ProjectTo<BookingResponse>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.Page, request.PageSize);
    }
}
