using Microsoft.AspNetCore.Authorization;

namespace Ciam;

public class UserAdminHandler : AuthorizationHandler<UserAdminRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, UserAdminRequirement requirement)
    {
        // magic namespaces
        var msMagicNamespace = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        var userRole = context.User.FindFirst(c => c.Type == "roles" && c.Value == "user-role");
        var adminRole = context.User.FindFirst(c => c.Type == "roles" && c.Value == "admin-role");

        if (userRole == null)
        {
            userRole = context.User.FindFirst(c => c.Type == msMagicNamespace && c.Value == "user-role");
        }

        if (adminRole == null)
        {
            adminRole = context.User.FindFirst(c => c.Type == msMagicNamespace && c.Value == "admin-role");
        }

        if (userRole != null || adminRole != null)
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
