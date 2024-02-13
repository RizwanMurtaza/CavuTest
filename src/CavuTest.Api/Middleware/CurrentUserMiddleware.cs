namespace CavuTest.Api.Middleware;

public class CurrentUserMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        // This can be used If we want to setup Identity in request pipeline 
        await next(context);
    }

}