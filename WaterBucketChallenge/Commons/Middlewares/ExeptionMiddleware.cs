using System.Text.Json;
using WaterBucketChallenge.Commons.Exceptions;

namespace WaterBucketChallenge.Commons.Middlewares
{
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate next;
        public ExeptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)ExceptionStatusCodes.GetExceptionStatusCode(ex);
                var result = new { message = ex.Message };
                await context.Response.WriteAsync(JsonSerializer.Serialize(result));
            }
        }
    }

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExeptionMiddleware>();
        }
    }
}
