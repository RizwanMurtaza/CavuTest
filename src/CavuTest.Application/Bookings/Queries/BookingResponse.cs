using AutoMapper;
using CavuTest.Domain.Entities;

namespace CavuTest.Application.Bookings.Queries
{
    public class BookingResponse
    {
        public long DateFrom { get; set; }

        public long DateTo { get; set; }

        public string Name { get; set; } = string.Empty;

        public long Price { get; set; }


        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<BookingEntity, BookingResponse>();
            }
        }
    }
}
