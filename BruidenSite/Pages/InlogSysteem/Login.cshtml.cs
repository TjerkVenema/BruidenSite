using System;
using Dapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BruidenSite.Pages.InlogSysteem
{
    public class Login : PageModel
    {
        [BindProperty]
        public User checkuser { get; set; }
        [BindProperty]
        public string uniqueCode { get; set; }
        [BindProperty]
        public string gastNaam { get; set; }

        
        public IActionResult OnPostLogin() 
        {
             string username1 = checkuser.UserName;
             string password = checkuser.PassWord;
             if (username1 == null || password == null)
             {
                 return Redirect("/InlogSysteem/Login");
             }

             User user = Repository.Login(username1, password);
             
             if (user == null)
             {
                 return Page();
             }
             
             if (user.TrouwDatum == DateTime.MinValue)
             {
                 string userId = user.UserId.ToString();
                 Response.Cookies.Append("userId", userId);
                 return RedirectToPage("/InlogSysteem/AddWeddingDate");
             }
             
             else
             {
                 string userId = user.UserId.ToString();
                 Response.Cookies.Append("userId", userId);
                 return RedirectToPage("/InlogSysteem/Overview");
             }
        }

        public IActionResult OnPostCode()
        {
            string uniquecode = uniqueCode;
            string gastnaam = gastNaam;
            if (gastnaam == null || uniquecode == null)
            {
                return Page();
            }

            WensenLijst listId = Repository.GetListIdByCode(uniquecode);
            if (listId == null)
            {
                return Page();
            }
            else
            {
                Response.Cookies.Append("gastnaam", gastnaam);
                Response.Cookies.Append("listId", listId.WensenLijstId.ToString());
                return RedirectToPage("/InlogSysteem/WensenLijstGast");
            }
        }
    
        public void OnGet()
        {
            
        }
    }
}