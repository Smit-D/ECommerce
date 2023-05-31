using Services.Models;
using System.Text.Json;

namespace ECommerce.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        #region Invoke
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //Capture Exception using HandleException Method
                await HandleException(httpContext, ex);
            }
        }
        #endregion

        #region HandleException
        private static async Task HandleException(HttpContext httpContext, Exception exception)
        {
            //declare reponse object
            var response = new ErrorResponse()
            {
                Message = exception.Message,
                Error = exception.TargetSite?.Name,
            };

            // Set the response content type to JSON
            httpContext.Response.ContentType = "application/json";
          
            switch (exception)
            {
               case InvalidDataException:
                    httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    response.StatusCode = StatusCodes.Status422UnprocessableEntity;
                    break;
                case UnauthorizedAccessException://unauthroized access error
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    response.StatusCode = StatusCodes.Status401Unauthorized;
                    break;
                case NotImplementedException://method not implemented error
                    httpContext.Response.StatusCode = StatusCodes.Status501NotImplemented;
                    response.StatusCode = StatusCodes.Status501NotImplemented;
                    break;
                default:
                    httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }
           
            // Serialize the response object to JSON
            var jsonResponse = JsonSerializer.Serialize(response);
            // Write the JSON response to the response body
            await httpContext.Response.WriteAsync(jsonResponse);
        }
        #endregion

    }
}
