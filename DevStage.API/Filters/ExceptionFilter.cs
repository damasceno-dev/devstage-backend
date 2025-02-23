using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using DevStage.Communication.Responses;
using DevStage.Exception;

namespace DevStage.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var environment = context.HttpContext.RequestServices.GetService<IWebHostEnvironment>();
        if (context.Exception is DevStageException exception)
        {
            context.HttpContext.Response.StatusCode = exception.GetStatusCode;
            context.Result = new ObjectResult(new ResponseErrorJson(exception.GetErrors)
            {
                Method = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}"
            });
        }
        else
        {
            var errorMessage = environment?.EnvironmentName == "Development" ? context.Exception.Message : ResourcesErrorMessages.UnkownError;
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(errorMessage)
            {
                Method = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}"
            });
        }
    }
}