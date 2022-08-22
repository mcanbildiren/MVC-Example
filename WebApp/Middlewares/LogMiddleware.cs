using System.Net;

namespace WebApp.Middlewares
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LogMiddleware> _logger;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.LogInformation("Request Middleware");
            var ip = context.Connection.RemoteIpAddress;

            if (ip!.Equals(IPAddress.Parse("::1")))
            {
                await _next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 403;

                await context.Response.WriteAsync("Forbidden");
            }

            await _next .Invoke(context);

            _logger.LogInformation("Response Middleware");

        }
    }
}
