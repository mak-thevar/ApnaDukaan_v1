using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ApnaDukaan_v1.BLL.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public MyExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                httpContext.Response.StatusCode = 500;

                await httpContext.Response.WriteAsJsonAsync(new
                {
                    Status = 500,
                    Success = false,
                    Message = ex.Message
                });

            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyExceptionHandlerMiddleware>();
        }
    }
}
