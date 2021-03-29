using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BruidenSite.Pages.InlogSysteem
{
    public class Confirm : PageModel
    {
        [BindProperty]
        public User ConfirmUser { get; set; }

        public IActionResult OnPostConfirm()
        {
            string date = Request.Cookies["Date"];
            DateTime dateTime = Convert.ToDateTime(date);
            string locatie = Request.Cookies["Location"];
            string id = Request.Cookies["userId"];
            int Id = Convert.ToInt32(id);
            
            ConfirmUser.TrouwDatum = dateTime;
            ConfirmUser.TrouwLocatie = locatie;
            ConfirmUser.UserId = Id;
            
            Repository.AddDl(ConfirmUser);
            
            Response.Cookies.Delete("Date");
            Response.Cookies.Delete("Location");
            
            return RedirectToPage("/InlogSysteem/Overview");
        }
        
        public void OnGet()
        {
            
        }
    }
}