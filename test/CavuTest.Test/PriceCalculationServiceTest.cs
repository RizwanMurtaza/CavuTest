using CavuTest.Application.Services;

namespace CavuTest.Test
{
    public class PriceCalculationServiceTest
    {
        private IPriceCalculatorService priceCalculatorService;

        [SetUp]
        public void Setup()
        {
            this.priceCalculatorService = new PriceCalculatorService();
        }

        [Test]
        [TestCase("2024-05-25 01:00", "2024-05-26 01:00", 101.00)] // Only Weekend 2 Days day is 50.50
        [TestCase("2024-05-26 01:00", "2024-05-27 01:00", 70.75)] // 1 Weekend Day 1 Normal Day 50.50 + 20.25 =70.75

        [TestCase("2024-07-20 01:00", "2024-07-22 01:00", 206.13)] // 2 Weekend Day 1 Normal Day Summer ((2*50.50) + 20.25) * 1.7= 206.125
        public async Task CreateBooking_Weekend(string startDate, string endDate, double total)
        {
            var result =
                await priceCalculatorService.CalculatePrice(DateTime.Parse(startDate), DateTime.Parse(endDate));
            Assert.That(result, Is.EqualTo(total));

        }
    }
}