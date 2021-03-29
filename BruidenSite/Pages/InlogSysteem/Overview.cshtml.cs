using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BruidenSite.Pages.InlogSysteem
{
    public class Overview : PageModel
    {
        public void OnGet()
        {
            int Id = Convert.ToInt32(Request.Cookies["userId"]);

            User user = new User(); 
            user = Repository.GetDL(Id);

            ViewData["Trouwlocatie"] = user.TrouwLocatie;
            ViewData["Trouwdatum"] = user.TrouwDatum;
        }
    }
}