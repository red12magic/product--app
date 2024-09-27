using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class SessionAuthorizationAttribute : ActionFilterAttribute {
    public override void OnActionExecuting(ActionExecutingContext context) {
        var userIdString = context.HttpContext.Session.GetString("UserId");

        if (string.IsNullOrEmpty(userIdString)) {
            // Redirect to login if the session does not contain UserId
            context.Result = new RedirectToActionResult("Index", "Login", null);
        }

        base.OnActionExecuting(context);
    }
}
