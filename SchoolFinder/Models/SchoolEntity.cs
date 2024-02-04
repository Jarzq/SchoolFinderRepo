using SchoolFinder.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolFinder.models
{
    public class SchoolEntity
    {
        [Key]
        public int Id { get; set; }
        public string Dzielnica { get; set; }
        public string NazwaSzkoly { get; set; }
        public string SymbolOddzialu { get; set; }
        public string NazwaOddzialu { get; set; }
        public double MinimalnePunkty { get; set; }
        public double MaksymalnePunkty { get; set; }
        public int SchoolType { get; set; }
        public List<SchoolEntitySubject> SchoolEntitySubjects { get; set; }
        public List<SchoolEntityLanguageSubject> SchoolEntityLanguageSubjects { get; set; }
    }
}
