using System.Security.Claims;

namespace CavuTest.Application.Interfaces;

public interface ICurrentUserInitializer
{
    void SetCurrentUser(ClaimsPrincipal user);

    bool IsAuthenticated();

}