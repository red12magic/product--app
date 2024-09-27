using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class RedirectIfAuthenticatedMiddleware {
    private readonly RequestDelegate _next;

    public RedirectIfAuthenticatedMiddleware(RequestDelegate next) {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context) {
        // Check if the user is trying to access the login page
        if (context.Request.Path.StartsWithSegments("/Login", StringComparison.OrdinalIgnoreCase)) {
            // Check if the user is already logged in
            var userIdString = context.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(userIdString)) {
                // Redirect to the book list page
                context.Response.Redirect("/Book/List");
                return;
            }
        }

        // Continue with the request pipeline
        await _next(context);
    }
}
