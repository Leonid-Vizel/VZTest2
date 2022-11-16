using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using VZTest2.Instruments;

namespace VZTest2.Filters
{
    public class AuthLoaderAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ISession session = context.HttpContext.Session;
            ViewDataDictionary data = (context.Controller as Controller).ViewData;
            Authenticator.CheckUser(session, data);
            await next();
        }
    }
}
