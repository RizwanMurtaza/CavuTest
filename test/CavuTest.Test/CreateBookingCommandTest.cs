using CavuTest.Application.Bookings.Commands.CreateBooking;
using CavuTest.Application.Interfaces;
using CavuTest.Application.Services;
using CavuTest.Domain.Entities;
using Moq;

namespace CavuTest.Test
{
    public class Tests
    {
        private readonly Mock<IApplicationDbContext> dbContext = new();
        private readonly Mock<IPriceCalculatorService> priceCalculatorService = new();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task CreateBookingWithValidDates()
        {
            // Just an example to test the command by mocking
            this.dbContext.Setup(x =>
                x.BookingEntities.Add(It.IsAny<BookingEntity>()));
            var bookingCommand = new CreateBookingCommandRequest()
            {
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddHours(2)
            };
            var handler = new CreateBookingCommandHandler(dbContext.Object, priceCalculatorService.Object);

            var result = await handler.Handle(bookingCommand, new CancellationToken());

            Assert.IsNotNull(result);

        }

    }
}