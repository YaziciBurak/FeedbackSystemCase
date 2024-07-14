using Microsoft.AspNetCore.Builder;
using System.Runtime.CompilerServices;

namespace Core.Exceptions.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void
        ConfigureCustomExceptionMiddleware(this IApplicationBuilder app) => app.UseMiddleware<ExceptionMiddleware>();
}
