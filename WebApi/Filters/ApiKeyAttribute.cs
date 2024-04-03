using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi.Filters;

[AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
public class ApiKeyAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
       var configuration = context.HttpContext.RequestServices.GetService<IConfiguration>();
       var apiKey = configuration!.GetValue<string>("ApiKey");

       if (!context.HttpContext.Request.Query.TryGetValue("Key", out var providedkey)) 
       {
            context.Result = new UnauthorizedResult();
            return;
       }

       if (!apiKey!.Equals(providedkey) )
       {
            context.Result = new UnauthorizedResult();
            return;
       }

       await next();
    }
}
