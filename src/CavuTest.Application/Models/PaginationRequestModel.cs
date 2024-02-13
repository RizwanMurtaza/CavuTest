namespace CavuTest.Application.Models;
public abstract class PaginationRequestModel
{
    public int Page { get; set; } = 0;

    public int PageSize { get; set; } = 10;

}