using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;
using VZTest2.Instruments;

namespace VZTest2.Filters
{
    public class AuthFilterAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ISession session = context.HttpContext.Session;
            Controller? controller = (context.Controller as Controller);
            if (controller == null)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
                return;
            }
            ViewDataDictionary data = controller.ViewData;
            if (!Authenticator.CheckUser(session, data))
            {
                string requestlUrl = controller.HttpContext.Request.GetEncodedUrl();
                context.Result = new RedirectToActionResult("Login", "Auth", new { OldUrl = requestlUrl });
            }
            else
            {
                await next();
            }
        }
    }
}
