using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BruidenSite.Pages.InlogSysteem
{
    public class Register : PageModel
    {
        [BindProperty]
        public User _user { get; set; }
        
        [BindProperty]
        public User passcheck { get; set; }

        private static Random _random = new Random();

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public IActionResult OnPostAdd()
        {
            if (ModelState.IsValid && _user.PassWord == passcheck.PassWord)
            {
                User _newUser = new User();
                WensenLijst _newWensenLijst = new WensenLijst();
                
                _newWensenLijst.UniqueId = RandomString(10);
                
                Repository.AddList(_newWensenLijst);

                string uniqueId = Convert.ToString(_newWensenLijst.UniqueId);
                var wensenLijstId = Repository.GetListIdcode(uniqueId);
                
                _newUser = _user;
                _newUser.WensenlijstId = wensenLijstId.WensenLijstId;
                
                Repository.AddUser(_newUser);
                return RedirectToPage("/InlogSysteem/Login");
            }
            else
            {
                return Page();
            }
        }
        
        
        public void OnGet()
        {
            
        }
    }
}