using System;
using System.Collections.Generic;
using System.Linq;
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
        
        [BindProperty]
        public int cadId { get; set; }
        
        public void OnPostAdd()
        {
            int Id = Convert.ToInt32(Request.Cookies["userId"]);
            var wensenlijstId = Repository.GetListIduser(Id);
            int _wensenlijstId = wensenlijstId.WensenLijstId;
            var list = Repository.GetCadeausByListId(_wensenlijstId);
            if (list.Count == 0)
            {
                NewPresent.Prioriteit = 0;
            }
            else
            {
                var lastItem = list.Last();
                NewPresent.Prioriteit = lastItem.Prioriteit -1;
            }
            NewPresent.WensenlijstId = _wensenlijstId;
            Repository.AddCadeau(NewPresent);

            Presents = Repository.GetCadeausByListId(_wensenlijstId);
        }

        public void OnPostDelete()
        {
            int Id = Convert.ToInt32(Request.Cookies["userId"]);
            var wensenlijstId = Repository.GetListIduser(Id);
            int _wensenlijstId = wensenlijstId.WensenLijstId;
                        
            int cadeauid = cadId;
            Repository.RemoveListItem(cadeauid, _wensenlijstId);

            Presents = Repository.GetCadeausByListId(_wensenlijstId);
        }

        public void OnPostUp()
        {
            int cadeauId = cadId;
            WensenLijst wensenLijst = Repository.GetListIduser(Convert.ToInt32(Request.Cookies["userId"]));
            int wensenLijstId = wensenLijst.WensenLijstId;
            
            Repository.UpdatePrioUp(cadeauId, wensenLijstId);

            Presents = Repository.GetCadeausByListId(wensenLijstId);
        }

        public void OnPostDown()
        {
            int cadeauId = cadId;
            WensenLijst wensenLijst = Repository.GetListIduser(Convert.ToInt32(Request.Cookies["userId"]));
            int wensenLijstId = wensenLijst.WensenLijstId;
            
            Repository.UpdatePrioDown(cadeauId, wensenLijstId);

            Presents = Repository.GetCadeausByListId(wensenLijstId);
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

