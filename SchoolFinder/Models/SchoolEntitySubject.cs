using SchoolFinder.models;
using System.ComponentModel.DataAnnotations;

namespace SchoolFinder.Models
{
    public class SchoolEntitySubject
    {
        [Key]
        public int Id { get; set; }
        public int SchoolEntityId { get; set; }
        public SchoolEntity SchoolEntity { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
