using System.ComponentModel.DataAnnotations;
using CavuTest.Application.Bookings.Queries.GetAll;
using CavuTest.Application.Bookings.Queries.GetBookingAvailability;
using CavuTest.Application.Bookings.Queries.PagedBooking;
using Microsoft.AspNetCore.Mvc;

namespace CavuTest.Api.Controllers.Request
{
    public class GetBookingRequestModel
    {
        [Required]
        [FromQuery(Name = "DateFrom")]
        public DateTime? DateFrom { get; set; }

        [Required]
        [FromQuery(Name = "DateTo")]
        public DateTime? DateTo { get; set; }


        // These should be separate request models 
        public BookingAvailabilityQuery ToBookingAvailabilityQuery()
        {
            return new BookingAvailabilityQuery
            {
                DateFrom = this.DateFrom.Value,
                DateTo = this.DateTo.Value,
            };
        }
        public GetAllBookingsQuery ToGetAllBookingsQuery()
        {
            return new GetAllBookingsQuery
            {
                DateFrom = this.DateFrom.Value,
                DateTo = this.DateTo.Value,
            };
        }
        public BookingsWithPaginationQuery ToBookingsWithPaginationQuery()
        {
            return new BookingsWithPaginationQuery
            {
                DateFrom = this.DateFrom.Value,
                DateTo = this.DateTo.Value,
            };
        }


    }
}
