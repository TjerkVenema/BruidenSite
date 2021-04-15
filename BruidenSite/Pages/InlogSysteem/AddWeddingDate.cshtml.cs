using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BruidenSite.Pages.InlogSysteem
{
    public class AddWeddingDate : PageModel
    {
        [BindProperty]
        public User DateUser { get; set; }

        public IActionResult OnPostDate()
        {
            DateTime dateTime = DateUser.TrouwDatum;
            string DateTime = dateTime.ToString();
            Response.Cookies.Append("Date", DateTime);

            return RedirectToPage("/InlogSysteem/AddLocation");
        }
        
        public void OnGet()
        {
            Response.Cookies.Delete("Date");
        }
    }
}