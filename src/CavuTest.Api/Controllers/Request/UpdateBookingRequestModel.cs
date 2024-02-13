using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CavuTest.Api.Controllers.Request
{
    public class UpdateBookingRequestModel
    {
        [Required]
        [FromBody]
        public DateTime? DateFrom { get; set; }

        [Required]
        [FromBody]
        public DateTime? DateTo { get; set; }

        [Required]
        [FromBody]
        public string Name { get; set; } = string.Empty;

    }
}
