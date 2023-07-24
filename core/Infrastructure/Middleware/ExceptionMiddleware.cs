using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace core.Infrastructure.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            string bodyRequest = string.Empty;
            try
            {
                httpContext.Request.EnableBuffering();
                using var reader = new StreamReader(httpContext.Request.Body);
                bodyRequest = await reader.ReadToEndAsync();
                httpContext.Request.Body.Position = 0;
                await _next(httpContext);
                reader.Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);

                //string resUrl = $"{httpContext.Request.Method}: {string.Format("{0}://{1}{2}{3}", httpContext.Request.Scheme, httpContext.Request.Host, httpContext.Request.Path, httpContext.Request.QueryString)}";
                //string resHeader = Newtonsoft.Json.JsonConvert.SerializeObject(httpContext.Request.Headers);
                //string exceptionMessage = ex.Message;
                //string errorDetail = Newtonsoft.Json.JsonConvert.SerializeObject(ex);
                _logger.LogError(ex, bodyRequest);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync("{\"message\":\"Internal Server Error.\"}");
        }
    }
}
