using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ValueApi.Middlewares
{
    public class HealthCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _path;

        public HealthCheckMiddleware(RequestDelegate next, string path)
        {
            _next = next;
            _path = path;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Path.Value == _path)
            {
                await context.Response.WriteAsync("UP");
            }
            else
            {
                await this._next(context);
            }
        }
    }

    public static class HealthCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UseHealthCheck(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HealthCheckMiddleware>("/_health");
        }
    }
}
