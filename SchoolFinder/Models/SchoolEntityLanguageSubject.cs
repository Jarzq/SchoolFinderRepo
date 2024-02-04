using SchoolFinder.models;
using System.ComponentModel.DataAnnotations;

namespace SchoolFinder.Models
{
    public class SchoolEntityLanguageSubject
    {
        [Key]
        public int Id { get; set; }
        public int SchoolEntityId { get; set; }
        public SchoolEntity SchoolEntity { get; set; }

        public int LanguageId { get; set; }
        public Subject LanguageSubject { get; set; }
    }
}