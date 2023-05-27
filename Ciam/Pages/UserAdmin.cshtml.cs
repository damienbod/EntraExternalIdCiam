using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ciam.Pages;

[Authorize(Policy = "UserAdminPolicy")]
public class UserAdminModel : PageModel
{
    public List<string> Roles { get; set; } = new List<string>();

    public void OnGet()
    {
        var claims = User.Claims.ToList();
        foreach(var claim in claims)
        {
            if(claim != null && claim.Type == "roles")
            {
                Roles.Add(claim.Value);
            }
        }
    }
}
