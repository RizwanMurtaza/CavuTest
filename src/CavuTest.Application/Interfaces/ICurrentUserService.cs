using System.Security.Claims;

namespace CavuTest.Application.Interfaces;

public interface ICurrentUserService
{

    string? CurrentUserId { get; }
}
