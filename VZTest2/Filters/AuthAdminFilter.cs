using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;
using VZTest2.Instruments;

namespace VZTest2.Filters
{
    public class AuthAdminFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ISession session = context.HttpContext.Session;
            ViewDataDictionary data = (context.Controller as Controller).ViewData;
            bool? authResult = Authenticator.CheckAdmin(session, data);
            if (authResult == null)
            {
                context.Result = new ForbidResult();
            }
            else if (!authResult.Value)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
            else
            {
                await next();
            }
        }
    }
}
