using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Ciam.Pages;

public class IndexModel : PageModel
{
    public void OnGet()
    {
        var user = User.Claims.ToList();
    }
}
