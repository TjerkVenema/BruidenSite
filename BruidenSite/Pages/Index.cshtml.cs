using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace BruidenSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public RedirectToPageResult OnGet()
        {
            Response.Cookies.Delete("listId");
            string Id = Request.Cookies["userId"];
            if (Id != null)
            {
                return RedirectToPage("/InlogSysteem/Overview");
            }
            return null;
        }
    }
}