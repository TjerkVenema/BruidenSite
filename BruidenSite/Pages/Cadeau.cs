namespace BruidenSite.Pages
{
    public class Cadeau
    {
        public int CadeauId { get; set; }
        public string CadeauNaam { get; set; }
        public int Prioriteit { get; set; }
        public bool Done { get; set; }
        public string Koper { get; set; }
        public int WensenlijstId { get; set; }
    }
}