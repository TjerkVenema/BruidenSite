using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BruidenSite.Pages.InlogSysteem
{
    public class WensenLijstAdd : PageModel
    {
        [BindProperty]
        public Cadeau NewPresent { get; set; }
        
        [BindProperty]
        public List<Cadeau> Presents { get; set; }
        
        public void OnPostAdd()
        {
            int Id = Convert.ToInt32(Request.Cookies["userId"]);
            var wensenlijstId = Repository.GetListIduser(Id);
            int _wensenlijstId = wensenlijstId.WensenLijstId;
            NewPresent.WensenlijstId = _wensenlijstId;
            Repository.AddCadeau(NewPresent);
            
            var list = Repository.GetCadeausByListId(_wensenlijstId);
            Presents = list;
        }
        
        public void OnGet()
        {
            int Id = Convert.ToInt32(Request.Cookies["userId"]);
            var wensenlijstId = Repository.GetListIduser(Id);
            int _wensenlijstId = wensenlijstId.WensenLijstId;
            
            var list = Repository.GetCadeausByListId(_wensenlijstId);
            Presents = list;
        }
    }
}