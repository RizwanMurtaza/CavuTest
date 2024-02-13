using CavuTest.Application.Bookings.Commands.CreateBooking;
using CavuTest.Application.Interfaces;
using CavuTest.Application.Services;
using Moq;

namespace FunctionalTest
{
    public class Tests
    {

        private CreateBookingCommandValidator Validator;

        [SetUp]
        public void Setup()
        {
            Validator = new CreateBookingCommandValidator();

        }

        [Test]
        [TestCase("2024-10-10 01:00", "2024-10-11 01:00")]
        public async Task CreateBookingWithValidDates(string startDate, string endDate)
        {
            var command = new CreateBookingCommandRequest()
            {
                DateFrom = DateTime.Parse(startDate),
                DateTo = DateTime.Parse(endDate),
                Title = "SomeTitle"
            };

            var result = await Validator.ValidateAsync(command);

            Assert.IsTrue(result.IsValid);
            Assert.That(result.Errors, Has.Count.EqualTo(0));

        }

        [Test]
        [TestCase("2020-10-10 01:00")]
        public async Task CreateBookingWithInvalidStartDate(string startDate)
        {
            var command = new CreateBookingCommandRequest()
            {
                DateFrom = DateTime.Parse(startDate),
                DateTo = DateTime.Now.AddHours(2),
                Title = "SomeTitle"
            };

            var result = await Validator.ValidateAsync(command);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
            var expectedResponse = "Booking Start Date Must be in future";
            Assert.That(expectedResponse, Is.EqualTo(result.Errors.First().ToString()));
        }

        [Test]
        [TestCase("2023-02-12 01:00")]
        public async Task CreateBookingWithInvalidEndDate(string endDate)
        {
            var command = new CreateBookingCommandRequest()
            {
                DateFrom = DateTime.Now.AddDays(60),
                DateTo = DateTime.Parse(endDate),
                Title = "SomeTitle"
            };

            var result = await Validator.ValidateAsync(command);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors, Has.Count.EqualTo(2));
            var expectedResponse = "Booking End Date Must be in future";
            Assert.That(result.Errors.Select(x => x.ErrorMessage), Does.Contain(expectedResponse));

        }

        [Test]
        [TestCase("2024-10-10 01:00", "2024-10-09 01:00")]
        public async Task CreateBookingWithDatesWhereEndDateIsBeforeStartDate(string startDate, string endDate)
        {
            var command = new CreateBookingCommandRequest()
            {
                DateFrom = DateTime.Parse(startDate),
                DateTo = DateTime.Parse(endDate),
                Title = "SomeTitle"
            };

            var result = await Validator.ValidateAsync(command);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
            var expectedResponse = "Booking End Date must be greater than start date";
            Assert.That(expectedResponse, Is.EqualTo(result.Errors.First().ToString()));
        }

        [Test]
        [TestCase("2024-10-10 01:00", "2024-10-11 01:00")]
        public async Task BookingTitleMissing(string startDate, string endDate)
        {
            var command = new CreateBookingCommandRequest()
            {
                DateFrom = DateTime.Parse(startDate),
                DateTo = DateTime.Parse(endDate),
            };
            var result = await Validator.ValidateAsync(command);

            Assert.IsFalse(result.IsValid);
            Assert.That(result.Errors, Has.Count.EqualTo(1));
            var expectedResponse = "Booking Title is required";
            Assert.That(expectedResponse, Is.EqualTo(result.Errors.First().ToString()));
        }

        [Test]
        [TestCase("2024-10-11 01:00")]
        public async Task BookingWithStartDateMissing(string endDate)
        {
            var command = new CreateBookingCommandRequest()
            {
                DateTo = DateTime.Parse(endDate),
                Title = "SomeTitle"
            };
            var result = await Validator.ValidateAsync(command);

            Assert.IsFalse(result.IsValid);

            Assert.That(result.Errors, Has.Count.EqualTo(2));
            var expectedResponse = "Booking Start Date is required";
            Assert.That(result.Errors.Select(x => x.ErrorMessage), Does.Contain(expectedResponse));
        }

        [Test]
        [TestCase("2024-10-11 01:00")]
        public async Task BookingWithEndDateMissing(string startDate)
        {
            var command = new CreateBookingCommandRequest()
            {
                DateFrom = DateTime.Parse(startDate),
                Title = "SomeTitle"
            };
            var result = await Validator.ValidateAsync(command);

            Assert.IsFalse(result.IsValid);

            Assert.That(result.Errors, Has.Count.EqualTo(2));
            var expectedResponse = "Booking End date is required";
            Assert.That(result.Errors.Select(x => x.ErrorMessage), Does.Contain(expectedResponse));
        }
    }
}