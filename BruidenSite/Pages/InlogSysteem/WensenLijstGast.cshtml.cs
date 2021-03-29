using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BruidenSite.Pages.InlogSysteem
{
    public class WensenLijstGast : PageModel
    {
        [BindProperty]
        public List<Cadeau> Presents { get; set; }
        
        public void OnGet()
        {
            int listId = Convert.ToInt32(Request.Cookies["listId"]);
            Presents = Repository.GetCadeausByListId(listId);
        }
    }
}