using Microsoft.AspNetCore.Authorization;

namespace Ciam;

public class UserAdminHandler : AuthorizationHandler<UserAdminRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, UserAdminRequirement requirement)
    {
        var userRole = context.User.FindFirst(c => c.Type == "roles" && c.Value == "user-role");
        var adminRole = context.User.FindFirst(c => c.Type == "roles" && c.Value == "admin-role");

        if (userRole != null || adminRole != null)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
