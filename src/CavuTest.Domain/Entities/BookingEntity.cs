using CavuTest.Domain.Common;

namespace CavuTest.Domain.Entities
{
    public class BookingEntity : BaseAuditableEntity
    {

        public long DateFrom { get; set; }

        public long DateTo { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Price { get; set; }

        public static BookingEntity CreateBookingEntity(
            DateTime dateFrom,
            DateTime dateTo,
            string name,
            double price)
        {
            return new BookingEntity()
            {
                Id = Guid.NewGuid(),
                DateFrom = dateFrom.ToEpochTime(),
                DateTo = dateTo.ToEpochTime(),
                Name = name,
                Price = price,
                Created = DateTime.UtcNow.ToEpochTime(),
                LastModified = DateTime.UtcNow.ToEpochTime()
            };
        }
    }
}
