using System;

namespace BruidenSite.Pages
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string EMailadres { get; set; }
        public DateTime TrouwDatum { get; set; }
        public string TrouwLocatie { get; set; }
        public int WensenlijstId { get; set; }
    }
}