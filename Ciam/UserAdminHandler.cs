using Microsoft.AspNetCore.Authorization;

namespace Ciam;

public class UserAdminHandler : AuthorizationHandler<UserAdminRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context, UserAdminRequirement requirement)
    {
        
        return Task.CompletedTask;
    }
}
