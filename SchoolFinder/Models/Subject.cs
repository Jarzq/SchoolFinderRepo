using System.ComponentModel.DataAnnotations;

namespace SchoolFinder.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<SchoolEntitySubject> SchoolEntitySubjects { get; set; }
    }
}
