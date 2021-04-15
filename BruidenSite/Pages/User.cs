using System;
using System.ComponentModel.DataAnnotations;

namespace BruidenSite.Pages
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        
        
        [MinLength(6, ErrorMessage = "Minimaal 6 karakters")]
        [MaxLength(30)]
        public string PassWord { get; set; }
        public string EMailadres { get; set; }
        public DateTime TrouwDatum { get; set; }
        public string TrouwLocatie { get; set; }
        public int WensenlijstId { get; set; }
    }
}