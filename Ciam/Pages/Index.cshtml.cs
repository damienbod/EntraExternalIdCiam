using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ciam.Pages;

public class IndexModel : PageModel
{
    public List<string> Roles { get; set; } = [];

    public void OnGet()
    {
        // magic namespaces
        var msMagicNamespace = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        var claims = User.Claims.ToList();
        foreach (var claim in claims)
        {
            if (claim != null && claim.Type == "roles")
            {
                Roles.Add(claim.Value);
            }

            if (claim != null && claim.Type == msMagicNamespace)
            {
                Roles.Add(claim.Value);
            }
        }
    }
}
