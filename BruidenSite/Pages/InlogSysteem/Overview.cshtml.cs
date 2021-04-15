using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BruidenSite.Pages.InlogSysteem
{
    public class Overview : PageModel
    {
        [BindProperty]
        public string UniqueCode { get; set; }
        
        public void OnGet()
        {
            Response.Cookies.Delete("Date");
        }

        public IActionResult OnPostCode()
        {
            string code = UniqueCode;
            WensenLijst wensenLijst = Repository.GetListIdByCode(code);
            User user = Repository.GetById(Convert.ToInt32(Request.Cookies["userId"]));
            if (wensenLijst == null)
            {
                return Page();
            }
            else
            {
                Response.Cookies.Append("gastnaam", user.UserName);
                Response.Cookies.Append("listId", wensenLijst.WensenLijstId.ToString());
                return RedirectToPage("/InlogSysteem/WensenLijstGast");
            }
        }
    }
}