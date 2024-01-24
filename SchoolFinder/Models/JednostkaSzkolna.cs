using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SchoolFinder.models
{
    public class JednostkaSzkolna
    {
        [Key]
        public int Id { get; set; }
        public string Dzielnica { get; set; }
        public string NazwaSzkoly { get; set; }
        public string SymbolOddzialu { get; set; }
        public string NazwaOddzialu { get; set; }
        public double MinimalnePunkty { get; set; }
        public double MaksymalnePunkty { get; set; }
    }
}
