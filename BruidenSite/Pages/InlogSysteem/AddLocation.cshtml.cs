using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BruidenSite.Pages.InlogSysteem
{
    public class AddLocation : PageModel
    {
        [BindProperty]
        public User LocUser { get; set; }

        public IActionResult OnPostLocation()
        {
            string location = LocUser.TrouwLocatie;
            Response.Cookies.Append("Location", location);
            return RedirectToPage("/InlogSysteem/Confirm");
        }
        
        public void OnGet()
        {
            
        }
    }
}