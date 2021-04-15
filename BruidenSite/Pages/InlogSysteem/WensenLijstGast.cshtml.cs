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
        
        [BindProperty]
        public List<int> AreChecked { get; set; }

        public void OnPostSubmit()
        {
            string buyername = Request.Cookies["gastnaam"];
            Repository.UpdateDoneAndBuyer(AreChecked, buyername);
            
            List<Cadeau> Pres = new List<Cadeau>();
            int listId = Convert.ToInt32(Request.Cookies["listId"]);
            var list = Repository.GetCadeausByListId(listId);
            foreach (var cadeau in list)
            {
                if (cadeau.Done == false)
                {
                    Pres.Add(cadeau);
                    Presents = Pres;
                }
            }
        }

        public void OnGet()
        {
            List<Cadeau> Pres = new List<Cadeau>();
            int listId = Convert.ToInt32(Request.Cookies["listId"]);
            var list = Repository.GetCadeausByListId(listId);
            foreach (var cadeau in list)
            {
                if (cadeau.Done == false)
                {
                    Pres.Add(cadeau);
                    Presents = Pres;
                }
            }
        }
    }
}