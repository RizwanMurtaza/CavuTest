using CavuTest.Application.Models;

namespace CavuTest.Application.Services
{
    public class PriceCalculatorService : IPriceCalculatorService
    {
        public async Task<double> CalculatePrice(DateTime dateFrom, DateTime dateTo)
        {
            int weekendDaysCount = 0;
            int weekDaysCount = 0;

            for (var day = dateFrom; day.Date <= dateTo; day = day.AddDays(1))
            {
                if (day.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
                {
                    weekendDaysCount++;
                }
                else
                {
                    weekDaysCount++;
                }
            }

            var weekendDaysPrice = ApplicationConstants.WeekendPrice * weekendDaysCount;
            var weekDaysPrice = ApplicationConstants.WeekdayPrice * weekDaysCount;

            var totalPrice = weekDaysPrice + weekendDaysPrice;


            switch (dateFrom.Month)
            {
                case 6 or 7 or 8:
                    {
                        var priceWithMultiplier = totalPrice * ApplicationConstants.SummerPriceMultiplier;
                        totalPrice = Math.Round(priceWithMultiplier, 2, MidpointRounding.AwayFromZero);
                        break;
                    }
                case 12 or 1 or 2 or 3:
                    {
                        var priceWithMultiplier = totalPrice * ApplicationConstants.WinterPriceMultiplier;
                        totalPrice = Math.Round(priceWithMultiplier, 2, MidpointRounding.AwayFromZero);
                        break;
                    }
            }

            return await Task.FromResult(totalPrice);
        }
    }
}
