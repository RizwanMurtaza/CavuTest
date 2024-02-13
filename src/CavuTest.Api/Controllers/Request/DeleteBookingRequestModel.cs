using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace CavuTest.Api.Controllers.Request
{
    public class DeleteBookingRequestModel
    {
        [Required]
        [FromRoute]
        public Guid Id { get; set; }
    }
}
