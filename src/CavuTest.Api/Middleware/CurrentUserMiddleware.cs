using CavuTest.Application.Interfaces;

namespace CavuTest.Api.Middleware;

public class CurrentUserMiddleware : IMiddleware
{
    private readonly ICurrentUserInitializer _currentUserInitializer;

    public CurrentUserMiddleware(ICurrentUserInitializer currentUserInitializer)
    {
        _currentUserInitializer = currentUserInitializer;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // This can be used If we want to setup in request pipeline 
        // this is just an example to set the uer

        _currentUserInitializer.SetCurrentUser(context.User);

        await next(context);
    }

}