using System.ComponentModel.DataAnnotations;
using CavuTest.Application.Bookings.Commands.CreateBooking;
using Microsoft.AspNetCore.Mvc;

namespace CavuTest.Api.Controllers.Request
{
    public class CreateBookingRequestModel
    {
        [Required]
        [FromBody]
        public DateTime? DateFrom { get; set; }

        [Required]
        [FromBody]
        public DateTime? DateTo { get; set; }

        [Required]
        [FromBody]
        public string Title { get; set; } = string.Empty;


        // can be done through auto mapper
        public CreateBookingCommandRequest ToCommand()
        {
            return new CreateBookingCommandRequest
            {
                DateFrom = this.DateFrom.Value,
                DateTo = this.DateTo.Value,
                Title = this.Title
            };
        }
    }
}
