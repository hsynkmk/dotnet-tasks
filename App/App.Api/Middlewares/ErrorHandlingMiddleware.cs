using App.Domain.Exceptions;
using System.Net;

namespace App.API.Middlewares;

public class ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger) : IMiddleware
{
	public async Task InvokeAsync(HttpContext context, RequestDelegate next)
	{
		try
		{
			await next.Invoke(context);
		}

		catch (NotFoundException ex)
		{
			logger.LogError(ex, ex.Message);
			context.Response.StatusCode = (int)HttpStatusCode.NotFound;
			await context.Response.WriteAsync(ex.Message);
		}

		//catch(ValidationException ex)
  //      {
  //          logger.LogError(ex, ex.Message);
  //          context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
  //          await context.Response.WriteAsync(ex.Message);
  //      }

		catch (Exception ex)
		{
			logger.LogError(ex, ex.Message);
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			await context.Response.WriteAsync("An unexpected error occurred. Please try again later.");
		}
	}
}
