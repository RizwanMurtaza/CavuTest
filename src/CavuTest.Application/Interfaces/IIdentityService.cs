using CavuTest.Application.Models;

namespace CavuTest.Application.Interfaces;

public interface IIdentityService
{
    Task<string?> GetUserNameAsync(string userId);
}
