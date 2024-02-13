using AutoMapper;
using AutoMapper.QueryableExtensions;
using CavuTest.Application.Interfaces;
using CavuTest.Domain.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CavuTest.Application.Bookings.Queries.GetAll
{
    public class GetAllBookingsQueryHandler : IRequestHandler<GetAllBookingsQuery, List<BookingResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllBookingsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<BookingResponse>> Handle(GetAllBookingsQuery request, CancellationToken cancellationToken)
        {
            return await _context.BookingEntities.
                Where(x =>
                    x.DateFrom >= request.DateFrom.ToEpochTime()
                    && x.DateFrom <= request.DateTo.ToEpochTime())
                .ProjectTo<BookingResponse>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken: cancellationToken);
        }
    }
}
