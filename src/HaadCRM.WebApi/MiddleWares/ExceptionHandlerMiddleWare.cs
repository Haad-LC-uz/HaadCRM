using HaadCRM.WebApi.Models;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.WebApi.MiddleWares;

public class ExceptionHandlerMiddleWare(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next.Invoke(context);
        }

        catch (AlreadyExistException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = ex.StatusCode
            });

        }

        catch (ArgumentIsNotValidException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = ex.StatusCode
            });
        }

        catch (CustomException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = ex.StatusCode
            });
        }

        catch (NotFoundException ex)
        {
            context.Response.StatusCode = ex.StatusCode;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = ex.StatusCode
            });
        }

        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new Response()
            {
                Message = ex.Message,
                StatusCode = 500
            });
        }
    }
}
