using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BruidenSite.Pages.InlogSysteem
{
    public class Logout : PageModel
    {
        public void OnGet()
        {
            Response.Cookies.Delete("userId");
        }
    }
}