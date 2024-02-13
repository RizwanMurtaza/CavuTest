namespace CavuTest.Application.Services;

public interface IPriceCalculatorService
{
    Task<double> CalculatePrice(DateTime dateFrom, DateTime dateTo);
}