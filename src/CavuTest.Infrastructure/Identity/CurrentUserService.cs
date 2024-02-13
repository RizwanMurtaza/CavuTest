using System.Security.Claims;
using CavuTest.Application.Interfaces;

namespace CavuTest.Infrastructure.Identity;

public class CurrentUserService : ICurrentUserInitializer
{
    private ClaimsPrincipal? _user;

    public void SetCurrentUser(ClaimsPrincipal user)
    {
        _user = user;
    }
    public bool IsAuthenticated()
    {
        return _user?.Identity?.IsAuthenticated is true;
    }


}